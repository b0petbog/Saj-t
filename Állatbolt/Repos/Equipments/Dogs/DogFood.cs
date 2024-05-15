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
    public class DogFoodRepo
    {
        #region Database
        private List<Food> _foods = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/DogFood/panziRegularDogFood.png", UriKind.Relative)),
                Brand = "Panzi",
                Name = "Regular száraz kutyaeledel adult bárány&rizs",
                Volume = 10,
                Description = "A Panzi Dog Adult kutyaeledel az átlagos aktivitású házőrző és hobbikutyák rendszeres táplálására kifejlesztett, extrudált kutyaeledel. Élettanilag optimálisan beállított arányban tartalmazza az összes olyan tápanyagot, ásványi elemet és vitamint, amely a kutyák harmonikus fejlődéséhez szükséges.\r\nHa a Panzi Dog Adult kutyaeledelt választja, biztos lehet abban, hogy kedvence táplálékával mindenhez hozzájut, amire jó kondíciójához, egészsége megőrzéséhez szüksége van. Az eledel magas biológiai értéke miatt könnyen, tökéletesen emészthető.",
                Composition = "Szárazanyag 90 %, Nyersfehérje 20 %, Nyerszsír 10,8 %, Nyersrost 3%, Nyershamu 7,5 %, A vitamin (E672), 2 736 NE/kg, D3 vitamin (E671)240 NE/kg, E vitamin (alfa-tokoferol, E307) 14 mg/kg",
                Price = 5299,
                Avability = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/DogFood/panziFitActiveDogFood.png", UriKind.Relative)),
                Brand = "Panzi",
                Name = "FitActive kutya konzerv marha&máj&bárány",
                Volume = 1.24,
                Description = "Az ízek varázsa kedvenceink örömére. A változatos fehérjeforrás minden szempontból fontos és hasznos kutyáink számára. Ezt a FitActive terméket úgy alakították ki, hogy a könnyen emészthető „testes” húsok ideális kombinációja (MARHA, BÁRÁNY) mellett a kutyák által igen kedvelt könnyen emészthető magas vastartalmú MARHAMÁJ is belekerült.\r\nA termék minimum 32%-os hústartalma garantálja kedvence laktató ízletes vacsoráját.\r\nA megfelelő vitaminszintekkel ellátott eledel. A kiváló minőségű természetes alapanyagoknak köszönhetően, a termék tartalmaz minden olyan összetevőt, mely kedvenceink egészséges mindennapjaihoz szükségesek. A gyümölcs, mint természetes forrású vitaminforrás igen hasznos kutyáink mindennapi táplálása során.\r\nFitActive – BURSTIN’ OUT – Kirobbanó formába hoz!",
                Composition = "Hús és állati alapanyagok (vegyeshús 20%, marhahús 4%, marhamáj 4 %, bárány 4%), teljes kiőrlésű gabona, alma 4%, ásványi anyagok.",
                Price = 1890,
                Avability = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/DogFood/briantosDogFood.png", UriKind.Relative)),
                Brand = "Briantos",
                Name = "száraztáp",
                Volume = 14,
                Description = "A Briantos kiegyensúlyozott és magas fokon emészthető prémium száraz kutyatáp. A Briantos eledeleket tapasztalt táplálkozásszakértők fejlesztették ki a tudomány jelenlegi állása szerint, és tartalmaznak minden olyan vitamint és tápanyagot, amelyekre kutyájának hosszú és vitalitással teli életéhez szüksége van. A Briantos gondosan válogatott összetevőket tartalmaz, nagyon jó emészthetőség jellemzi, és hozzájárul a kutya kiegyensúlyozott táplálásához. Esszenciális zsírsavai pozitívan hatnak kutyája bőrére és szőrzetére. Emellett ez az egyedi eledel kitűnik nagyon jó emészthetőségével és magas elfogadási arányával, ezért nagyszerűen alkalmas érzékenyebb kutyáknak is.",
                Composition  = "ismeretlen",
                Price = 8190,
                Avability = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                ImageSrc = new BitmapImage(new Uri("/Image/DogFood/pedigreeAdultDryFoodFood.png", UriKind.Relative)),
                Brand = "Pedigree",
                Name = "száraz kutyaeledel medium marha&szárnyas",
                Volume = 7,
                Description = "A Pedigree teljes értékű és kiegyensúlyozott száraz kutyaeledel mindennapi fogyasztásra.\r\nA Waltham kisállat-táplálkozási kutatóközpont táplálkozástani szakemberei és állatorvosai segítségével kifejlesztett Pedigree Száraz kutyaeledel rendelkezik minden alapvető tápanyaggal, amely támogatja az optimális emésztést, egészséges bőrt és szőrzetet, a természetes ellenállóképességet és a fogak védelmét. Az ételdarabkák különleges állaga segíti a felnőtt kutyák fogainak a tisztítását és támogatja a fogak védelmét, ezért ideális kiegészítője a mindennapos fogápolásnak.",
                Composition = "Összetétel: válogatott gabonafélék*, hús és állati származékok (19%, ebből 4% marha a vörösesbarna szemcsékben, 4% baromfi a barna szemcsékben**), növényi eredetű származékok (ebből szárított répapép 3%*), olajok és zsírok (ebből napraforgóolaj 0.4%), ásványi anyagok.",
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
