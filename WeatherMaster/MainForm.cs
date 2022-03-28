using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherMaster.Models;

namespace WeatherMaster
{
    public partial class MainForm : Form
    {
        private readonly ICollection<string> _history = new List<string>();
        private AppSettings _settings;
        private RestClient _client;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Initialise settings
            _settings = Program.Configuration.GetSection("AppSettings").Get<AppSettings>();
            _client = new RestClient(_settings.WeatherApi);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Check if history file exists and load history
            if (File.Exists(_settings.HistoryFileName))
            {
                foreach (string line in File.ReadLines(_settings.HistoryFileName))
                {
                    _history.Add(line);
                }
            }

            //Populate history list
            if (_history.Any())
            {
                foreach (var line in _history.Reverse())
                {
                    lstHistory.Items.Add(line);
                }
                grbHistory.Visible = true;
            }
        }

        private async Task<IEnumerable<GeoResult>> GetCitiesFromNameAsync(string name)
        {
            var request = new RestRequest("geo/1.0/direct", Method.Get);
            request.AddQueryParameter("q", name);
            request.AddQueryParameter("limit", 5);
            request.AddQueryParameter("appid", _settings.ApiKey);

            var result = await _client.ExecuteAsync<IEnumerable<GeoResult>>(request);

            return result.Data;
        }

        private async Task<WeatherResult> GetWeatherResultForCityAsync(double latitude, double longitude)
        {
            var request = new RestRequest("data/2.5/weather", Method.Get);
            request.AddQueryParameter("lat", latitude);
            request.AddQueryParameter("lon", longitude);
            request.AddQueryParameter("appid", _settings.ApiKey);
            request.AddQueryParameter("units", _settings.Units);

            var result = await _client.ExecuteAsync<WeatherResult>(request);

            return result.Data;
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            //Validate empty string
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter a city to search");
                return;
            }

            //Query for cities based on text
            var geoResults = await GetCitiesFromNameAsync(txtSearch.Text.Trim());

            if (geoResults == null || !geoResults.Any())
            {
                MessageBox.Show($"Could not find city named {txtSearch.Text.Trim()}");
                return;
            }

            GeoResult selectedCity;
            //Display selection form if more than 1 city was returned
            if (geoResults.Count() > 1)
            {
                var selectionForm = new SelectionForm(geoResults);
                selectionForm.ShowDialog();
                selectedCity = selectionForm.SelectedItem;
            }
            else
            {
                selectedCity = geoResults.First();
            }

            //Request weather for selected city
            var weatherResult = await GetWeatherResultForCityAsync(selectedCity.Latitude, selectedCity.Longitude);

            if (weatherResult == null)
            {
                MessageBox.Show($"Could not get weather for {txtSearch.Text.Trim()}");
                return;
            }

            //Only write to history successful requests
            await WriteHistoryAsync(txtSearch.Text.Trim());

            //Display results
            DisplayResults(txtSearch.Text.Trim(), weatherResult);
        }

        private async Task WriteHistoryAsync(string location)
        {
            //Write to history file
            using StreamWriter file = new(_settings.HistoryFileName, append: true);
            await file.WriteLineAsync(location);

            //Add item to the top of the list
            lstHistory.Items.Insert(0, location);
            grbHistory.Visible = true;
        }

        private void DisplayResults(string location, WeatherResult result)
        {
            lblLocation.Text = location;
            lblTemperature.Text = result.Main.Temperature.ToString("N0");
            lblCurrentWeather.Text = result.Weather.First().Description.ToUpper();
            lblFeelsLike.Text = result.Main.FeelsLike.ToString("N0");
            grbResults.Visible = true;
        }

        private void LstHistory_Click(object sender, EventArgs e)
        {
            //When clicked copy value from history to textbox
            if (lstHistory.SelectedItem != null)
            {
                txtSearch.Text = lstHistory.SelectedItem.ToString();
            }
        }
    }
}