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
    public partial class OptionsDialog : Form
    {
        public OptionsDialog()
        {
            InitializeComponent();
        }

        public void SetHeight(int number)
        {
            HeightUpDown.Value = number;
        }
        public int GetHeight()
        {
            return (int)HeightUpDown.Value;
        }

        public void SetWidth(int number)
        {
            WidthUpDown.Value = number;
        }
        public int GetWidth()
        {
            return (int)WidthUpDown.Value;
        }

        public void SetInt(int number)
        {
            intervalUpDown.Value = number;
        }

        public int GetInt()
        {
            return (int)intervalUpDown.Value;
        }
    }
}
