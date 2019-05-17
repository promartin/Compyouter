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
using Registry.Classes.Components.Processors;

namespace Registry.Forms
{
    public partial class newProcessorForm : Form
    {
        internal static Components newComponent;

        public static Components NewComponent
        {
            get => newComponent;
            set => newComponent = value;
        }

        enum Manufacturers
        {
            AMD,
            Intel
        }

        public newProcessorForm()
        {
            InitializeComponent();
            dateOfPurchaseTimePicker.Value = DateTime.Today;
            warrantyTimePicker.Value = DateTime.Today;

            comboBox1.DataSource = Enum.GetValues(typeof(Manufacturers));

            amdComboBox2.DisplayMember = "Description";
            amdComboBox2.ValueMember = "Value";
            amdComboBox2.DataSource = Enum.GetValues(typeof(AMDSocket))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            intelcomboBox.DisplayMember = "Description";
            intelcomboBox.ValueMember = "Value";
            intelcomboBox.DataSource = Enum.GetValues(typeof(IntelSocket))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            switch ((Manufacturers)comboBox1.SelectedItem)
            {
                case Manufacturers.AMD:
                    amdgroupBox.Show();
                    IntelGroupBox.Hide();
                    break;
                case Manufacturers.Intel:
                    amdgroupBox.Hide();
                    IntelGroupBox.Show();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public newProcessorForm(Components modification)
        {
            InitializeComponent();
            dateOfPurchaseTimePicker.Value = DateTime.Today;

            comboBox1.DataSource = Enum.GetValues(typeof(Manufacturers));

            amdComboBox2.DisplayMember = "Description";
            amdComboBox2.ValueMember = "Value";
            amdComboBox2.DataSource = Enum.GetValues(typeof(AMDSocket))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            intelcomboBox.DisplayMember = "Description";
            intelcomboBox.ValueMember = "Value";
            intelcomboBox.DataSource = Enum.GetValues(typeof(IntelSocket))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            intelcomboBox.DisplayMember = "Description";
            intelcomboBox.ValueMember = "Value";
            intelcomboBox.DataSource = Enum.GetValues(typeof(IntelSocket))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            newComponent = modification;

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

            l2CacheNumericUpDown.Value = (decimal)(newComponent as Processor).L2Cache;
            l3CachenumericUpDown.Value = (decimal)(newComponent as Processor).L3Cache;
            coresnumericUpDown1.Value = (newComponent as Processor).Cores;
            threadsnumericUpDown2.Value = (newComponent as Processor).Threads;
            processnumericUpDown3.Value = (newComponent as Processor).Process;
            frequencynumericUpDown4.Value = (newComponent as Processor).Frequency;
            turbofrequencynumericUpDown5.Value = (newComponent as Processor).TurboFrequency;
            tdpnumericUpDown1.Value = (newComponent as Processor).Tdp;
            if (modification is AMDProcessor)
            {
                comboBox1.SelectedItem = Manufacturers.AMD;
                amdGraphicstextBox.Text = (newComponent as AMDProcessor).IntegratedGraphics;
                amdComboBox2.SelectedIndex = (int)(newComponent as AMDProcessor).AmdSocket;
            }
            else
            {
                comboBox1.SelectedItem = Manufacturers.Intel;
                intelTextBox.Text = (newComponent as IntelProcessor).IntegratedGraphics;
                intelcomboBox.SelectedIndex = (int)(newComponent as IntelProcessor).IntelSocket;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (productNameTextBox.Text.Trim() != "")
                {

                    switch ((Manufacturers)comboBox1.SelectedItem)
                    {
                        case Manufacturers.AMD:
                            newComponent = new AMDProcessor("AMD", productNameTextBox.Text, serialNumberTextBox.Text, (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, (double)l2CacheNumericUpDown.Value, (double)l3CachenumericUpDown.Value, (int)coresnumericUpDown1.Value, (int)threadsnumericUpDown2.Value, (int)processnumericUpDown3.Value, (int)frequencynumericUpDown4.Value, (int)turbofrequencynumericUpDown5.Value, (int)tdpnumericUpDown1.Value, (AMDSocket)amdComboBox2.SelectedIndex, amdGraphicstextBox.Text);
                            break;
                        case Manufacturers.Intel:
                            newComponent = new IntelProcessor("Intel", productNameTextBox.Text, serialNumberTextBox.Text, (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, (double)l2CacheNumericUpDown.Value, (double)l3CachenumericUpDown.Value, (int)coresnumericUpDown1.Value, (int)threadsnumericUpDown2.Value, (int)processnumericUpDown3.Value, (int)frequencynumericUpDown4.Value, (int)turbofrequencynumericUpDown5.Value, (int)tdpnumericUpDown1.Value, (IntelSocket)intelcomboBox.SelectedIndex, intelTextBox.Text);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                }
                else
                {
                    MessageBox.Show("The product's name must be filled!", "Warning!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DialogResult = DialogResult.None;

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((Manufacturers)comboBox1.SelectedItem)
            {
                case Manufacturers.AMD:
                    amdgroupBox.Show();
                    IntelGroupBox.Hide();
                    break;
                case Manufacturers.Intel:
                    amdgroupBox.Hide();
                    IntelGroupBox.Show();
                    break;
            }
        }
    }
}




