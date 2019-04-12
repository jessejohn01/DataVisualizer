using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            openFileDialog1_FileOk(sender);
        }

        private void openFileDialog1_FileOk(object sender)
        {
            throw new NotImplementedException();
        }

        private void exportFile_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
