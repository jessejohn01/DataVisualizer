using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Data
    {

        public static List<double> time = new List<double>();
        public static List<double> Ax = new List<double>();
        public static List<double> Ay = new List<double>();
        public static List<double> Az = new List<double>();
        public static List<int> T = new List<int>();
        public static List<int> Gx = new List<int>();
        public static List<int> Gy = new List<int>();
        public static List<int> Gz = new List<int>();

        public static void printTime()
        {
            for(int i = 0; i < time.Count; i++)
            {
                Console.WriteLine(time[i]);
            }
        }

    }
}
