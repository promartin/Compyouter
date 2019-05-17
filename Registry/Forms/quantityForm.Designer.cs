namespace Registry.Forms
{
    partial class quantityForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(3, 1);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(74, 18);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Title here";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Registry.Properties.Resources.question_100px;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(9, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // questionTextBox
            // 
            this.questionTextBox.BackColor = System.Drawing.Color.White;
            this.questionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.questionTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.questionTextBox.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.questionTextBox.Location = new System.Drawing.Point(130, 30);
            this.questionTextBox.Multiline = true;
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.Size = new System.Drawing.Size(258, 49);
            this.questionTextBox.TabIndex = 4;
            this.questionTextBox.Text = "Question here";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Century Gothic", 9.25F, System.Drawing.FontStyle.Bold);
            this.okButton.Location = new System.Drawing.Point(130, 111);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 32);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Century Gothic", 9.25F, System.Drawing.FontStyle.Bold);
            this.cancelButton.Location = new System.Drawing.Point(313, 111);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 32);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.quantityNumericUpDown.Location = new System.Drawing.Point(226, 85);
            this.quantityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(63, 25);
            this.quantityNumericUpDown.TabIndex = 1;
            this.quantityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(145)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 24);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Image = global::Registry.Properties.Resources.close_cross;
            this.exitButton.Location = new System.Drawing.Point(375, 1);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(23, 23);
            this.exitButton.TabIndex = 23;
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(154)))), ((int)(((byte)(93)))));
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 10);
            this.panel2.TabIndex = 7;
            // 
            // quantityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 160);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.quantityNumericUpDown);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "quantityForm";
            this.ShowIcon = false;
            this.Text = "quantityForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button exitButton;
    }
}