using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        // The universe array
        bool[,] universe = new bool[30, 30];
        bool[,] scratch = new bool[30, 30];
        
        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;
        
        // The Timer class
        Timer timer = new Timer();

        // Initializers
        int generations = 0;
        int rngSeed = 0;
        int fromSeed = 0;
        int aliveCount = 0;
        int universeHeight = 30;
        int universeWidth = 30;
        int interval = 20;
        //Bools
        bool isNeighborVisible = true;
        bool isGridVisible = true;
        //this broke in the last build, so i'm gonna have to make some major changes because i had to revert 3 versions ago to get this shit done.
        //I am BEYOND pissed, and i have 0 fucking clue as to what broke and why i have to crunch in so hard the day that this is due when it was working
        //yesterday.
        public Form1()
        {
            InitializeComponent();

            // Setup the timer

            //reads the properties
            //settings defaults:
            graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
            cellColor = Properties.Settings.Default.CellColor;
            gridColor = Properties.Settings.Default.GridColor;
            universeHeight = Properties.Settings.Default.CellHeight;
            universeWidth = Properties.Settings.Default.CellWidth;
            interval = Properties.Settings.Default.Interval;
            universe = new bool[universeWidth, universeHeight];
            scratch = new bool[universeWidth, universeHeight];

            timer.Interval = interval; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                //nested for loop, iterates through the area of the ting
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int neighbors = CountNeighborsFinite(x,y);
                    //int neighbors = CountNeighborsToroidal(x, y);
                    scratch[x, y] = false;

                    // Apply Rules of Nature
                    if (universe[x, y] == true && neighbors < 2)
                    {
                        scratch[x, y] = false;
                        aliveCount--;
                    }
                    if (universe[x, y] == true && neighbors > 3)
                    {
                        scratch[x, y] = false;
                        aliveCount--;
                    }
                    if (universe[x, y] == true && (neighbors == 2 || neighbors == 3))
                    {
                        scratch[x, y] = true;
                        
                    }
                    if (universe[x, y] == false && neighbors == 3)
                    {
                        scratch[x, y] = true;
                        aliveCount++;
                    }
                    
                    // Turn the cell on or off in scratch pad, 2nd 2d array.
                }
            }
            //copy from scratch 2 universe
            bool[,] temp = universe;
            universe = scratch;
            scratch = temp;

            // Increment generation count
            generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            AliveCountStatusLabel.Text = "Alive = " + aliveCount;
            //invalidate here for graphics pls thanks future me :)
            graphicsPanel1.Invalidate();
            //no problem past me, i gotchu fam.
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            isNeighborVisible = neighborCountToolStripMenuItem.Checked ? true : false;
            isGridVisible = gridToolStripMenuItem.Checked ? true : false;
            //To Do: Floats
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);
            
            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    //neighbor count:
                    int neighbors = CountNeighborsFinite(x, y);
                    //int neighbors = CountNeighborsToroidal(x, y);
                    // A rectangle to represent each cell in pixels
                    //RectangleF uses Floats.
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;
                    

                    

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                        if (isNeighborVisible)
                        {   //Neighbor count in cells
                            Font font = new Font("Arial", 20f);

                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Center;
                            stringFormat.LineAlignment = StringAlignment.Center;
                            e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Black, cellRect, stringFormat);
                        }
                    }




                    // Outline the cell with a pen
                    if (isGridVisible)
                    {
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    }
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];
                if (universe[x, y] == true)
                {
                    aliveCount++;
                }
                else
                {
                    aliveCount--;
                }
                AliveCountStatusLabel.Text = "Alive = " + aliveCount;
                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayStripButton1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            //Deprecated, turns out you can just call NextGeneration() so that whole Timer_tick2 stuff is useless, whoops.
            //timer.Tick -= Timer_Tick2;
        }

        private void PauseStripButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void NextStripButton1_Click(object sender, EventArgs e)
        {
            NextGeneration();
            
        }
        //Deprecated.
        //private void Timer_Tick2(object sender, EventArgs e)
        //{
        //    timer.Enabled = false;
        //}

        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;
                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }
                    // if xCheck is less than 0 then continue
                    if (xCheck < 0)
                    {
                        continue;
                    }
                    // if yCheck is less than 0 then continue
                    if (yCheck < 0)
                    {
                        continue;
                    }
                    // if xCheck is greater than or equal too xLen then continue
                    if (xCheck >= xLen)
                    {
                        continue;
                    }
                    // if yCheck is greater than or equal too yLen then continue
                    if (yCheck >= yLen)
                    {
                        continue;
                    }

                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }

        //i got to work once, then everything broke and now i don't remember what i did to fix it. the wording in the FSO page is weird and i'm mad.
        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;
                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }
                    // if xCheck is less than 0 then set to xLen - 1
                    if (xCheck < 0)
                    {
                        xLen--;
                    }
                    // if yCheck is less than 0 then set to yLen - 1
                    if (yCheck < 0)
                    {
                        yLen--;
                    }
                    // if xCheck is greater than or equal too xLen then set to 0
                    if (xCheck >= xLen)
                    {
                        xLen = 0;
                    }
                    // if yCheck is greater than or equal too yLen then set to 0
                    if (yCheck >= yLen)
                    {
                        yLen = 0;
                    }
                    //yeah.
                    if (universe[xCheck, yCheck] == true)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        //Toolstrip buttons
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    timer.Enabled = false;  
                    scratch[x, y] = false;
                    universe[x, y] = false;
                    toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
                }
            }
                    aliveCount = 0;
                    generations = 0;
                    AliveCountStatusLabel.Text = "Alive = " + generations.ToString();
                    SeedStatusLabel.Text = "Seed = " + rngSeed.ToString();
                    graphicsPanel1.Invalidate();
        }

        //Randomizers [Time]
        private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Seed Dialogue for future getting seeds.
            SeedModalDialogue dlg = new SeedModalDialogue();

            //Discovery: Do NOT initialize the random within the loop, it just makes every cell the same.
            Random randSeedTime = new Random();
            
            for (int x = 0; x <  universe.GetLength(1); x++)
            {
                for (int y = 0; y < universe.GetLength(0); y++)
                {
                    int seed = randSeedTime.Next(0, 2);
                    
                    if (seed == 0)
                    {
                        universe[x, y] = true;
                    }
                    else if (seed > 0)
                    {
                        universe[x, y] = false;
                    }
                }
            }
            fromSeed = randSeedTime.Next(-100000, 100000);
            SeedStatusLabel.Text = "Seed = " + fromSeed.ToString();
            graphicsPanel1.Invalidate();
        }
        //Deprecated, not a necessary function and i can visit it any time later to reimplement it if i really wanna

        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeedModalDialogue dlg = new SeedModalDialogue();
            Random seed = new Random(fromSeed);
            for (int x = 0; x < universe.GetLength(1); x++)
            {
                for (int y = 0; y < universe.GetLength(0); y++)
                {
                    int rng = seed.Next(0, 2);

                    if (rng == 0)
                    {
                        universe[x, y] = true;
                    }
                    else if (rng > 0)
                    {
                        universe[x, y] = false;
                    }
                }
            }
        }
        
        //SEEDED, WORKING AS NEEDED :D
        private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SeedModalDialogue dlg = new SeedModalDialogue();
            dlg.SetSeed(rngSeed);
            
            if (DialogResult.OK == dlg.ShowDialog())
            {
                //i tried something, didn't work. keeping it commented for future references if i wanna go back to it.
                //rngSeed = dlg.GetSeed();
                Random seed = new Random(rngSeed);
                dlg.SetSeed(rngSeed);
                for (int x = 0; x < universe.GetLength(1); x++)
                {
                    for (int y = 0; y < universe.GetLength(0); y++)
                    {
                        int rng = seed.Next(0, 2);

                        if (rng == 0)
                        {
                            universe[x, y] = true;
                        }
                        else if (rng > 0)
                        {
                            universe[x, y] = false;
                        }
                    }
                }
                fromSeed = dlg.GetSeed();
                SeedStatusLabel.Text = "Seed = " + fromSeed.ToString();
                graphicsPanel1.Invalidate();
            }
        }


        // Color Dialogue Boxes (using windows common Dialogs)
        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;
            
            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }

        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }

        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }
        //soonish, idk how to do bold x10  grids yet.
        private void gridX10ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ColorDialog dlg = new ColorDialog();

            //dlg.Color = graphicsPanel1.BackColor;
            
            //if (DialogResult.OK == dlg.ShowDialog())
            //{
            //    graphicsPanel1.BackColor = dlg.Color;
            //}
            //graphicsPanel1.Invalidate();
        }
        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OptionsDialog dlg = new OptionsDialog();

            dlg.SetInt(interval);
            dlg.SetHeight(universeHeight);
            dlg.SetWidth(universeWidth);
            if (DialogResult.OK == dlg.ShowDialog())
            {

                interval = dlg.GetInt();
                universeHeight = dlg.GetHeight();
                universeWidth = dlg.GetWidth();

                universe = new bool[universeWidth, universeHeight];
                scratch = new bool[universeWidth, universeHeight];
            }
            graphicsPanel1.Invalidate();
        }
        //RESETS TO DEFAULTS
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            //READS PROPERTIES
            graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
            cellColor = Properties.Settings.Default.CellColor;
            gridColor = Properties.Settings.Default.GridColor;
            interval = Properties.Settings.Default.Interval;
            universeHeight = Properties.Settings.Default.CellHeight;
            universeWidth = Properties.Settings.Default.CellWidth;
        }
        //RELOADS FROM LAST CACHED DATA
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            //READS PROPERTIES
            graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
            cellColor = Properties.Settings.Default.CellColor;
            gridColor = Properties.Settings.Default.GridColor;
            interval = Properties.Settings.Default.Interval;
            universeHeight = Properties.Settings.Default.CellHeight;
            universeWidth = Properties.Settings.Default.CellWidth;
        }

        private void toToolStripMenuItem_Click(object sender, EventArgs e)
        {
                ToDialog to = new ToDialog();
                to.SetGeneration(generations);
            if (DialogResult.OK == to.ShowDialog())
            {
                int skip = to.GetGeneration();
                if (generations >= 0 && generations < skip)
                {
                    //timer.Enabled = true;
                    for (int i = generations; i < skip; i++)
                    {
                        NextGeneration();
                    }
                    
                }
                graphicsPanel1.Invalidate();
            }
            //timer.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;
                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.
                    if (row.StartsWith("!"))
                    {
                        continue;
                    }

                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.
                    if (row.StartsWith("!") == false)
                    {
                        maxHeight++;
                    }

                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                    maxWidth = row.Length;
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.
                 universe = new bool[maxWidth, maxHeight];
                 scratch = new bool[maxWidth, maxHeight];
                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                // Iterate through the file again, this time reading in the cells.
                // For the Y for universe;
                int yPos = 0;
                while (!reader.EndOfStream)
                {
                    
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (row.StartsWith("!"))
                    {
                        continue;
                    }
                    // If the row is not a comment then 
                    // it is a row of cells and needs to be iterated through.
                    if (row.StartsWith("!") == false)
                    {

                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            // If row[xPos] is a 'O' (capital O) then
                            // set the corresponding cell in the universe to alive.
                            if (row[xPos] == 'O')
                            {
                                universe[xPos, yPos] = true;
                            }

                            // If row[xPos] is a '.' (period) then
                            // set the corresponding cell in the universe to dead.
                            if (row[xPos] == '.')
                            {
                                universe[xPos, yPos] = false;
                            }
                        }
                        yPos++;
                    }
                   
                }

                // Close the file.
                reader.Close();
            }

        }

        //Save works as intended, Comments and File Extension are good to go.
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.
                writer.WriteLine("!This is my comment.");
                writer.WriteLine("!Date: " + DateTime.Now);

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.
                        if (universe[x, y] == true)
                        {
                            currentRow += 'O';
                        }
                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        else if (universe[x, y] == false)
                        {
                            currentRow += '.';
                        }
                    }

                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.
                    writer.WriteLine(currentRow);
                }

                // After all rows and columns have been written then close the file.
                writer.Close();
            }
        }


        //when it closes, it saves all the stuff.
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Updates the properties.
            Properties.Settings.Default.BackgroundColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.GridColor = gridColor;
            Properties.Settings.Default.CellColor = cellColor;
            Properties.Settings.Default.CellWidth = universeWidth;
            Properties.Settings.Default.CellHeight = universeHeight;
            Properties.Settings.Default.Interval = interval;



             Properties.Settings.Default.Save();
        }

       

        
    }
}
