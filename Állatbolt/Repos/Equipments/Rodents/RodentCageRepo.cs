using System;
using AllatboltProject.Equipments;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Microsoft.Win32;

namespace AllatboltProject.Repos
{
    public class RodentCageRepo
    {
        #region Database
        private List<Cage> _cages = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/Cages/ferplastRabbit.png", UriKind.Relative)),
                Brand = "Ferplast",
                Name = "kisállatketrec",
                Animal = "nyúl",
                Size = "95 x 57 x 46",
                Description = "Robusztus rágcsálóketrec, felhajtható elülső oldallal, megemelt aljtálcávall, alapfelszereltséggel együtt",
                Price = 20690,
                Avability = true,
            }
        };
        #endregion

        public List<Cage> FindAll()
        {
            return _cages;
        }

        public void Insert(Cage cage)
        {
            _cages.Add(cage);
        }

        public void Update(Cage cage)
        {
            if (!cage.HasId)
            {
                Insert(cage);
            }
            else
            {
                Cage? cageToUpdate = _cages.FirstOrDefault(c => c.Id == cage.Id);
                cageToUpdate?.Set(cage);
            }
        }

        public void Delete(Cage cage)
        {
            _cages.Remove(cage);
        }

        public void UploadImage(Cage cage)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp;*.jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                cage.ImageSrc = new BitmapImage(new System.Uri(openDialog.FileName));
                Update(cage);
            }
        }

        public int GetNumberOfCages()
        {
            return FindAll().Count();
        }
    }
}
