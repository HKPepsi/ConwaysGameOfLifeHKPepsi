
namespace GameOfLife
{
    partial class SeedModalDialogue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SeedNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.Seed = new System.Windows.Forms.Label();
            this.RandomizeSeed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SeedNumberUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(106, 149);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(60, 20);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(181, 149);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(60, 20);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // SeedNumberUpDown
            // 
            this.SeedNumberUpDown.Location = new System.Drawing.Point(106, 82);
            this.SeedNumberUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.SeedNumberUpDown.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.SeedNumberUpDown.Name = "SeedNumberUpDown";
            this.SeedNumberUpDown.Size = new System.Drawing.Size(135, 20);
            this.SeedNumberUpDown.TabIndex = 2;
            this.SeedNumberUpDown.ValueChanged += new System.EventHandler(this.SeedNumberUpDown_ValueChanged);
            // 
            // Seed
            // 
            this.Seed.AutoSize = true;
            this.Seed.Location = new System.Drawing.Point(65, 84);
            this.Seed.Name = "Seed";
            this.Seed.Size = new System.Drawing.Size(32, 13);
            this.Seed.TabIndex = 3;
            this.Seed.Text = "Seed";
            this.Seed.Click += new System.EventHandler(this.Seed_Click);
            // 
            // RandomizeSeed
            // 
            this.RandomizeSeed.Location = new System.Drawing.Point(247, 80);
            this.RandomizeSeed.Name = "RandomizeSeed";
            this.RandomizeSeed.Size = new System.Drawing.Size(75, 23);
            this.RandomizeSeed.TabIndex = 4;
            this.RandomizeSeed.Text = "Randomize";
            this.RandomizeSeed.UseVisualStyleBackColor = true;
            this.RandomizeSeed.Click += new System.EventHandler(this.RandomizeSeed_Click);
            // 
            // SeedModalDialogue
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(355, 179);
            this.Controls.Add(this.RandomizeSeed);
            this.Controls.Add(this.Seed);
            this.Controls.Add(this.SeedNumberUpDown);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeedModalDialogue";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seed";
            ((System.ComponentModel.ISupportInitialize)(this.SeedNumberUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.NumericUpDown SeedNumberUpDown;
        private System.Windows.Forms.Label Seed;
        private System.Windows.Forms.Button RandomizeSeed;
    }
}