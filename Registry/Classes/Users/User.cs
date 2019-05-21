using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Registry.Classes.Users
{
    class User
    {
        private string userName;
        private string email;
        private string password;
        public int UserId { get; set; }

        public string UserName
        {
            get { return userName; }
            set
            {
                if (value.Trim() != "")
                {

                    if (value.Length >= 6)
                    {
                        userName = value;
                    }
                    else
                    {
                        throw new ArgumentException("Username must have 6 characters or more!");
                    }
                }
                else
                {
                    throw new ArgumentException("Username can't be empty!");
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                MailAddress valami = new MailAddress(value);
                if (emailIsValid(value.Trim()))
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentException("E-mail is not valid!");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Trim().Length >= 6)
                {
                    password = value;
                }
                else
                {
                    throw new ArgumentException("Password must contain 6 characters or more!");
                }
            }
        }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public User(string userName, string email, int userId)
        {
            UserName = userName;
            Email = email;
            UserId = userId;
        }

        public User(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
