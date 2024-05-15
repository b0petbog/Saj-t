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
using System.Windows.Data;

namespace AllatboltProject.Repos
{
    public class BeddingRepo
    {
        #region Database
        private List<Bedding> _baddings = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/Bedding/chipsiSuper.png", UriKind.Relative)),
                Brand = "Chipsi",
                Name = "Super háziállat alom",
                Volume = 24,
                Description = "A puhafa finom-granulátumból készülő Chipsi Super háziállat-alom újszerű és nagyon hatékony alomféleség. Az alom speciális szárítással készül, más faalmokhoz képest dupla felszívóerővel bír, így azután a nedvességet és szagokat fixen megköti a növényi rostok belsejében. Ezáltal a Chipsi Super optimálisan alkalmas allergiás vagy légzési nehézségekkel küzdő kisállatoknak, mivel csaknem teljesen por- és csíramentes. Emellett a puhafa-granulátum különösen takarékosan használható, s a legkiválóbb rothadási tulajdonságokkal rendelkezik. ",
                Material = "Puhafa-granulátum",
                Price = 11090,
                Avability = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/Bedding/chipsiSuper.png", UriKind.Relative)),
                Brand = "Dolly",
                Name = "faforgács",
                Volume = 15,
                Description = "",
                Material = "100% szárított, préselt, szitált fenyőfa forgács",
                Price = 13190,
                Avability = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/Bedding/safebedPapierflocken.png", UriKind.Relative)),
                Brand = "Petlife",
                Name = "Safebed alom papírpehely",
                Volume = 0.8,
                Description = "A Petlife Safebed papírpehely növényi rostokból készült alom, amely minden rágcsáló esetében alkalmazható. Kiváló minőségű teatasak- és kávéfilterpapírból állítják elő, ennek köszönhetően különösen természetes, biztonságos és nem mérgező. A nedvességet optimálisan képes megkötni, mivel a papírpelyhek rendkívül magas nedvszívóképességgel rendelkeznek. A papírpehely kiválóságát emellett még 99% pormentessége is alátámasztja, amiből adódóan viszont optimális a más anyagokból készült almokra allergiás vagy éppen frissen operált állatok számára. A papírpehely hozzájárul a kisállatok természetes fészek- és alagútépítő ösztönei szerinti viselkedésmódjához.",
                Material = "Papírpehely",
                Price = 2820,
                Avability = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/Bedding/dollyForgacs.png", UriKind.Relative)),
                Brand = "Gimbi",
                Name = "Rágcsáló alom",
                Volume = 4,
                Description = "A Gimbi rágcsáló alom préselt búzaszalma egy biológiailag lebomló, nagyon abszorbens, természetes alom. Azonnal megköti a folyadékokat és a szagokat, nem ragad sem a lábhoz, sem a szőrhöz a nagy nedvszívó képességének köszönhetően.  Törpe nyulaknak és kis rágcsálóknak, például hörcsögöknek, tengerimalacoknak, egereknek, csincsilláknak, degusoknak, gerbiineknek, patkányoknak stb. alkalmas.",
                Material = "Préselt búzaszalma",
                Price = 13190,
                Avability = true
            },
        };
        #endregion

        public List<Bedding> FindAll()
        {
            return _baddings;
        }

        public void Insert(Bedding bedding)
        {
            _baddings.Add(bedding);
        }

        public void Update(Bedding bedding)
        {
            if (!bedding.HasId)
            {
                Insert(bedding);
            }
            else
            {
                Bedding? beddingToUpdate = _baddings.FirstOrDefault(b => b.Id == bedding.Id);
                beddingToUpdate?.Set(bedding);
            }
        }

        public void Delete(Bedding bedding)
        {
            _baddings.Remove(bedding);
        }

        public void UploadImage(Bedding bedding)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp;*.jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                bedding.ImageSrc = new BitmapImage(new System.Uri(openDialog.FileName));
                Update(bedding);
            }
        }

        public int GetNumberOfBeddings()
        {
            return FindAll().Count();
        }
    }
}
