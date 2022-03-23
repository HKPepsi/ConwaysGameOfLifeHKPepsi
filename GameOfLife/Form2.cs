using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class ToDialog : Form
    {
        public ToDialog()
        {
            InitializeComponent();
        }

        public int GetGeneration()
        {
            return (int)ToNumericUpDown.Value;
        }
        public void SetGeneration(int number)
        {
            ToNumericUpDown.Value = number;
            
        }

        private void ToLabel_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
