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
namespace er9PlotProgram
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

                loadDataFromFile(filename);
                
            }

        }

        private void loadDataFromFile(String inFile) // This function loads and parses the data from the CSV file. Uses the lists from the Data class.
        {
            try
            {
                using (var reader = new StreamReader(inFile))
                {


                    double tempDouble; // Dummy temp varibale
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        // This next section parses places all the data in seperate lists.
                        try
                        {

                            if (Double.TryParse(values[0], out tempDouble) == true)
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
                            if (Double.TryParse(values[4], out tempDouble) == true)
                            {
                                Data.T.Add((Convert.ToDouble(values[4])) / 340.0 + 35.0);
                            }
                            if (double.TryParse(values[5], out tempDouble) == true)
                            {
                                Data.Gx.Add((Convert.ToDouble(values[5])) / 16.4);
                            }
                            if (double.TryParse(values[6], out tempDouble) == true)
                            {
                                Data.Gy.Add((Convert.ToDouble(values[6])) / 16.4);
                            }
                            if (double.TryParse(values[7], out tempDouble) == true)
                            {
                                Data.Gz.Add((Convert.ToDouble(values[7])) / 16.4);
                            }

                        }
                        catch (Exception e)
                        {

                            MessageBox.Show("This file has the incorrect format.");
                            break;
                        }




                    }
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(Data.time[i]);
                    }


                    //Data.printTime(); 
                    List<double> timeScale = new List<double>();
                    for (int i = 0; i < Data.time.Count; i++)
                    {
                        timeScale.Add(((Data.time[i] - Data.time.Min()) / 1000) +.001 ); // This will make the time into seconds and bumps it up .001 so it is a nice even number.
                    }

                    // This sections loads the data into charts.
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

                    tempChart.Series["Temperature"].Points.DataBindXY(timeScale, Data.T);
                    tempChart.ChartAreas[0].RecalculateAxesScale();
                    tempChart.Update();

                }
            }catch(Exception e)
            {
                MessageBox.Show("An error occured reading the file. Is the file open in another program?"); // Just in case any reading errors happen.
            }
        }

        private void exportFile_Click(object sender, EventArgs e) //Save file function
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.RestoreDirectory = true;
                //save.FileName = "*.csv";
                save.DefaultExt = "csv";
                save.Filter = "csv files (*.csv) | *.csv";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = save.OpenFile();
                    StreamWriter writer = new StreamWriter(fileStream);
                    writer.Write("Time, Ax, Ay, Az, T, Gx, Gy, Gz,");
                    writer.WriteLine("");
                    for (int i = 0; i < Data.time.Count; i++)
                    {
                        writer.Write(UnixTimeStampToDateTime((long)Data.time[i]));
                        writer.Write(",");
                        writer.Write(Data.Ax[i]);
                        writer.Write(",");
                        writer.Write(Data.Ay[i]);
                        writer.Write(",");
                        writer.Write(Data.Az[i]);
                        writer.Write(",");
                        writer.Write(Data.T[i]);
                        writer.Write(",");
                        writer.Write(Data.Gx[i]);
                        writer.Write(",");
                        writer.Write(Data.Gy[i]);
                        writer.Write(",");
                        writer.Write(Data.Gz[i]);

                        if (i + 1 < Data.time.Count)
                        {
                            writer.Write(",");
                        }
                        writer.WriteLine("");


                    }


                    writer.Close();
                    fileStream.Close();
                    MessageBox.Show("File was saved.");

                }
            }catch(Exception ex)
            {
                MessageBox.Show("There was an error saving the file.");
                Console.WriteLine(ex);
            }
        }

        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp);
            return dtDateTime;
        }



    }
}
