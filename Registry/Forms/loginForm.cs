using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Registry.Classes.Users;
using Registry.Database.Config;

namespace Registry.Forms
{
    public partial class loginForm : Form
    {
        private static User user;

        private Control[,] fieldGroups;
        private int fieldgroup1D;
        private int fieldgroup2D;

        private TextBox confirmTextBox;
        private Panel confirmPanel;
        private Label confirmLabel;
        private Label confirmErrorLabel;

        private TextBox registerPass;
        private Panel registerPassPanel;
        private Label registerPassLabel;

        private bool wePositionedThem;
        private bool loginPage;


        #region Draggable surfaces
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        public loginForm()
        {
            InitializeComponent();

            loginPage = true;
            successLabel.Hide();
            this.BackColor = BackColor = ColorTranslator.FromHtml("#2D2D30");
            userNameTextBox.BackColor = ColorTranslator.FromHtml("#2D2D30");
            passwordTextBox.BackColor = ColorTranslator.FromHtml("#2D2D30");

            fieldGroups = new Control[4, 3] { { passwordLabel.Clone(), passwordTextBox.Clone(), passwordPanel.Clone() }, { passwordLabel.Clone(), passwordTextBox.Clone(), passwordPanel.Clone() }, { passwordLabel, passwordTextBox, passwordPanel }, { userLabel, userNameTextBox, userPanel } };
            fieldgroup1D = fieldGroups.GetLength(0);
            fieldgroup2D = fieldGroups.GetLength(1);

            //Give them Lost and Got focus event
            for (int i = 0; i < fieldgroup1D; i++)
            {
                for (int j = 0; j < fieldgroup2D; j++)
                {
                    if (fieldGroups[i, j] is TextBox)
                    {
                        fieldGroups[i, j].GotFocus += OnGotFocus;
                        fieldGroups[i, j].LostFocus += OnLostFocus;
                        fieldGroups[i, j].KeyDown += TextBox_TextChanged;
                    }
                }
            }

            //These lines of code are here to avoid flickering on panel1
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            int style = Form1.NativeWinAPI.GetWindowLong(panel1.Handle, Form1.NativeWinAPI.GWL_EXSTYLE);
            style |= Form1.NativeWinAPI.WS_EX_COMPOSITED;
            Form1.NativeWinAPI.SetWindowLong(panel1.Handle, Form1.NativeWinAPI.GWL_EXSTYLE, style);
            //
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            for (int i = 0; i < fieldgroup1D; i++)
            {
                for (int j = 0; j < fieldgroup2D; j++)
                {
                    if (fieldGroups[i, j] is TextBox && fieldGroups[i, j].Visible && fieldGroups[i, j].Focused)
                    {
                        for (int k = 0; k < fieldgroup2D; k++)
                        {
                            if (fieldGroups[i, k] is Label || fieldGroups[i, k] is TextBox)
                            {
                                if (fieldGroups[i, k].ForeColor != Color.Red)
                                {
                                    fieldGroups[i, k].ForeColor = Color.DarkGray;
                                }
                            }
                            else
                            {
                                if (fieldGroups[i, k].BackColor != Color.Red)
                                {
                                    fieldGroups[i, k].BackColor = Color.DarkGray;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            for (int i = 0; i < fieldgroup1D; i++)
            {
                for (int j = 0; j < fieldgroup2D; j++)
                {
                    if (fieldGroups[i, j] is TextBox && fieldGroups[i, j].Visible && fieldGroups[i, j].ForeColor != Color.Red && !fieldGroups[i, j].Focused)
                    {
                        for (int k = 0; k < fieldgroup2D; k++)
                        {
                            if (fieldGroups[i, k] is Label && fieldGroups[i, k].ForeColor != Color.Red)
                            {
                                fieldGroups[i, k].ForeColor = Color.FromArgb(109, 109, 109);
                            }
                            else if (fieldGroups[i, k] is TextBox && fieldGroups[i, k].ForeColor != Color.Red)
                            {
                                fieldGroups[i, k].ForeColor = Color.FromArgb(109, 109, 109);
                            }
                            else if (fieldGroups[i, k] is Panel && fieldGroups[i, k].BackColor != Color.Red)
                            {
                                fieldGroups[i, k].BackColor = Color.FromArgb(109, 109, 109);
                            }
                        }
                    }
                }
            }
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

                        if (user != null)
                        {
                            this.Hide();
                            Form form1 = new Form1(user);
                            form1.Closed += (s, args) => this.Close();
                            form1.Show();
                        }
                    }
                    catch (Exception exception)
                    {
                        if (exception.Message == "There is no user named like that!")
                        {
                            passwordErrorLabel.Hide();
                            userErrorLabel.Show();
                            userErrorLabel.Text = exception.Message;
                            userErrorLabel.ForeColor = Color.Red;
                            userPanel.BackColor = Color.Red;
                        }
                        else if (exception.Message == "Wrong password!")
                        {
                            userErrorLabel.Hide();
                            passwordErrorLabel.Show();
                            passwordErrorLabel.Text = exception.Message;
                            passwordErrorLabel.ForeColor = Color.Red;
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

        private void TextBox_TextChanged(object sender, KeyEventArgs e)
        {
            string a = (sender as TextBox).Text;
            if (e.KeyData == Keys.Back || e.KeyData == Keys.Delete || (sender as TextBox).Text.Length == 1)
            {

                if (sender == userNameTextBox)
                {
                    userNameTextBox.ForeColor = Color.DarkGray;
                    userErrorLabel.Hide();
                }
                else if (sender == passwordTextBox)
                {
                    passwordTextBox.ForeColor = Color.DarkGray;
                    passwordErrorLabel.Hide();
                }
                else if (sender == registerPass)
                {
                    registerPass.ForeColor = Color.DarkGray;
                    confirmErrorLabel?.Hide();
                }
                else if (sender == confirmTextBox)
                {
                    confirmTextBox.ForeColor = Color.DarkGray;
                    confirmErrorLabel?.Hide();
                }
            }
        }

        //Create registering part!
        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            if (registerLabel.Text == "You haven't registered yet? Register!")
            {
                SetExistingForRegister();
                loginPage = false;


                int lastAddedControlGroup = 0;

                for (int i = 0; i < fieldgroup1D; i++)
                {
                    for (int j = 0; j < fieldgroup2D; j++)
                    {
                        if (!fieldGroups[i, j].Visible)
                        {
                            if (!wePositionedThem)
                            {
                                if (lastAddedControlGroup >= i)
                                {
                                    fieldGroups[i, j].Top += 75;
                                    lastAddedControlGroup = i;
                                    if (fieldGroups[i, j] is Label)
                                    {
                                        registerPassLabel = fieldGroups[i, j] as Label;
                                    }
                                    else if (fieldGroups[i, j] is Panel)
                                    {
                                        registerPassPanel = fieldGroups[i, j] as Panel;
                                    }
                                    else
                                    {
                                        registerPass = fieldGroups[i, j] as TextBox;
                                    }
                                }
                                else
                                {

                                    if (fieldGroups[i, j] is Label)
                                    {
                                        fieldGroups[i, j].Name = "confirmPasswordLabel";
                                        fieldGroups[i, j].Text = "Confirm password";
                                        confirmLabel = fieldGroups[i, j] as Label;
                                    }
                                    else if (fieldGroups[i, j] is Panel)
                                    {
                                        fieldGroups[i, j].Name = "confirmPasswordPanel";
                                        confirmPanel = fieldGroups[i, j] as Panel;
                                    }
                                    else
                                    {
                                        fieldGroups[i, j].Name = "confirmPasswordTextBox";
                                        confirmTextBox = fieldGroups[i, j] as TextBox;
                                    }
                                    fieldGroups[i, j].Top = fieldGroups[lastAddedControlGroup, j].Top + 75;
                                }
                            }

                            fieldGroups[i, j].Show();
                        }
                    }
                }

                wePositionedThem = true;
                OnLostFocus(sender, e);
            }
            else if (registerLabel.Text == "Register!")
            {
                bool weHaveError = false;

                List<Label> excpetLabels = new List<Label>();
                if (userNameTextBox.Text.Trim() != "")
                {
                    if (User.emailIsValid(userNameTextBox.Text))
                    {
                        if (passwordTextBox.Text.Trim().Length >= 6)
                        {
                            if (confirmTextBox.Text == registerPass.Text)
                            {
                                try
                                {
                                    user = new User(passwordTextBox.Text, userNameTextBox.Text, registerPass.Text);
                                    DBManager.Register(user);

                                    SetEverythingBack();
                                    successLabel.Show();
                                }
                                catch (Exception exception)
                                {
                                    if (exception.Message == "This username is in use!")
                                    {
                                        weHaveError = true;
                                        Errors("This username is in use!");
                                    }
                                    else if (exception.Message == "This E-mail is already in use!")
                                    {
                                        weHaveError = true;
                                        Errors("This E-mail is already in use!");
                                    }
                                    else
                                    {
                                        MessageBox.Show(exception.Message, "Error!", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                weHaveError = true;
                                Errors("The passwords don't match!");
                            }
                        }
                        else
                        {
                            weHaveError = true;
                            Errors("The user name must contain 6 characters!");
                        }
                    }
                    else
                    {
                        weHaveError = true;
                        Errors("This E-mail is not valid!");
                    }
                }
                else
                {
                    weHaveError = true;
                    Errors("Please, enter your E-mail!");
                }

                void Errors(string message)
                {
                    if (weHaveError)
                    {
                        userLabel.ForeColor = Color.FromArgb(109, 109, 109);
                        userPanel.BackColor = Color.FromArgb(109, 109, 109);
                        passwordLabel.ForeColor = Color.FromArgb(109, 109, 109);
                        passwordPanel.BackColor = Color.FromArgb(109, 109, 109);
                        registerPassLabel.ForeColor = Color.FromArgb(109, 109, 109);
                        registerPassPanel.BackColor = Color.FromArgb(109, 109, 109);
                        confirmLabel.ForeColor = Color.FromArgb(109, 109, 109);
                        confirmPanel.BackColor = Color.FromArgb(109, 109, 109);

                        userNameTextBox.Focus();
                        OnGotFocus(null, null);

                        TextBox_TextChanged(userNameTextBox, new KeyEventArgs(Keys.Delete));
                        TextBox_TextChanged(passwordTextBox, new KeyEventArgs(Keys.Delete));
                        TextBox_TextChanged(registerPass, new KeyEventArgs(Keys.Delete));
                        TextBox_TextChanged(confirmTextBox, new KeyEventArgs(Keys.Delete));
                    }

                    if (message == "Please, enter your E-mail!" || message == "This E-mail is not valid!" || message == "This E-mail is already in use!")
                    {
                        userErrorLabel.Show();
                        userErrorLabel.Text = message;
                        userLabel.ForeColor = Color.Red;
                        userPanel.BackColor = Color.Red;
                        excpetLabels.Add(userLabel);
                        excpetLabels.Add(userErrorLabel);
                    }
                    else if (message == "The user name must contain 6 characters!" || message == "This username is in use!")
                    {
                        passwordErrorLabel.Show();
                        passwordErrorLabel.Text = message;
                        passwordLabel.ForeColor = Color.Red;
                        passwordPanel.BackColor = Color.Red;
                        excpetLabels.Add(passwordLabel);
                        excpetLabels.Add(passwordErrorLabel);

                    }
                    else if (message == "The passwords don't match!")
                    {
                        confirmErrorLabel = userErrorLabel.Clone();
                        confirmErrorLabel.Location = new Point(userErrorLabel.Location.X, registerPass.Top + 30);
                        confirmErrorLabel.Text = message;
                        confirmErrorLabel.Show();

                        confirmLabel.ForeColor = Color.Red;
                        confirmPanel.BackColor = Color.Red;

                        registerPassLabel.ForeColor = Color.Red;
                        registerPassPanel.BackColor = Color.Red;

                        excpetLabels.Add(confirmLabel);
                        excpetLabels.Add(confirmErrorLabel);
                        excpetLabels.Add(registerPassLabel);
                    }
                }
            }
        }

        private void SetEverythingBack()
        {
            loginPage = true;

            userNameTextBox.Focus();

            userLabel.Text = "Username";
            if (user != null)
            {
                userNameTextBox.Text = user.UserName;
            }
            else
            {
                userNameTextBox.Text = "";
            }

            userPanel.BackColor = Color.FromArgb(109, 109, 109);

            passwordLabel.Text = "Password";
            passwordTextBox.Text = "";
            passwordTextBox.PasswordChar = '*';
            passwordPanel.BackColor = Color.FromArgb(109, 109, 109);

            registerLabel.Text = "You haven't registered yet? Register!";
            exitButton.Text = "Exit";

            forgotPasswordLabel.Show();
            loginButton.Show();
            confirmErrorLabel?.Hide();

            for (int i = 0; i < fieldgroup1D; i++)
            {
                for (int j = 0; j < fieldgroup2D; j++)
                {
                    if (fieldGroups[i, j] == registerPass || fieldGroups[i, j] == confirmTextBox)
                    {
                        for (int k = 0; k < fieldgroup2D; k++)
                        {
                            if (fieldGroups[i, j] is TextBox)
                            {
                                fieldGroups[i, j].Text = "";
                            }
                            fieldGroups[i, k].Hide();
                        }
                    }
                }
            }

            SetEveryLabelBack(null);
        }


        private void SetEveryLabelBack(List<Label> exceptTheseOnes)
        {
            int countControl = this.Controls.Count;
            for (int i = 0; i < countControl; i++)
            {
                if (exceptTheseOnes != null)
                {
                    if (this.Controls[i] != registerLabel)
                    {
                        if (this.Controls[i] is Label && !exceptTheseOnes.Contains(this.Controls[i]))
                        {
                            this.Controls[i].ForeColor = Color.FromArgb(109, 109, 109);
                        }
                        else if (this.Controls[i].Visible && this.Controls[i] is Label)
                        {
                            this.Controls[i].ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    if (this.Controls[i] is Label && this.Controls[i] != userLabel && this.Controls[i] != passwordLabel && this.Controls[i] != registerLabel && this.Controls[i] != forgotPasswordLabel && this.Controls[i] != successLabel)
                    {
                        this.Controls[i].Hide();
                    }

                    if (this.Controls[i] is Label && this.Controls[i] != forgotPasswordLabel && this.Controls[i] != successLabel)
                    {
                        this.Controls[i].ForeColor = Color.FromArgb(109, 109, 109);
                    }
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (exitButton.Text == "Exit")
            {
                Application.Exit();
            }
            else if (exitButton.Text == "Back")
            {
                SetEverythingBack();
            }
        }

        private void SetExistingForRegister()
        {
            userNameTextBox.Text = "";
            userErrorLabel.Hide();
            passwordErrorLabel.Hide();
            userNameTextBox.Focus();

            passwordTextBox.Text = "";
            registerLabel.Text = "Register!";
            exitButton.Text = "Back";
            userLabel.Text = "E-mail address";
            passwordLabel.Text = "Username";
            passwordTextBox.PasswordChar = '\0';
            forgotPasswordLabel.Hide();
            loginButton.Hide();
            successLabel.Hide();

            for (int i = 0; i < fieldgroup1D; i++)
            {
                for (int j = 0; j < fieldgroup2D; j++)
                {
                    if (fieldGroups[i, j].BackColor == Color.Red || fieldGroups[i, j].ForeColor == Color.Red)
                    {
                        if (fieldGroups[i, j].Focused)
                        {
                            if (fieldGroups[i, j] is TextBox || fieldGroups[i, j] is Label)
                            {
                                fieldGroups[i, j].ForeColor = Color.DarkGray;
                            }
                            else
                            {
                                fieldGroups[i, j].BackColor = Color.DarkGray;
                            }
                        }
                        else
                        {
                            if (fieldGroups[i, j] is TextBox || fieldGroups[i, j] is Label)
                            {
                                fieldGroups[i, j].ForeColor = Color.FromArgb(109, 109, 109);
                            }
                            else
                            {
                                fieldGroups[i, j].BackColor = Color.FromArgb(109, 109, 109);
                            }
                        }
                    }
                }
            }
        }

        private void RegisterLabel_MouseEnter(object sender, EventArgs e)
        {
            registerLabel.Cursor = Cursors.Hand;
            registerLabel.ForeColor = Color.CornflowerBlue;
            registerLabel.Font = new Font(registerLabel.Font.Name, registerLabel.Font.SizeInPoints, FontStyle.Bold | FontStyle.Underline);
        }

        private void RegisterLabel_MouseLeave(object sender, EventArgs e)
        {
            registerLabel.ForeColor = Color.DarkGray;
            registerLabel.Font = new Font(registerLabel.Font.Name, registerLabel.Font.SizeInPoints, FontStyle.Bold);
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (loginPage)
                {
                    loginButton.PerformClick();
                }
                else
                {
                    RegisterLabel_Click(sender, e);
                }
            }
        }

        private void ForgotPasswordLabel_Click(object sender, EventArgs e)
        {

        }
    }

    public static class ControlExtensions
    {
        public static T Clone<T>(this T controlToClone)
            where T : Control
        {
            PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            T instance = Activator.CreateInstance<T>();

            foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                        propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                }
            }

            return instance;
        }
    }
}