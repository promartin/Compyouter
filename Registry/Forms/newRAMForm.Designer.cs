namespace Registry.Forms
{
    partial class newRAMForm
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
            this.manufacturerTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RAMGenerationComboBox1 = new System.Windows.Forms.ComboBox();
            this.sizeNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.frequencyNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.latencyNumericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.piecesNumericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.eccCheckBox = new System.Windows.Forms.CheckBox();
            this.rgbCheckBox = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.latencyNumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piecesNumericUpDown4)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(52, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 45);
            this.button1.TabIndex = 69;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // warrantyTimePicker
            // 
            this.warrantyTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.warrantyTimePicker.Location = new System.Drawing.Point(110, 138);
            this.warrantyTimePicker.Name = "warrantyTimePicker";
            this.warrantyTimePicker.Size = new System.Drawing.Size(100, 20);
            this.warrantyTimePicker.TabIndex = 68;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 224);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(428, 201);
            this.textBox.TabIndex = 67;
            // 
            // dateOfPurchaseTimePicker
            // 
            this.dateOfPurchaseTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfPurchaseTimePicker.Location = new System.Drawing.Point(110, 112);
            this.dateOfPurchaseTimePicker.Name = "dateOfPurchaseTimePicker";
            this.dateOfPurchaseTimePicker.Size = new System.Drawing.Size(100, 20);
            this.dateOfPurchaseTimePicker.TabIndex = 66;
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Location = new System.Drawing.Point(110, 85);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.serialNumberTextBox.TabIndex = 65;
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.Location = new System.Drawing.Point(110, 59);
            this.priceNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.priceNumericUpDown.TabIndex = 64;
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new System.Drawing.Point(110, 32);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.productNameTextBox.TabIndex = 63;
            // 
            // manufacturerTextBox
            // 
            this.manufacturerTextBox.Location = new System.Drawing.Point(110, 6);
            this.manufacturerTextBox.Name = "manufacturerTextBox";
            this.manufacturerTextBox.Size = new System.Drawing.Size(100, 20);
            this.manufacturerTextBox.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Warranty";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Text";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Date of purchase";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Serial number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Product\'s name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Manufacturer";
            // 
            // RAMGenerationComboBox1
            // 
            this.RAMGenerationComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RAMGenerationComboBox1.FormattingEnabled = true;
            this.RAMGenerationComboBox1.Location = new System.Drawing.Point(81, 17);
            this.RAMGenerationComboBox1.Name = "RAMGenerationComboBox1";
            this.RAMGenerationComboBox1.Size = new System.Drawing.Size(121, 21);
            this.RAMGenerationComboBox1.TabIndex = 70;
            // 
            // sizeNumericUpDown1
            // 
            this.sizeNumericUpDown1.Location = new System.Drawing.Point(82, 50);
            this.sizeNumericUpDown1.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.sizeNumericUpDown1.Name = "sizeNumericUpDown1";
            this.sizeNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.sizeNumericUpDown1.TabIndex = 71;
            // 
            // frequencyNumericUpDown2
            // 
            this.frequencyNumericUpDown2.Location = new System.Drawing.Point(82, 76);
            this.frequencyNumericUpDown2.Maximum = new decimal(new int[] {
            4600,
            0,
            0,
            0});
            this.frequencyNumericUpDown2.Minimum = new decimal(new int[] {
            266,
            0,
            0,
            0});
            this.frequencyNumericUpDown2.Name = "frequencyNumericUpDown2";
            this.frequencyNumericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.frequencyNumericUpDown2.TabIndex = 72;
            this.frequencyNumericUpDown2.Value = new decimal(new int[] {
            266,
            0,
            0,
            0});
            // 
            // latencyNumericUpDown3
            // 
            this.latencyNumericUpDown3.Location = new System.Drawing.Point(83, 102);
            this.latencyNumericUpDown3.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.latencyNumericUpDown3.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.latencyNumericUpDown3.Name = "latencyNumericUpDown3";
            this.latencyNumericUpDown3.Size = new System.Drawing.Size(120, 20);
            this.latencyNumericUpDown3.TabIndex = 73;
            this.latencyNumericUpDown3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // piecesNumericUpDown4
            // 
            this.piecesNumericUpDown4.Location = new System.Drawing.Point(82, 128);
            this.piecesNumericUpDown4.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.piecesNumericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.piecesNumericUpDown4.Name = "piecesNumericUpDown4";
            this.piecesNumericUpDown4.Size = new System.Drawing.Size(120, 20);
            this.piecesNumericUpDown4.TabIndex = 74;
            this.piecesNumericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // eccCheckBox
            // 
            this.eccCheckBox.AutoSize = true;
            this.eccCheckBox.Location = new System.Drawing.Point(94, 155);
            this.eccCheckBox.Name = "eccCheckBox";
            this.eccCheckBox.Size = new System.Drawing.Size(109, 17);
            this.eccCheckBox.TabIndex = 75;
            this.eccCheckBox.Text = "Does it has ECC?";
            this.eccCheckBox.UseVisualStyleBackColor = true;
            // 
            // rgbCheckBox
            // 
            this.rgbCheckBox.AutoSize = true;
            this.rgbCheckBox.Location = new System.Drawing.Point(94, 179);
            this.rgbCheckBox.Name = "rgbCheckBox";
            this.rgbCheckBox.Size = new System.Drawing.Size(74, 17);
            this.rgbCheckBox.TabIndex = 76;
            this.rgbCheckBox.Text = "Is it RGB?";
            this.rgbCheckBox.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(297, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 45);
            this.button2.TabIndex = 77;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 26);
            this.label7.TabIndex = 78;
            this.label7.Text = "RAM\r\ngeneration";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 79;
            this.label9.Text = "Size";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 80;
            this.label10.Text = "Frequency";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 81;
            this.label11.Text = "Latency";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 82;
            this.label12.Text = "Pieces";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RAMGenerationComboBox1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.sizeNumericUpDown1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.frequencyNumericUpDown2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.latencyNumericUpDown3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.piecesNumericUpDown4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.eccCheckBox);
            this.groupBox1.Controls.Add(this.rgbCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(216, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 206);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RAM";
            // 
            // newRAMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 539);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.warrantyTimePicker);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.dateOfPurchaseTimePicker);
            this.Controls.Add(this.serialNumberTextBox);
            this.Controls.Add(this.priceNumericUpDown);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(this.manufacturerTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "newRAMForm";
            this.ShowIcon = false;
            this.Text = "RAM";
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.latencyNumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piecesNumericUpDown4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox manufacturerTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RAMGenerationComboBox1;
        private System.Windows.Forms.NumericUpDown sizeNumericUpDown1;
        private System.Windows.Forms.NumericUpDown frequencyNumericUpDown2;
        private System.Windows.Forms.NumericUpDown latencyNumericUpDown3;
        private System.Windows.Forms.NumericUpDown piecesNumericUpDown4;
        private System.Windows.Forms.CheckBox eccCheckBox;
        private System.Windows.Forms.CheckBox rgbCheckBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}