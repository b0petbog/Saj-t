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
    public class VetRepo
    {
        #region Database
        private List<Vet> _vets = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Dr. Farkas",
                LastName = "Patrícia Éva",
                IsFemale = true,
                Animals = "Kisállatok, hüllők, kutyák, macskák, madarak, lovak, haszonállatok, baromfik, vadállatok",
                Webpage = "www.szegedallatorvosirendelo.hu",
                PhoneNumber = "06 20 436 1723",
                Email = "farkas.patricia@gmail.com",
                Address = "Bokor utca 12/a., 6722 Szeged",
                Username = "farkas.pati04",
                Password = "varazsszo123",
                IsAdmin = false,
                ImageSrc = new BitmapImage(new Uri("/Image/default.png", UriKind.Relative))
            }
        };
        #endregion

        public List<Vet> FindAll()
        {
            return _vets;
        }

        public void Insert(Vet wet)
        {
            _vets.Add(wet);
        }

        public void Update(Vet vet)
        {
            if (!vet.HasId)
            {
                Insert(vet);
            }
            else
            {
                Vet? vetToUpdate = _vets.FirstOrDefault(v => v.Id == vet.Id);
                vetToUpdate?.Set(vet);
            }
        }

        public void Delete(Vet vet)
        {
            _vets.Remove(vet);
        }

        public void UploadImage(Vet vet)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp;*.jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                vet.ImageSrc = new BitmapImage(new System.Uri(openDialog.FileName));
            }
        }

        public int GetNumberOfVets()
        {
            return FindAll().Count();
        }
    }
}
