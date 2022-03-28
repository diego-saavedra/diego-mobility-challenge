using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeatherMaster.Models;

namespace WeatherMaster
{
    public partial class MainForm : Form
    {
        private readonly ICollection<string> _history = new List<string>();
        private AppSettings _settings;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Initialise settings
            _settings = Program.Configuration.GetSection("AppSettings").Get<AppSettings>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Check if history file exists and load history
            if (File.Exists("history.txt"))
            {
                foreach (string line in File.ReadLines(@"history.txt"))
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

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            //Validate empty string
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter a city to search");
                return;
            }

            //Query for cities based on text
            var client = new RestClient("https://api.openweathermap.org");
            var geoRequest = new RestRequest("geo/1.0/direct", Method.Get);
            geoRequest.AddQueryParameter("q", txtSearch.Text.Trim());
            geoRequest.AddQueryParameter("limit", 5);
            geoRequest.AddQueryParameter("appid", _settings.ApiKey);

            //Validate city results
            var geoResults = await client.ExecuteAsync<IEnumerable<GeoResult>>(geoRequest);

            if (geoResults.Data == null || !geoResults.Data.Any())
            {
                MessageBox.Show($"Could not find city named {txtSearch.Text.Trim()}");
                return;
            }

            GeoResult selectedCity;
            //Display selection form if more than 1 city was returned
            if (geoResults.Data.Count() > 1)
            {
                var selectionForm = new SelectionForm(geoResults.Data);
                selectionForm.ShowDialog();
                selectedCity = selectionForm.SelectedItem;
            }
            else
            {
                selectedCity = geoResults.Data.First();
            }

            //Request weather for selected city
            var weatherRequest = new RestRequest("data/2.5/weather", Method.Get);
            weatherRequest.AddQueryParameter("lat", selectedCity.Latitude);
            weatherRequest.AddQueryParameter("lon", selectedCity.Longitude);
            weatherRequest.AddQueryParameter("appid", _settings.ApiKey);
            weatherRequest.AddQueryParameter("units", "metric");

            var weatherResults = await client.ExecuteAsync<WeatherResult>(weatherRequest);

            //Validate weather results
            if (weatherResults.Data == null)
            {
                MessageBox.Show($"Could not get weather for {txtSearch.Text.Trim()}");
                return;
            }

            //Only write to history successful requests
            using StreamWriter file = new("history.txt", append: true);
            await file.WriteLineAsync(txtSearch.Text.Trim());

            //Add to history listbox
            lstHistory.Items.Insert(0,txtSearch.Text.Trim());
            grbHistory.Visible = true;

            //Display results
            lblLocation.Text = txtSearch.Text.Trim();
            lblTemperature.Text = weatherResults.Data.Main.Temperature.ToString("N0");
            lblCurrentWeather.Text = weatherResults.Data.Weather.First().Description.ToUpper();
            lblFeelsLike.Text = weatherResults.Data.Main.FeelsLike.ToString("N0");
            grbResults.Visible = true;
        }

        private void lstHistory_Click(object sender, EventArgs e)
        {
            //When clicked copy value from history to textbox
            if (lstHistory.SelectedItem != null)
            {
                txtSearch.Text = lstHistory.SelectedItem.ToString();
            }
        }
    }
}