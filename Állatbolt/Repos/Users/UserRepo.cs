using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Microsoft.Win32;
using AllatboltProject.Users;

namespace AllatboltProject.Repos
{
    public class UserRepo
    {
        #region Database
        private List<User> _users = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Pethő",
                LastName = "Boglárka",
                IsFemale = true,
                BirthsDay = new DateTime(2005, 09, 10),
                PhoneNumber = "+36 30 390 5723",
                Email = "b0petbog@vasvari.org",
                Address = "Szeged",
                Username = "PetBog0214",
                Password = "varazsszo123",
                ImageSrc = new BitmapImage(new Uri("/Image/default.png", UriKind.Relative)),
                IsAdmin = true
            },
            new()
            {
                Id = Guid.Empty,
                FirstName = "Mészáros",
                LastName = "Eszter",
                IsFemale = true,
                BirthsDay = new DateTime(1982, 02, 14),
                PhoneNumber = "",
                Email = "esztike14@gmail.com",
                Address = "",
                Username = "esztike14",
                Password = "varazsszo123",
                ImageSrc = new BitmapImage(new Uri("/Image/default.png", UriKind.Relative)),
                IsAdmin = false
            }
        };
        #endregion

        public List<User> FindAll()
        {
            return _users;
        }

        public void Insert(User user)
        {
            _users.Add(user);
        }

        public void Update(User user)
        {
            if (!user.HasId)
            {
                Insert(user);
            }
            else
            {
                User? userToUpdate = _users.FirstOrDefault(u => u.Id == user.Id);
                userToUpdate?.Set(user);
            }
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public void UploadImage(User user)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp;*.jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                user.ImageSrc = new BitmapImage(new System.Uri(openDialog.FileName));
            }
        }

        public int GetNumberOfUsers()
        {
            return FindAll().Count();
        }
    }
}
