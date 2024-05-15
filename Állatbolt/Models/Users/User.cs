using System;
using System.Net;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AllatboltProject.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public bool HasId => Id != Guid.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFemale { get; set; }
        public bool IsMale => !IsFemale;
        public DateTime BirthsDay { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ImageSource ImageSrc { get; set; }
        public int BadPoints { get; set; }
        public bool IsAdmin {  get; set; }

        public User(Guid id, string firstname, string lastname, bool isFemale, DateTime birthsday, string phoneNumber, string email, string address, string username, string password, ImageSource imageSrc, bool isAdmin)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            IsFemale = isFemale;
            BirthsDay = birthsday;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            Username = username;
            Password = password;
            ImageSrc = imageSrc;
            IsAdmin = isAdmin;
        }

        public User()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            IsFemale = false;
            BirthsDay = DateTime.Now;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            ImageSrc = new BitmapImage(new Uri("/Image/default.png", UriKind.Relative));
            IsAdmin = false;
        }

        public void Set(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            IsFemale = user.IsFemale;
            BirthsDay = user.BirthsDay;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
            Address = user.Address;
            Username = user.Username;
            Password = user.Password;
            ImageSrc = user.ImageSrc;
            BadPoints = user.BadPoints;
            IsAdmin = user.IsAdmin;
        }

        public string Gender()
        {
            if (IsFemale == true)
            {
                return "Nő";
            }
            else
            {
                return "Férfi";
            }
        }

        public string Admin()
        {
            if (IsAdmin == true)
            {
                return "Adminisztrátor";
            }
            else
            {
                return "Rendszergazda";
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}\t {Username}\t {BadPoints}\t {Admin()}";
        }
    }
}
