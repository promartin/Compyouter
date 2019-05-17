namespace Registry.Forms
{
    partial class newVideoCardForm
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
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.manufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.productsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(56, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 45);
            this.button1.TabIndex = 67;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // warrantyTimePicker
            // 
            this.warrantyTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.warrantyTimePicker.Location = new System.Drawing.Point(144, 145);
            this.warrantyTimePicker.Name = "warrantyTimePicker";
            this.warrantyTimePicker.Size = new System.Drawing.Size(100, 20);
            this.warrantyTimePicker.TabIndex = 66;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(16, 193);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(388, 120);
            this.textBox.TabIndex = 65;
            // 
            // dateOfPurchaseTimePicker
            // 
            this.dateOfPurchaseTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfPurchaseTimePicker.Location = new System.Drawing.Point(144, 119);
            this.dateOfPurchaseTimePicker.Name = "dateOfPurchaseTimePicker";
            this.dateOfPurchaseTimePicker.Size = new System.Drawing.Size(100, 20);
            this.dateOfPurchaseTimePicker.TabIndex = 64;
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Location = new System.Drawing.Point(144, 92);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.serialNumberTextBox.TabIndex = 63;
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.Location = new System.Drawing.Point(144, 66);
            this.priceNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.priceNumericUpDown.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Warranty";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Text";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Date of purchase";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Serial number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Product\'s name";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 3;
            this.numericUpDown1.Location = new System.Drawing.Point(102, 22);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            196608});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown1.TabIndex = 68;
            this.numericUpDown1.Value = new decimal(new int[] {
            128,
            0,
            0,
            196608});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(102, 100);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown2.TabIndex = 69;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(102, 48);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            403,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            69,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown3.TabIndex = 70;
            this.numericUpDown3.Value = new decimal(new int[] {
            69,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(102, 74);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown4.TabIndex = 71;
            this.numericUpDown4.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 21);
            this.comboBox1.TabIndex = 72;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown4);
            this.groupBox1.Location = new System.Drawing.Point(250, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 181);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video card";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 74;
            this.label11.Text = "Design";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 77;
            this.label10.Text = "TDP (W)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 26);
            this.label9.TabIndex = 76;
            this.label9.Text = "Video card length\r\n(mm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 26);
            this.label7.TabIndex = 75;
            this.label7.Text = "PCIe Connectors\r\nneeded";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Size (GB)";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(240, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 45);
            this.button2.TabIndex = 74;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // manufacturerComboBox
            // 
            this.manufacturerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manufacturerComboBox.FormattingEnabled = true;
            this.manufacturerComboBox.Location = new System.Drawing.Point(144, 12);
            this.manufacturerComboBox.Name = "manufacturerComboBox";
            this.manufacturerComboBox.Size = new System.Drawing.Size(100, 21);
            this.manufacturerComboBox.TabIndex = 78;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "Manufacturer";
            // 
            // productsTextBox
            // 
            this.productsTextBox.Location = new System.Drawing.Point(144, 39);
            this.productsTextBox.Name = "productsTextBox";
            this.productsTextBox.Size = new System.Drawing.Size(100, 20);
            this.productsTextBox.TabIndex = 80;
            // 
            // newVideoCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 378);
            this.Controls.Add(this.productsTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.manufacturerComboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.warrantyTimePicker);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.dateOfPurchaseTimePicker);
            this.Controls.Add(this.serialNumberTextBox);
            this.Controls.Add(this.priceNumericUpDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "newVideoCardForm";
            this.ShowIcon = false;
            this.Text = "Video card";
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox manufacturerComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox productsTextBox;
    }
}