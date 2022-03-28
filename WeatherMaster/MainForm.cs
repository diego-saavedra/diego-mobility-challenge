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
            _settings = Program.Configuration.GetSection("AppSettings").Get<AppSettings>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("history.txt"))
            {
                foreach (string line in File.ReadLines(@"history.txt"))
                {
                    _history.Add(line);
                }
            }

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
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter a city to search");
                return;
            }

            var client = new RestClient("https://api.openweathermap.org");
            var geoRequest = new RestRequest("geo/1.0/direct", Method.Get);
            geoRequest.AddQueryParameter("q", txtSearch.Text.Trim());
            geoRequest.AddQueryParameter("limit", 5);
            geoRequest.AddQueryParameter("appid", _settings.ApiKey);

            var geoResults = await client.ExecuteAsync<IEnumerable<GeoResult>>(geoRequest);

            if (geoResults.Data == null || !geoResults.Data.Any())
            {
                MessageBox.Show($"Could not find city named {txtSearch.Text.Trim()}");
                return;
            }

            GeoResult selectedCity;

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

            var weatherRequest = new RestRequest("data/2.5/weather", Method.Get);
            weatherRequest.AddQueryParameter("lat", selectedCity.Latitude);
            weatherRequest.AddQueryParameter("lon", selectedCity.Longitude);
            weatherRequest.AddQueryParameter("appid", _settings.ApiKey);
            weatherRequest.AddQueryParameter("units", "metric");

            var weatherResults = await client.ExecuteAsync<WeatherResult>(weatherRequest);

            if (weatherResults.Data == null)
            {
                MessageBox.Show($"Could not get weather for {txtSearch.Text.Trim()}");
                return;
            }

            using StreamWriter file = new("history.txt", append: true);
            await file.WriteLineAsync(txtSearch.Text.Trim());

            lstHistory.Items.Insert(0,txtSearch.Text.Trim());
            grbHistory.Visible = true;

            lblLocation.Text = txtSearch.Text.Trim();
            lblTemperature.Text = weatherResults.Data.Main.Temperature.ToString();
            lblCurrentWeather.Text = weatherResults.Data.Weather.First().Description;
            lblFeelsLike.Text = weatherResults.Data.Main.FeelsLike.ToString();

            grbResults.Visible = true;
        }
    }
}