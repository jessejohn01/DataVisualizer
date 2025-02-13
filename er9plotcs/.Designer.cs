﻿namespace er9PlotProgram
{
    partial class Er9plot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Acceleration = new System.Windows.Forms.TabPage();
            this.accelChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Gyro = new System.Windows.Forms.TabPage();
            this.gyroChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileDropdown = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Temperature = new System.Windows.Forms.TabPage();
            this.tempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.Acceleration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accelChart)).BeginInit();
            this.Gyro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gyroChart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.Temperature.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Acceleration);
            this.tabControl1.Controls.Add(this.Gyro);
            this.tabControl1.Controls.Add(this.Temperature);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 411);
            this.tabControl1.TabIndex = 0;
            // 
            // Acceleration
            // 
            this.Acceleration.Controls.Add(this.accelChart);
            this.Acceleration.Location = new System.Drawing.Point(4, 22);
            this.Acceleration.Name = "Acceleration";
            this.Acceleration.Padding = new System.Windows.Forms.Padding(3);
            this.Acceleration.Size = new System.Drawing.Size(768, 385);
            this.Acceleration.TabIndex = 0;
            this.Acceleration.Text = "Acceleration Graph";
            this.Acceleration.UseVisualStyleBackColor = true;
            // 
            // accelChart
            // 
            chartArea1.AxisX.Title = "Time in Seconds";
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.Title = "Gs";
            chartArea1.Name = "ChartArea1";
            this.accelChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.accelChart.Legends.Add(legend1);
            this.accelChart.Location = new System.Drawing.Point(0, 0);
            this.accelChart.Name = "accelChart";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series1.Legend = "Legend1";
            series1.Name = "Ax";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Ay";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Blue;
            series3.Legend = "Legend1";
            series3.Name = "Az";
            this.accelChart.Series.Add(series1);
            this.accelChart.Series.Add(series2);
            this.accelChart.Series.Add(series3);
            this.accelChart.Size = new System.Drawing.Size(768, 388);
            this.accelChart.TabIndex = 0;
            this.accelChart.Text = "Acceleration Chart";
            // 
            // Gyro
            // 
            this.Gyro.Controls.Add(this.gyroChart);
            this.Gyro.Location = new System.Drawing.Point(4, 22);
            this.Gyro.Name = "Gyro";
            this.Gyro.Padding = new System.Windows.Forms.Padding(3);
            this.Gyro.Size = new System.Drawing.Size(768, 385);
            this.Gyro.TabIndex = 1;
            this.Gyro.Text = "Angular Velocity Graph";
            this.Gyro.UseVisualStyleBackColor = true;
            // 
            // gyroChart
            // 
            chartArea2.AxisX.Title = "Time in Seconds";
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.Title = "Deg / Sec";
            chartArea2.Name = "ChartArea1";
            this.gyroChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.gyroChart.Legends.Add(legend2);
            this.gyroChart.Location = new System.Drawing.Point(-4, 0);
            this.gyroChart.Name = "gyroChart";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Aqua;
            series4.Legend = "Legend1";
            series4.Name = "Gx";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Yellow;
            series5.Legend = "Legend1";
            series5.Name = "Gy";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Green;
            series6.Legend = "Legend1";
            series6.Name = "Gz";
            this.gyroChart.Series.Add(series4);
            this.gyroChart.Series.Add(series5);
            this.gyroChart.Series.Add(series6);
            this.gyroChart.Size = new System.Drawing.Size(772, 388);
            this.gyroChart.TabIndex = 0;
            this.gyroChart.Text = "GyroChart";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileDropdown});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // FileDropdown
            // 
            this.FileDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.exportFile});
            this.FileDropdown.Name = "FileDropdown";
            this.FileDropdown.Size = new System.Drawing.Size(37, 20);
            this.FileDropdown.Text = "File";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(128, 22);
            this.openFile.Text = "Open File";
            this.openFile.ToolTipText = "Open a CSV file to visualize the data.";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // exportFile
            // 
            this.exportFile.Name = "exportFile";
            this.exportFile.Size = new System.Drawing.Size(128, 22);
            this.exportFile.Text = "Export File";
            this.exportFile.ToolTipText = "Export a copy of the loaded data.";
            this.exportFile.Click += new System.EventHandler(this.exportFile_Click);
            // 
            // Temperature
            // 
            this.Temperature.Controls.Add(this.tempChart);
            this.Temperature.Location = new System.Drawing.Point(4, 22);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(768, 385);
            this.Temperature.TabIndex = 2;
            this.Temperature.Text = "Temperature Graph";
            this.Temperature.UseVisualStyleBackColor = true;
            // 
            // tempChart
            // 
            chartArea3.AxisX.Title = "Time in Seconds";
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.Title = "°C";
            chartArea3.Name = "ChartArea1";
            this.tempChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.tempChart.Legends.Add(legend3);
            this.tempChart.Location = new System.Drawing.Point(4, 0);
            this.tempChart.Name = "tempChart";
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.Red;
            series7.Legend = "Legend1";
            series7.Name = "Temperature";
            this.tempChart.Series.Add(series7);
            this.tempChart.Size = new System.Drawing.Size(764, 381);
            this.tempChart.TabIndex = 0;
            this.tempChart.Text = "TemperatureGraph";
            // 
            // Er9plot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Er9plot";
            this.Text = "er9plot";
            this.tabControl1.ResumeLayout(false);
            this.Acceleration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accelChart)).EndInit();
            this.Gyro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gyroChart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Temperature.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Acceleration;
        private System.Windows.Forms.TabPage Gyro;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileDropdown;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem exportFile;
        private System.Windows.Forms.DataVisualization.Charting.Chart accelChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart gyroChart;
        private System.Windows.Forms.TabPage Temperature;
        private System.Windows.Forms.DataVisualization.Charting.Chart tempChart;
    }
}

