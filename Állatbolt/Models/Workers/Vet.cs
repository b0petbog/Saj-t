using System;
using System.Net;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AllatboltProject.Workers
{
    public class Vet
    {
        public Guid Id { get; set; }
        public bool HasId => Id != Guid.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFemale { get; set; }
        public bool IsMale => !IsFemale;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Animals { get; set; }
        public string Webpage { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ImageSource ImageSrc { get; set; }
        public bool IsAdmin { get; set; }

        public Vet(Guid id, string firstname, string lastname, bool isFemale, string phoneNumber, string email, string address, string animals, string webpage, string username, string password, ImageSource imageSrc)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            IsFemale = isFemale;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            Animals = animals;
            Webpage = webpage;
            Username = username;
            Password = password;
            ImageSrc = imageSrc;
        }

        public Vet()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            IsFemale = false;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            Animals = string.Empty;
            Webpage = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            ImageSrc = new BitmapImage(new Uri("/Image/default.png", UriKind.Relative));
            IsAdmin = false;
        }

        public void Set(Vet vet)
        {
            Id = vet.Id;
            FirstName = vet.FirstName;
            LastName = vet.LastName;
            IsFemale = vet.IsFemale;
            PhoneNumber = vet.PhoneNumber;
            Email = vet.Email;
            Address = vet.Address;
            Animals = vet.Animals;
            Webpage = vet.Webpage;
            Username = vet.Username;
            Password = vet.Password;
            ImageSrc = vet.ImageSrc;
            IsAdmin = vet.IsAdmin;
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
                return "Felhasználó";
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}\t {Username}\t {Admin()}";
        }
    }
}
