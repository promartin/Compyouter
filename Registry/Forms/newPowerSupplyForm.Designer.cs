namespace Registry.Forms
{
    partial class newPowerSupplyForm
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
            this.outputNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.efficencyComboBox1 = new System.Windows.Forms.ComboBox();
            this.formFactorComboBox2 = new System.Windows.Forms.ComboBox();
            this.sataNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pcieNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.molexNumericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sataNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcieNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.molexNumericUpDown3)).BeginInit();
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
            this.button1.TabIndex = 69;
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
            this.warrantyTimePicker.TabIndex = 68;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(46, 170);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(195, 252);
            this.textBox.TabIndex = 67;
            // 
            // dateOfPurchaseTimePicker
            // 
            this.dateOfPurchaseTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfPurchaseTimePicker.Location = new System.Drawing.Point(141, 112);
            this.dateOfPurchaseTimePicker.Name = "dateOfPurchaseTimePicker";
            this.dateOfPurchaseTimePicker.Size = new System.Drawing.Size(100, 20);
            this.dateOfPurchaseTimePicker.TabIndex = 66;
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Location = new System.Drawing.Point(141, 85);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.serialNumberTextBox.TabIndex = 65;
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
            this.priceNumericUpDown.TabIndex = 64;
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new System.Drawing.Point(141, 32);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.productNameTextBox.TabIndex = 63;
            // 
            // manufacturerTextBox
            // 
            this.manufacturerTextBox.Location = new System.Drawing.Point(141, 6);
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
            this.label6.Location = new System.Drawing.Point(12, 170);
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
            // outputNumericUpDown1
            // 
            this.outputNumericUpDown1.Location = new System.Drawing.Point(99, 19);
            this.outputNumericUpDown1.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.outputNumericUpDown1.Name = "outputNumericUpDown1";
            this.outputNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.outputNumericUpDown1.TabIndex = 70;
            // 
            // efficencyComboBox1
            // 
            this.efficencyComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.efficencyComboBox1.FormattingEnabled = true;
            this.efficencyComboBox1.Location = new System.Drawing.Point(99, 46);
            this.efficencyComboBox1.Name = "efficencyComboBox1";
            this.efficencyComboBox1.Size = new System.Drawing.Size(121, 21);
            this.efficencyComboBox1.TabIndex = 71;
            // 
            // formFactorComboBox2
            // 
            this.formFactorComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formFactorComboBox2.FormattingEnabled = true;
            this.formFactorComboBox2.Location = new System.Drawing.Point(99, 73);
            this.formFactorComboBox2.Name = "formFactorComboBox2";
            this.formFactorComboBox2.Size = new System.Drawing.Size(121, 21);
            this.formFactorComboBox2.TabIndex = 72;
            // 
            // sataNumericUpDown1
            // 
            this.sataNumericUpDown1.Location = new System.Drawing.Point(99, 101);
            this.sataNumericUpDown1.Name = "sataNumericUpDown1";
            this.sataNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.sataNumericUpDown1.TabIndex = 73;
            // 
            // pcieNumericUpDown2
            // 
            this.pcieNumericUpDown2.Location = new System.Drawing.Point(100, 127);
            this.pcieNumericUpDown2.Name = "pcieNumericUpDown2";
            this.pcieNumericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.pcieNumericUpDown2.TabIndex = 74;
            // 
            // molexNumericUpDown3
            // 
            this.molexNumericUpDown3.Location = new System.Drawing.Point(99, 153);
            this.molexNumericUpDown3.Name = "molexNumericUpDown3";
            this.molexNumericUpDown3.Size = new System.Drawing.Size(120, 20);
            this.molexNumericUpDown3.TabIndex = 75;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(72, 179);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 17);
            this.checkBox1.TabIndex = 76;
            this.checkBox1.Text = "Is it modular?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 77;
            this.label7.Text = "Output (W)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 78;
            this.label9.Text = "Efficency";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 79;
            this.label10.Text = "Form factor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 80;
            this.label11.Text = "SATA connectors";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 81;
            this.label12.Text = "PCIe connectors";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 82;
            this.label13.Text = "Molex connectors";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outputNumericUpDown1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.efficencyComboBox1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.formFactorComboBox2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.sataNumericUpDown1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.pcieNumericUpDown2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.molexNumericUpDown3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(247, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 203);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Power supply";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(319, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 45);
            this.button2.TabIndex = 84;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // newPowerSupplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 521);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
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
            this.Name = "newPowerSupplyForm";
            this.ShowIcon = false;
            this.Text = "newPowerSupplyForm";
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sataNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcieNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.molexNumericUpDown3)).EndInit();
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
        private System.Windows.Forms.NumericUpDown outputNumericUpDown1;
        private System.Windows.Forms.ComboBox efficencyComboBox1;
        private System.Windows.Forms.ComboBox formFactorComboBox2;
        private System.Windows.Forms.NumericUpDown sataNumericUpDown1;
        private System.Windows.Forms.NumericUpDown pcieNumericUpDown2;
        private System.Windows.Forms.NumericUpDown molexNumericUpDown3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
    }
}