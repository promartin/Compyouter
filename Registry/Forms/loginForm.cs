using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registry.Classes.Users;
using Registry.Database.Config;

namespace Registry.Forms
{
    public partial class loginForm : Form
    {
        internal static User user { get; set; }

        public loginForm()
        {
            InitializeComponent();
            this.BackColor = BackColor = ColorTranslator.FromHtml("#2D2D30");
            userNameTextBox.BackColor = ColorTranslator.FromHtml("#2D2D30");
            passwordTextBox.BackColor = ColorTranslator.FromHtml("#2D2D30");

            userNameTextBox.GotFocus += UserNameTextBoxOnGotFocus;
            passwordTextBox.GotFocus += PasswordTextBoxOnGotFocus;
        }

        private void PasswordTextBoxOnGotFocus(object sender, EventArgs e)
        {
            passwordErrorLabel.Hide();
            passwordLabel.ForeColor = Color.DarkGray;
            passwordPanel.BackColor = Color.DarkGray;
            userLabel.ForeColor = Color.FromArgb(109, 109, 109);
            userPanel.BackColor = Color.FromArgb(109, 109, 109);
            
        }

        private void UserNameTextBoxOnGotFocus(object sender, EventArgs e)
        {
            userErrorLabel.Hide();
            userLabel.ForeColor = Color.DarkGray;
            if (userPanel.BackColor != Color.Red)
            {
                userPanel.BackColor = Color.DarkGray;
            }
            passwordLabel.ForeColor = Color.FromArgb(109, 109, 109);
            passwordPanel.BackColor = Color.FromArgb(109, 109, 109);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (userNameTextBox.Text.Trim() != "")
            {
                if (passwordTextBox.Text.Trim() != "")
                {
                    try
                    {
                        user = DBManager.Login(new User(userNameTextBox.Text, passwordTextBox.Text));
                    }
                    catch (Exception exception)
                    {
                        if (exception.Message == "There is no user named like that!")
                        {
                            passwordErrorLabel.Hide();
                            userErrorLabel.Show();
                            userErrorLabel.Text = exception.Message;
                            userPanel.BackColor = Color.Red;
                        }
                        else if (exception.Message == "Wrong password!")
                        {
                            userErrorLabel.Hide();
                            passwordErrorLabel.Show();
                            passwordErrorLabel.Text = exception.Message;
                            passwordPanel.BackColor = Color.Red;
                        }
                        else
                        {
                            MessageBox.Show(exception.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (userNameTextBox.Text.Trim() == "")
            {
                userPanel.BackColor = Color.DarkGray;
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Trim() == "")
            {
                passwordPanel.BackColor = Color.DarkGray;
            }
        }

        //Create registering part!
        private void RegisterLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
