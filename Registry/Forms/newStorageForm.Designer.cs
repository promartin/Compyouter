namespace Registry.Forms
{
    partial class newStorageForm
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
            this.typeComboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.storageSizenumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.connectorComboBox2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.conditionNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.sizeComboBox3 = new System.Windows.Forms.ComboBox();
            this.ssdGroupBox = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.technologyComboBox = new System.Windows.Forms.ComboBox();
            this.readSpeedNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.writeSpeedNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.hddGroupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cacheNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.rpmNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageSizenumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionNumericUpDown2)).BeginInit();
            this.ssdGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.readSpeedNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeSpeedNumericUpDown1)).BeginInit();
            this.hddGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cacheNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpmNumericUpDown2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(103, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 45);
            this.button1.TabIndex = 84;
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
            this.warrantyTimePicker.TabIndex = 83;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(46, 170);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(195, 252);
            this.textBox.TabIndex = 82;
            // 
            // dateOfPurchaseTimePicker
            // 
            this.dateOfPurchaseTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfPurchaseTimePicker.Location = new System.Drawing.Point(141, 112);
            this.dateOfPurchaseTimePicker.Name = "dateOfPurchaseTimePicker";
            this.dateOfPurchaseTimePicker.Size = new System.Drawing.Size(100, 20);
            this.dateOfPurchaseTimePicker.TabIndex = 81;
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Location = new System.Drawing.Point(141, 85);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.serialNumberTextBox.TabIndex = 80;
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
            this.priceNumericUpDown.TabIndex = 79;
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new System.Drawing.Point(141, 32);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.productNameTextBox.TabIndex = 78;
            // 
            // manufacturerTextBox
            // 
            this.manufacturerTextBox.Location = new System.Drawing.Point(141, 6);
            this.manufacturerTextBox.Name = "manufacturerTextBox";
            this.manufacturerTextBox.Size = new System.Drawing.Size(100, 20);
            this.manufacturerTextBox.TabIndex = 77;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 76;
            this.label8.Text = "Warranty";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 75;
            this.label6.Text = "Text";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Date of purchase";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Serial number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Product\'s name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Manufacturer";
            // 
            // typeComboBox1
            // 
            this.typeComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox1.FormattingEnabled = true;
            this.typeComboBox1.Location = new System.Drawing.Point(105, 153);
            this.typeComboBox1.Name = "typeComboBox1";
            this.typeComboBox1.Size = new System.Drawing.Size(121, 21);
            this.typeComboBox1.TabIndex = 85;
            this.typeComboBox1.SelectedIndexChanged += new System.EventHandler(this.typeComboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Type";
            // 
            // storageSizenumericUpDown1
            // 
            this.storageSizenumericUpDown1.Location = new System.Drawing.Point(105, 22);
            this.storageSizenumericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.storageSizenumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.storageSizenumericUpDown1.Name = "storageSizenumericUpDown1";
            this.storageSizenumericUpDown1.Size = new System.Drawing.Size(57, 20);
            this.storageSizenumericUpDown1.TabIndex = 87;
            this.storageSizenumericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 88;
            this.label9.Text = "Storage size";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 26);
            this.label10.TabIndex = 91;
            this.label10.Text = "Connector\r\ntype";
            // 
            // connectorComboBox2
            // 
            this.connectorComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connectorComboBox2.FormattingEnabled = true;
            this.connectorComboBox2.Location = new System.Drawing.Point(105, 68);
            this.connectorComboBox2.Name = "connectorComboBox2";
            this.connectorComboBox2.Size = new System.Drawing.Size(121, 21);
            this.connectorComboBox2.TabIndex = 90;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 93;
            this.label11.Text = "Condition";
            // 
            // conditionNumericUpDown2
            // 
            this.conditionNumericUpDown2.Location = new System.Drawing.Point(105, 100);
            this.conditionNumericUpDown2.Name = "conditionNumericUpDown2";
            this.conditionNumericUpDown2.Size = new System.Drawing.Size(57, 20);
            this.conditionNumericUpDown2.TabIndex = 92;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 95;
            this.label12.Text = "Size";
            // 
            // sizeComboBox3
            // 
            this.sizeComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeComboBox3.FormattingEnabled = true;
            this.sizeComboBox3.Location = new System.Drawing.Point(105, 125);
            this.sizeComboBox3.Name = "sizeComboBox3";
            this.sizeComboBox3.Size = new System.Drawing.Size(121, 21);
            this.sizeComboBox3.TabIndex = 94;
            // 
            // ssdGroupBox
            // 
            this.ssdGroupBox.Controls.Add(this.label15);
            this.ssdGroupBox.Controls.Add(this.label14);
            this.ssdGroupBox.Controls.Add(this.technologyComboBox);
            this.ssdGroupBox.Controls.Add(this.readSpeedNumericUpDown2);
            this.ssdGroupBox.Controls.Add(this.label13);
            this.ssdGroupBox.Controls.Add(this.writeSpeedNumericUpDown1);
            this.ssdGroupBox.Location = new System.Drawing.Point(247, 204);
            this.ssdGroupBox.Name = "ssdGroupBox";
            this.ssdGroupBox.Size = new System.Drawing.Size(215, 108);
            this.ssdGroupBox.TabIndex = 96;
            this.ssdGroupBox.TabStop = false;
            this.ssdGroupBox.Text = "SSD";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 98;
            this.label15.Text = "Technology";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 100;
            this.label14.Text = "Read speed";
            // 
            // technologyComboBox
            // 
            this.technologyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.technologyComboBox.FormattingEnabled = true;
            this.technologyComboBox.Location = new System.Drawing.Point(89, 72);
            this.technologyComboBox.Name = "technologyComboBox";
            this.technologyComboBox.Size = new System.Drawing.Size(121, 21);
            this.technologyComboBox.TabIndex = 97;
            // 
            // readSpeedNumericUpDown2
            // 
            this.readSpeedNumericUpDown2.Location = new System.Drawing.Point(90, 46);
            this.readSpeedNumericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.readSpeedNumericUpDown2.Name = "readSpeedNumericUpDown2";
            this.readSpeedNumericUpDown2.Size = new System.Drawing.Size(57, 20);
            this.readSpeedNumericUpDown2.TabIndex = 99;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 98;
            this.label13.Text = "Write speed";
            // 
            // writeSpeedNumericUpDown1
            // 
            this.writeSpeedNumericUpDown1.Location = new System.Drawing.Point(90, 20);
            this.writeSpeedNumericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.writeSpeedNumericUpDown1.Name = "writeSpeedNumericUpDown1";
            this.writeSpeedNumericUpDown1.Size = new System.Drawing.Size(57, 20);
            this.writeSpeedNumericUpDown1.TabIndex = 97;
            // 
            // hddGroupBox1
            // 
            this.hddGroupBox1.Controls.Add(this.label17);
            this.hddGroupBox1.Controls.Add(this.cacheNumericUpDown1);
            this.hddGroupBox1.Controls.Add(this.label18);
            this.hddGroupBox1.Controls.Add(this.rpmNumericUpDown2);
            this.hddGroupBox1.Location = new System.Drawing.Point(247, 204);
            this.hddGroupBox1.Name = "hddGroupBox1";
            this.hddGroupBox1.Size = new System.Drawing.Size(109, 77);
            this.hddGroupBox1.TabIndex = 101;
            this.hddGroupBox1.TabStop = false;
            this.hddGroupBox1.Text = "HDD";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 100;
            this.label17.Text = "Cache";
            // 
            // cacheNumericUpDown1
            // 
            this.cacheNumericUpDown1.Location = new System.Drawing.Point(43, 46);
            this.cacheNumericUpDown1.Name = "cacheNumericUpDown1";
            this.cacheNumericUpDown1.Size = new System.Drawing.Size(57, 20);
            this.cacheNumericUpDown1.TabIndex = 99;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 98;
            this.label18.Text = "RPM";
            // 
            // rpmNumericUpDown2
            // 
            this.rpmNumericUpDown2.Location = new System.Drawing.Point(43, 20);
            this.rpmNumericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rpmNumericUpDown2.Name = "rpmNumericUpDown2";
            this.rpmNumericUpDown2.Size = new System.Drawing.Size(57, 20);
            this.rpmNumericUpDown2.TabIndex = 97;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.typeComboBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.storageSizenumericUpDown1);
            this.groupBox1.Controls.Add(this.sizeComboBox3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.connectorComboBox2);
            this.groupBox1.Controls.Add(this.conditionNumericUpDown2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(247, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 186);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Storage";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(290, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 45);
            this.button2.TabIndex = 103;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // newStorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 510);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hddGroupBox1);
            this.Controls.Add(this.ssdGroupBox);
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
            this.Name = "newStorageForm";
            this.ShowIcon = false;
            this.Text = "Storage";
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageSizenumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionNumericUpDown2)).EndInit();
            this.ssdGroupBox.ResumeLayout(false);
            this.ssdGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.readSpeedNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeSpeedNumericUpDown1)).EndInit();
            this.hddGroupBox1.ResumeLayout(false);
            this.hddGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cacheNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpmNumericUpDown2)).EndInit();
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
        private System.Windows.Forms.ComboBox typeComboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown storageSizenumericUpDown1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox connectorComboBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown conditionNumericUpDown2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox sizeComboBox3;
        private System.Windows.Forms.GroupBox ssdGroupBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown writeSpeedNumericUpDown1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown readSpeedNumericUpDown2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox technologyComboBox;
        private System.Windows.Forms.GroupBox hddGroupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown cacheNumericUpDown1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown rpmNumericUpDown2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
    }
}