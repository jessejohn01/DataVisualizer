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

        private void loadDataFromFile(String inFile)
        {
            using (var reader = new StreamReader(inFile))
            {
                List<double> time = new List<double>();
                List<int> Ax = new List<int>();
                List<int> Ay = new List<int>();
                List<int> Az = new List<int>();
                List<int> T = new List<int>();
                List<int> Gx = new List<int>();
                List<int> Gy = new List<int>();
                List<int> Gz = new List<int>();
                double tempDouble; // Dummy temp varibale
                int tempInt; // Dummy temp variable 
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    try {

                    if (Double.TryParse(values[0],out tempDouble) == true)
                    {
                        time.Add((Convert.ToDouble(values[0])));
                    }
                    if (int.TryParse(values[1], out tempInt) == true)
                    {
                        Ax.Add((Convert.ToInt32(values[1])));
                    }
                    if (int.TryParse(values[2], out tempInt) == true)
                    {
                        Ay.Add((Convert.ToInt32(values[2])));
                    }
                    if (int.TryParse(values[3], out tempInt) == true)
                    {
                        Az.Add((Convert.ToInt32(values[3])));
                    }
                    if (int.TryParse(values[4], out tempInt) == true)
                    {
                        T.Add((Convert.ToInt32(values[4])));
                    }
                    if (int.TryParse(values[5], out tempInt) == true)
                    {
                        Gx.Add((Convert.ToInt32(values[5])));
                    }
                    if (int.TryParse(values[6], out tempInt) == true)
                    {
                        Gy.Add((Convert.ToInt32(values[6])));
                    }
                    if (int.TryParse(values[7], out tempInt) == true)
                    {
                        Gz.Add((Convert.ToInt32(values[7])));
                    }

                    } catch (Exception e) {
                        
                        MessageBox.Show("This file has the incorrect format.");
                        break;
                    }




                }

            }
        }

        private void exportFile_Click(object sender, EventArgs e)
        {

        }


    }
}
