using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OxyPlot;
using OxyPlot.Wpf;
namespace WindowsFormsApp1
{
    public partial class Er9plot : Form
    {
        public Er9plot()
        {
            InitializeComponent();
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFile = new OpenFileDialog();

            if (inputFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = inputFile.FileName;

                MessageBox.Show(filename);
                loadDataFromFile(filename);
                
            }

        }

        private void loadDataFromFile(String inFile) // This function loads and parses the data from the CSV file. Uses the lists from the Data class.
        {
            using (var reader = new StreamReader(inFile))
            {
                /*List<double> time = new List<double>();
                List<int> Ax = new List<int>();
                List<int> Ay = new List<int>();
                List<int> Az = new List<int>();
                List<int> T = new List<int>();
                List<int> Gx = new List<int>();
                List<int> Gy = new List<int>();
                List<int> Gz = new List<int>(); */
                
                double tempDouble; // Dummy temp varibale
                int tempInt; // Dummy temp variable 
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    try {

                    if (Double.TryParse(values[0],out tempDouble) == true)
                    {
                        Data.time.Add((Convert.ToDouble(values[0])));
                    }
                    if (Double.TryParse(values[1], out tempDouble) == true)
                    {
                        
                        Data.Ax.Add(((Convert.ToDouble(values[1]) / 2046.0)));
                    }
                    if (Double.TryParse(values[2], out tempDouble) == true)
                    {
                        Data.Ay.Add(((Convert.ToDouble(values[2]) / 2046.0)));
                    }
                    if (Double.TryParse(values[3], out tempDouble) == true)
                    {
                        Data.Az.Add(((Convert.ToDouble(values[3]) / 2046.0)));
                    }
                    if (int.TryParse(values[4], out tempInt) == true)
                    {
                        Data.T.Add((Convert.ToInt32(values[4])));
                    }
                    if (int.TryParse(values[5], out tempInt) == true)
                    {
                        Data.Gx.Add((Convert.ToInt32(values[5])));
                    }
                    if (int.TryParse(values[6], out tempInt) == true)
                    {
                        Data.Gy.Add((Convert.ToInt32(values[6])));
                    }
                    if (int.TryParse(values[7], out tempInt) == true)
                    {
                        Data.Gz.Add((Convert.ToInt32(values[7])));
                    }

                    } catch (Exception e) {
                        
                        MessageBox.Show("This file has the incorrect format.");
                        break;
                    }




                }
                for(int i = 0; i< 10; i++)
                {
                    Console.WriteLine(Data.time[i]);
                }


                //Data.printTime(); 
                List<double> timeScale = new List<double>();
                for (int i = 0; i < Data.time.Count; i++)
                {
                      timeScale.Add((Data.time[i] - Data.time.Min()) /100);
                }
                accelChart.Series["Ax"].Points.DataBindXY(timeScale, Data.Ax);
                accelChart.Series["Ay"].Points.DataBindXY(timeScale, Data.Ay);
                accelChart.Series["Az"].Points.DataBindXY(timeScale, Data.Az);
                accelChart.ChartAreas[0].RecalculateAxesScale();
                accelChart.Update();

                gyroChart.Series["Gx"].Points.DataBindXY(timeScale, Data.Gx);
                gyroChart.Series["Gy"].Points.DataBindXY(timeScale, Data.Gy);
                gyroChart.Series["Gz"].Points.DataBindXY(timeScale, Data.Gz);
                gyroChart.ChartAreas[0].RecalculateAxesScale();
                gyroChart.Update();

            }
        }

        private void exportFile_Click(object sender, EventArgs e)
        {

        }


    }
}
