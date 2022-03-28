using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeatherMaster.Models;

namespace WeatherMaster
{
    public partial class SelectionForm : Form
    {
        private readonly IEnumerable<GeoResult> _results;
        public GeoResult SelectedItem;

        public SelectionForm(IEnumerable<GeoResult> results)
        {
            _results = results;
            InitializeComponent();
        }

        private void SelectionForm_Load(object sender, EventArgs e)
        {
            lstOptions.DisplayMember = "Display";
            lstOptions.Items.Clear();

            foreach (var result in _results)
            {
                lstOptions.Items.Add(result);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lstOptions.SelectedItem == null)
            {
                MessageBox.Show("You need to select and item");
                return;
            }

            SelectedItem = lstOptions.SelectedItem as GeoResult;
            this.Close();
        }
    }
}
