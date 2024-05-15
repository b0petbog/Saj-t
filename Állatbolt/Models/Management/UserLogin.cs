using System;
using System.Security;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AllatboltProject.Management
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLogin(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public UserLogin()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        public void Set(UserLogin user)
        {
            Username = user.Username;
            Password = user.Password;
        }
        public override string ToString()
        {
            return $"{Username}";
        }
    }
}
