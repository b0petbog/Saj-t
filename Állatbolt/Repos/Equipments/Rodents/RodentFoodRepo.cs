using System;
using AllatboltProject.Equipments;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace AllatboltProject.Repos
{
    public class RodentFoodRepo
    {
        #region Database
        private List<Food> _foods = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/RodentFood/guineapigFood.jpg", UriKind.Relative)),
                Brand = "Panzi",
                Name = "tengerimalac eleség",
                Volume = 0.5,
                Description = "Egy teljes értékű-, gyümölcsöket is tartalmazó tengerimalac eledel, mely tartalmazza mindazt, amire az Ön kedvencének szüksége van. Minőségi összetevők, ízletes falatok biztosítják azokat az Ön kedvence számára fontos vitaminokat, ásványi anyagokat, fehérjéket és rostokat, melyek biztosítják, hogy szőrzete mindig egészséges és fényes legyen, kedvence pedig élénk és aktív maradjon",
                Composition = "Gabona granulátumok és pelyhek, napraforgó, kukorica, zab, búza, aszalt gyümölcsök, tökmag különböző arányú keverékei",
                Price = 1390,
                Avability = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/RodentFood/hamsterFood.jpg", UriKind.Relative)),
                Brand = "Vitakraft",
                Name = "törpehörcsög menü",
                Volume = 0.4,
                Description = "Teljes értékű eledel törpehörcsögök számára. A vitaminok, ásványi anyagok és nyomelemek segítik az állat optimális ellátását. A linolsav, cink és biotin ápolják a szőrzetet. A fehérjetartalom segíti az energiaellátást. Nem tartalmaz gyümölcsöket.",
                Composition = "Gabona, növényi eredetű származékok, magok, zöldségek, mogyoró 3%,  puhatestűek és rákfélék (szárított garnéla 2%), ásványi anyagok. ",
                Price = 1890,
                Avability = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/RodentFood/hedgehogFood.jpg", UriKind.Relative)),
                Brand = "Vitakraft",
                Name = "Igelfutter süni eledel",
                Volume = 0.6,
                Description = "Vitakraft Menü egy hatékony, sokoldalú természetes eledel, amely növeli a túlélési esélyeit az esetlegesen legyengült sünök számára és biztosítja az egészséges táplálkozást",
                Composition = "Rovarok, puhatestűek, rákfélékkel, diófélék, gyümölcsök, vitaminok, ásványi anyagok",
                Price = 3990,
                Avability = true
            }

        };
        #endregion

        public List<Food> FindAll()
        {
            return _foods;
        }

        public void Insert(Food food)
        {
            _foods.Add(food);
        }

        public void Update(Food food)
        {
            if (!food.HasId)
            {
                Insert(food);
            }
            else
            {
                Food? foodToUpdate = _foods.FirstOrDefault(f => f.Id == food.Id);
                foodToUpdate?.Set(food);
            }
        }

        public void Delete(Food food)
        {
            _foods.Remove(food);
        }

        public void UploadImage(Food food)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp;*.jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                food.ImageSrc = new BitmapImage(new System.Uri(openDialog.FileName));
            }
        }

        public int GetNumberOfFoods()
        {
            return FindAll().Count();
        }
    }
}
