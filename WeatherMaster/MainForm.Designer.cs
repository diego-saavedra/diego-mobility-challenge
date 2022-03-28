namespace WeatherMaster
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.grbResults = new System.Windows.Forms.GroupBox();
            this.lblFeelsLike = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentWeather = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.grbHistory = new System.Windows.Forms.GroupBox();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.grbResults.SuspendLayout();
            this.grbHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(60, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(654, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(720, 5);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // grbResults
            // 
            this.grbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbResults.Controls.Add(this.lblFeelsLike);
            this.grbResults.Controls.Add(this.label4);
            this.grbResults.Controls.Add(this.lblTemperature);
            this.grbResults.Controls.Add(this.label2);
            this.grbResults.Controls.Add(this.lblCurrentWeather);
            this.grbResults.Controls.Add(this.lblLocation);
            this.grbResults.Location = new System.Drawing.Point(204, 35);
            this.grbResults.Name = "grbResults";
            this.grbResults.Size = new System.Drawing.Size(591, 341);
            this.grbResults.TabIndex = 3;
            this.grbResults.TabStop = false;
            this.grbResults.Text = "Result";
            this.grbResults.Visible = false;
            // 
            // lblFeelsLike
            // 
            this.lblFeelsLike.AutoSize = true;
            this.lblFeelsLike.Location = new System.Drawing.Point(72, 113);
            this.lblFeelsLike.Name = "lblFeelsLike";
            this.lblFeelsLike.Size = new System.Drawing.Size(13, 15);
            this.lblFeelsLike.TabIndex = 6;
            this.lblFeelsLike.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Feels Like:";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(131, 84);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(13, 15);
            this.lblTemperature.TabIndex = 3;
            this.lblTemperature.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Temperature:";
            // 
            // lblCurrentWeather
            // 
            this.lblCurrentWeather.AutoSize = true;
            this.lblCurrentWeather.Location = new System.Drawing.Point(6, 52);
            this.lblCurrentWeather.Name = "lblCurrentWeather";
            this.lblCurrentWeather.Size = new System.Drawing.Size(51, 15);
            this.lblCurrentWeather.TabIndex = 1;
            this.lblCurrentWeather.Text = "Weather";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(6, 22);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(53, 15);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location";
            // 
            // grbHistory
            // 
            this.grbHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbHistory.Controls.Add(this.lstHistory);
            this.grbHistory.Location = new System.Drawing.Point(12, 35);
            this.grbHistory.Name = "grbHistory";
            this.grbHistory.Size = new System.Drawing.Size(186, 341);
            this.grbHistory.TabIndex = 4;
            this.grbHistory.TabStop = false;
            this.grbHistory.Text = "History";
            this.grbHistory.Visible = false;
            // 
            // lstHistory
            // 
            this.lstHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 15;
            this.lstHistory.Location = new System.Drawing.Point(6, 22);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(174, 304);
            this.lstHistory.TabIndex = 0;
            this.lstHistory.Click += new System.EventHandler(this.lstHistory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 388);
            this.Controls.Add(this.grbHistory);
            this.Controls.Add(this.grbResults);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "WeatherMaster";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grbResults.ResumeLayout(false);
            this.grbResults.PerformLayout();
            this.grbHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.GroupBox grbResults;
        private System.Windows.Forms.GroupBox grbHistory;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Label lblFeelsLike;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentWeather;
        private System.Windows.Forms.Label lblLocation;
    }
}