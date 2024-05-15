using AllatboltProject.Animals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllatboltProject.Repos
{
    public class HorseRepo
    {
        #region Database
        private List<Horse> _horses = new()
        {
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Denisz",
                BirthsDay = System.DateTime.Now,
                Weigh = 600,
                Species = "angol telivér",
                IsFemale = false,
                IsAvailable = false,
                Price = 700000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Kira",
                BirthsDay = System.DateTime.Now,
                Weigh = 650,
                Species = "ismeretlen",
                IsFemale = true,
                IsAvailable = true,
                Price = 800000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Dáma", 
                BirthsDay = System.DateTime.Now, 
                Weigh = 750, 
                Species = "ismeretlen", 
                IsFemale = true, 
                IsAvailable = true, 
                Price = 650000
            }, 
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Zselyke", 
                BirthsDay = System.DateTime.Now, 
                Weigh = 650, 
                Species = "ismeretlen", 
                IsFemale = true, 
                IsAvailable = true, 
                Price = 600000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Frézia", 
                BirthsDay = System.DateTime.Now, 
                Weigh = 800, 
                Species = "ismeretlen", 
                IsFemale = true, 
                IsAvailable = true, 
                Price = 1200000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Smaragd",
                BirthsDay = System.DateTime.Now,
                Weigh = 600,
                Species = "furioso-north star",
                IsFemale = true,
                IsAvailable = true,
                Price = 700000
            }, 
            new() 
            {
                Id = Guid.NewGuid(),
                Name = "Kalota", 
                BirthsDay = System.DateTime.Now, 
                Weigh = 500, 
                Species = "hucul", 
                IsFemale = true, 
                IsAvailable = true, 
                Price = 600000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Hajnal", 
                BirthsDay = System.DateTime.Now, 
                Weigh = 500, 
                Species = "hucul", 
                IsFemale = true, 
                IsAvailable = true, 
                Price = 600000
            }
        };
        #endregion

        public List<Horse> FindAll()
        {
            return _horses;
        }

        public void Insert(Horse horse)
        {
            _horses.Add(horse);
        }

        public void Update(Horse horse)
        {
            if (!horse.HasId)
            {
                Insert(horse);
            }
            else
            {
                Horse? horseToUpdate = _horses.FirstOrDefault(s => s.Id == horse.Id);
                horseToUpdate?.Set(horse);
            }
        }

        public void Delete(Horse horse)
        {
            _horses.Remove(horse);
        }

        public int GetNumberOfHorses()
        {
            return FindAll().Count();
        }

        public List<Horse> Filtering(string searchedSpecies, bool isGenderSearchingEnabled, bool isFemale)
        {
            List<Horse> horses = FindAll();
            SearchBySpecies(ref horses, searchedSpecies);
            SearchByGender(ref horses, isGenderSearchingEnabled, isFemale);
            return horses;
        }

        private void SearchBySpecies(ref List<Horse> horses, string searchedSpecies)
        {
            if (searchedSpecies.Any())
            {
                horses = horses.Where(horse => horse.Species.ToLower().Contains(searchedSpecies.ToLower().Trim())).ToList();
            }
        }

        private void SearchByGender(ref List<Horse> horses, bool isGenderSearchingEnabled, bool isFemale)
        {
            if (isGenderSearchingEnabled)
            {
                horses = horses.Where(horse => horse.IsFemale == isFemale).ToList();
            }
        }
    }
}
