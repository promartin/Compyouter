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
using Registry.Classes.Components.Cooler;

namespace Registry.Forms
{
    public partial class newCoolerForm : Form
    {
        internal static Components newComponent;
        public static Components NewComponent
        {
            get => newComponent;
            set => newComponent = value;
        }

        public newCoolerForm()
        {
            InitializeComponent();
            dateOfPurchaseTimePicker.Value = DateTime.Today;
            warrantyTimePicker.Value = DateTime.Today;
        }

        public newCoolerForm(Components modificate)
        {
            InitializeComponent();
            newComponent = modificate;
            dateOfPurchaseTimePicker.Value = DateTime.Today;
            maufacturerTextBox.Text = newComponent.Manufacturer;
            productNameTextBox.Text = newComponent.ProductsName;
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

            checkBox1.Checked = (newComponent as Cooler).Lga1151;
            checkBox2.Checked = (newComponent as Cooler).Lga2066;
            checkBox3.Checked = (newComponent as Cooler).Lga2011;
            checkBox4.Checked = (newComponent as Cooler).Lga1366;
            checkBox5.Checked = (newComponent as Cooler).Lga775;
            checkBox6.Checked = (newComponent as Cooler).Fm122plus3plus;
            checkBox7.Checked = (newComponent as Cooler).AM22plus33plus;
            checkBox8.Checked = (newComponent as Cooler).Am4;
            checkBox9.Checked = (newComponent as Cooler).Tr4;
            numericUpDown1.Value = (newComponent as Cooler).Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maufacturerTextBox.Text.Trim() != "")
            {
                if (productNameTextBox.Text.Trim() != "")
                {
                    try
                    {
                        newComponent = new Cooler(maufacturerTextBox.Text, productNameTextBox.Text, serialNumberTextBox.Text, (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked, checkBox5.Checked, checkBox6.Checked, checkBox8.Checked, checkBox7.Checked, checkBox9.Checked, (int)numericUpDown1.Value);
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
            else
            {
                MessageBox.Show("The manufacturer's text has to be filled!", "Warning!", MessageBoxButtons.OK);
                DialogResult = DialogResult.None;
            }
        }
    }
}
