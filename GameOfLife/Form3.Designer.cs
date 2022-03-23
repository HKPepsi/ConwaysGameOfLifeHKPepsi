
namespace GameOfLife
{
    partial class OptionsDialog
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.intervalUpDown = new System.Windows.Forms.NumericUpDown();
            this.WidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.HeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.ChangeHeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.intervalUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(110, 183);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(191, 183);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // intervalUpDown
            // 
            this.intervalUpDown.Location = new System.Drawing.Point(144, 116);
            this.intervalUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.intervalUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.intervalUpDown.Name = "intervalUpDown";
            this.intervalUpDown.Size = new System.Drawing.Size(152, 20);
            this.intervalUpDown.TabIndex = 2;
            this.intervalUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // WidthUpDown
            // 
            this.WidthUpDown.Location = new System.Drawing.Point(144, 90);
            this.WidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthUpDown.Name = "WidthUpDown";
            this.WidthUpDown.Size = new System.Drawing.Size(152, 20);
            this.WidthUpDown.TabIndex = 3;
            this.WidthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // HeightUpDown
            // 
            this.HeightUpDown.Location = new System.Drawing.Point(144, 64);
            this.HeightUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightUpDown.Name = "HeightUpDown";
            this.HeightUpDown.Size = new System.Drawing.Size(152, 20);
            this.HeightUpDown.TabIndex = 4;
            this.HeightUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ChangeHeight
            // 
            this.ChangeHeight.AutoSize = true;
            this.ChangeHeight.Location = new System.Drawing.Point(56, 69);
            this.ChangeHeight.Name = "ChangeHeight";
            this.ChangeHeight.Size = new System.Drawing.Size(78, 13);
            this.ChangeHeight.TabIndex = 5;
            this.ChangeHeight.Text = "Change Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Change Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Change Interval";
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 218);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChangeHeight);
            this.Controls.Add(this.HeightUpDown);
            this.Controls.Add(this.WidthUpDown);
            this.Controls.Add(this.intervalUpDown);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.intervalUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.NumericUpDown intervalUpDown;
        private System.Windows.Forms.NumericUpDown WidthUpDown;
        private System.Windows.Forms.NumericUpDown HeightUpDown;
        private System.Windows.Forms.Label ChangeHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}