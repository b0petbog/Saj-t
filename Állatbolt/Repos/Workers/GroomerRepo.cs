using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Microsoft.Win32;
using AllatboltProject.Workers;

namespace AllatboltProject.Repos
{
    public class GroomerRepo
    {
        #region Database
        private List<Groomer> _groomers = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                FirstName = "",
                LastName = "",
                IsFemale = true,
                Animals = "",
                Webpage = "",
                PhoneNumber = "",
                Email = "",
                Address = "",
                Username = "",
                Password = "",
                IsAdmin = false,
                ImageSrc = new BitmapImage(new Uri("/Image/default.png", UriKind.Relative))
            }
        };
        #endregion

        public List<Groomer> FindAll()
        {
            return _groomers;
        }

        public void Insert(Groomer groomer)
        {
            _groomers.Add(groomer);
        }

        public void Update(Groomer groomer)
        {
            if (!groomer.HasId)
            {
                Insert(groomer);
            }
            else
            {
                Groomer? groomerToUpdate = _groomers.FirstOrDefault(g => g.Id == groomer.Id);
                groomerToUpdate?.Set(groomer);
            }
        }

        public void Delete(Groomer groomer)
        {
            _groomers.Remove(groomer);
        }

        public void UploadImage(Groomer groomer)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp;*.jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                groomer.ImageSrc = new BitmapImage(new System.Uri(openDialog.FileName));
            }
        }

        public int GetNumberOfGroomers()
        {
            return FindAll().Count();
        }
    }
}
