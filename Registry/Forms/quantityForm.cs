using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registry.Forms
{
    public partial class quantityForm : Form
    {
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public quantityForm(string title, string question)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            titleLabel.Text = title;
            questionTextBox.Text = question;
            SystemSounds.Beep.Play();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (quantityNumericUpDown.Value >= 1)
            {
                quantity = (int)quantityNumericUpDown.Value;
            }
        }

        //Making top panel movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
