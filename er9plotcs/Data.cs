using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace er9PlotProgram
{
    public class Data
    {

        public static List<double> time = new List<double>();
        public static List<double> Ax = new List<double>();
        public static List<double> Ay = new List<double>();
        public static List<double> Az = new List<double>();
        public static List<double> T = new List<double>();
        public static List<double> Gx = new List<double>();
        public static List<double> Gy = new List<double>();
        public static List<double> Gz = new List<double>();

        public static void printTime()
        {
            for(int i = 0; i < time.Count; i++)
            {
                Console.WriteLine(time[i]);
            }
        }

    }
}
