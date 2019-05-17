using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registry.Classes.Components;
using Registry.Classes.Components.RAM;

namespace Registry.Forms
{
    public partial class newRAMForm : Form
    {
        internal static Components newComponent;
        public static Components NewComponent
        {
            get => newComponent;
            set => newComponent = value;
        }

        public newRAMForm()
        {
            InitializeComponent();
            RAMGenerationComboBox1.DataSource = Enum.GetValues(typeof(RAMGeneration));
        }

        public newRAMForm(Components modification)
        {
            InitializeComponent();
            RAMGenerationComboBox1.DataSource = Enum.GetValues(typeof(RAMGeneration));
            newComponent = modification;

            manufacturerTextBox.Text = newComponent.Manufacturer;
            productNameTextBox.Text = newComponent.ProductsName;
            serialNumberTextBox.Text = newComponent.SerialNumber;
            priceNumericUpDown.Value = newComponent.Price;
            serialNumberTextBox.Text = newComponent.SerialNumber;
            dateOfPurchaseTimePicker.Value = newComponent.DateOfPurchase;
            textBox.Text = newComponent.Text;
            if (newComponent.Warranty < DateTime.Now)
            {
                warrantyTimePicker.Value = new DateTime(1753, 01, 01);
                label8.Text = "There were no warranty!";
            }
            else
            {
                warrantyTimePicker.Value = (DateTime)newComponent.Warranty;
            }

            RAMGenerationComboBox1.SelectedItem = (modification as RAM).RamGeneration;
            sizeNumericUpDown1.Value = (modification as RAM).Size;
            frequencyNumericUpDown2.Value = (modification as RAM).Frequency;
            latencyNumericUpDown3.Value = (modification as RAM).Latency;
            piecesNumericUpDown4.Value = (modification as RAM).Pieces;
            eccCheckBox.Checked = (modification as RAM).Ecc;
            rgbCheckBox.Checked = (modification as RAM).Rgb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (productNameTextBox.Text.Trim() != "")
            {
                try
                {
                    newComponent = new RAM(manufacturerTextBox.Text, productNameTextBox.Text, serialNumberTextBox.Text, (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, (RAMGeneration) RAMGenerationComboBox1.SelectedItem, (int) sizeNumericUpDown1.Value, (int) frequencyNumericUpDown2.Value, (int) latencyNumericUpDown3.Value, (int) piecesNumericUpDown4.Value, eccCheckBox.Checked, rgbCheckBox.Checked);

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }

            }
            else
            {
                MessageBox.Show("The product's name must be filled!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.None;

            }
        }
    }
}
