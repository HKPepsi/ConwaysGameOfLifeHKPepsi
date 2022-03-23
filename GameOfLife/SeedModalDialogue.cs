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
    public partial class SeedModalDialogue : Form
    {
        public SeedModalDialogue()
        {
            InitializeComponent();
        }

        public int GetSeed()
        {
            return (int)SeedNumberUpDown.Value;
        }

        public void SetSeed(int number)
        {
            SeedNumberUpDown.Value = number;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RandomizeSeed_Click(object sender, EventArgs e)
        {
            Random seed = new Random();
            SetSeed(seed.Next((int)SeedNumberUpDown.Minimum,(int)SeedNumberUpDown.Maximum));
        }

        private void Seed_Click(object sender, EventArgs e)
        {

        }

        private void SeedNumberUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
