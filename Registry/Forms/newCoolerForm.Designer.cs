namespace Registry.Forms
{
    partial class newCoolerForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.warrantyTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBox = new System.Windows.Forms.TextBox();
            this.dateOfPurchaseTimePicker = new System.Windows.Forms.DateTimePicker();
            this.serialNumberTextBox = new System.Windows.Forms.TextBox();
            this.priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.maufacturerTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(46, 451);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 45);
            this.button1.TabIndex = 54;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // warrantyTimePicker
            // 
            this.warrantyTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.warrantyTimePicker.Location = new System.Drawing.Point(141, 138);
            this.warrantyTimePicker.Name = "warrantyTimePicker";
            this.warrantyTimePicker.Size = new System.Drawing.Size(100, 20);
            this.warrantyTimePicker.TabIndex = 53;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(46, 170);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(195, 252);
            this.textBox.TabIndex = 52;
            // 
            // dateOfPurchaseTimePicker
            // 
            this.dateOfPurchaseTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfPurchaseTimePicker.Location = new System.Drawing.Point(141, 112);
            this.dateOfPurchaseTimePicker.Name = "dateOfPurchaseTimePicker";
            this.dateOfPurchaseTimePicker.Size = new System.Drawing.Size(100, 20);
            this.dateOfPurchaseTimePicker.TabIndex = 51;
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Location = new System.Drawing.Point(141, 85);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.serialNumberTextBox.TabIndex = 50;
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.Location = new System.Drawing.Point(141, 59);
            this.priceNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.priceNumericUpDown.TabIndex = 49;
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new System.Drawing.Point(141, 32);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.productNameTextBox.TabIndex = 48;
            // 
            // maufacturerTextBox
            // 
            this.maufacturerTextBox.Location = new System.Drawing.Point(141, 6);
            this.maufacturerTextBox.Name = "maufacturerTextBox";
            this.maufacturerTextBox.Size = new System.Drawing.Size(100, 20);
            this.maufacturerTextBox.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Warranty";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Text";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Date of purchase";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Serial number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Product\'s name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Manufacturer";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 55;
            this.checkBox1.Text = "LGA115x";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 50);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(71, 17);
            this.checkBox2.TabIndex = 56;
            this.checkBox2.Text = "LGA2066";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 73);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(71, 17);
            this.checkBox3.TabIndex = 57;
            this.checkBox3.Text = "LGA2011";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(88, 28);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(71, 17);
            this.checkBox4.TabIndex = 58;
            this.checkBox4.Text = "LGA1366";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(88, 51);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(65, 17);
            this.checkBox5.TabIndex = 59;
            this.checkBox5.Text = "LGA775";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(6, 19);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(46, 17);
            this.checkBox6.TabIndex = 60;
            this.checkBox6.Text = "FMx";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(6, 42);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(47, 17);
            this.checkBox7.TabIndex = 61;
            this.checkBox7.Text = "AMx";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(58, 19);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(48, 17);
            this.checkBox8.TabIndex = 62;
            this.checkBox8.Text = "AM4";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(58, 42);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(47, 17);
            this.checkBox9.TabIndex = 63;
            this.checkBox9.Text = "TR4";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Location = new System.Drawing.Point(247, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 104);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intel";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Controls.Add(this.checkBox7);
            this.groupBox2.Controls.Add(this.checkBox9);
            this.groupBox2.Controls.Add(this.checkBox8);
            this.groupBox2.Location = new System.Drawing.Point(247, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 79);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AMD";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(253, 353);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(70, 20);
            this.numericUpDown1.TabIndex = 66;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Cooler\'s height (mm)";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(285, 451);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 45);
            this.button2.TabIndex = 68;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 39);
            this.label9.TabIndex = 69;
            this.label9.Text = "Check those \r\nstockings which are\r\nsupported by the cooler";
            // 
            // newCoolerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 508);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.warrantyTimePicker);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.dateOfPurchaseTimePicker);
            this.Controls.Add(this.serialNumberTextBox);
            this.Controls.Add(this.priceNumericUpDown);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(this.maufacturerTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "newCoolerForm";
            this.ShowIcon = false;
            this.Text = "Cooler";
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker warrantyTimePicker;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.DateTimePicker dateOfPurchaseTimePicker;
        private System.Windows.Forms.TextBox serialNumberTextBox;
        private System.Windows.Forms.NumericUpDown priceNumericUpDown;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.TextBox maufacturerTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
    }
}