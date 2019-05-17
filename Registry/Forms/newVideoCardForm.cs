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
using Registry.Classes.Components.Videocard;

namespace Registry.Forms
{
    enum Manufacturer
    {
        AMD,
        GeForce
    }

    public partial class newVideoCardForm : Form
    {
        internal static Components newComponent;
        public static Components NewComponent
        {
            get => newComponent;
            set => newComponent = value;
        }



        public newVideoCardForm()
        {
            InitializeComponent();
            manufacturerComboBox.DataSource = Enum.GetValues(typeof(Manufacturer));
            comboBox1.DataSource = Enum.GetValues(typeof(Design));
            dateOfPurchaseTimePicker.Value = DateTime.Today;
            warrantyTimePicker.Value = DateTime.Today;
        }

        public newVideoCardForm(Components modification)
        {
            InitializeComponent();
            newComponent = modification;
            manufacturerComboBox.DataSource = Enum.GetValues(typeof(Manufacturer));
            comboBox1.DataSource = Enum.GetValues(typeof(Design));
            productsTextBox.Text = newComponent.ProductsName;
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

            numericUpDown1.Value = (decimal)(modification as Videocard).Gb;
            numericUpDown2.Value = (modification as Videocard).PcieConnector;
            numericUpDown3.Value = (modification as Videocard).VideoCardLength;
            numericUpDown4.Value = (modification as Videocard).Tdp;
            comboBox1.SelectedItem = (modification as Videocard).Design;
            if (modification.Manufacturer == Manufacturer.AMD.ToString())
            {
                manufacturerComboBox.SelectedIndex = (int)Manufacturer.AMD;
            }
            else if (modification.Manufacturer == Manufacturer.GeForce.ToString())
            {
                manufacturerComboBox.SelectedIndex = (int)Manufacturer.GeForce;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (manufacturerComboBox.SelectedIndex == (int)Manufacturer.GeForce)
                {
                    newComponent = new Videocard("GeForce", productsTextBox.Text, serialNumberTextBox.Text,
                        (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, (double)numericUpDown1.Value, (Design)comboBox1.SelectedItem, (int)numericUpDown4.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
                }
                else
                {
                    newComponent = new Videocard("AMD", productsTextBox.Text, serialNumberTextBox.Text,
                        (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, (double)numericUpDown1.Value, (Design)comboBox1.SelectedItem, (int)numericUpDown4.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
