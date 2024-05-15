using System.Collections.Generic;
using System;
using AllatboltProject.Animals;
using System.Linq;

namespace AllatboltProject.Repos
{
    public class BunnyRepo
    {
        #region Database
        private List<Bunny> _bunnies = new()
        {
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Tapsi",
                BirthsDay = new DateTime(2034, 2, 12),
                Weigh = 6,
                Species = "német tarka óriás",
                IsFemale = false,
                IsAvailable = true,
                Price = 34000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Törpi",
                BirthsDay = new DateTime(2024, 1, 23),
                Weigh = 5,
                Species = "holland nyúl",
                IsFemale = false,
                IsAvailable = true,
                Price = 12000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Folti",
                BirthsDay = new DateTime(2024, 4, 2),
                Weigh = 2,
                Species = "mecklenburgi tarka",
                IsFemale = true,
                IsAvailable = false,
                Price = 40000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Pistike",
                BirthsDay = new DateTime(2024, 2, 9),
                Weigh = 1,
                Species = "világos nagyezüst",
                IsFemale = true,
                IsAvailable = true,
                Price = 22000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Dreher",
                BirthsDay = new DateTime(2024, 1, 14),
                Weigh = 6,
                Species = "német kosorrú",
                IsFemale = true,
                IsAvailable = true,
                Price = 10000
            }
        };
        #endregion

        public List<Bunny> FindAll()
        {
            return _bunnies;
        }

        public void Insert(Bunny bunny)
        {
            _bunnies.Add(bunny);
        }

        public void Update(Bunny bunny)
        {
            if (!bunny.HasId)
            {
                Insert(bunny);
            }
            else
            {
                Bunny? bunnyToUpdate = _bunnies.FirstOrDefault(b => b.Id == bunny.Id);
                bunnyToUpdate?.Set(bunny);
            }
        }

        public void Delete(Bunny bunny)
        {
            _bunnies.Remove(bunny);
        }

        public int GetNumberOfBunnies()
        {
            return FindAll().Count();
        }

        public List<Bunny> Filtering(string searchedSpecies, bool isGenderSearchingEnabled, bool isFemale)
        {
            List<Bunny> bunnies = FindAll();
            SearchBySpecies(ref bunnies, searchedSpecies);
            SearchByGender(ref bunnies, isGenderSearchingEnabled, isFemale);
            return bunnies;
        }

        private void SearchBySpecies(ref List<Bunny> bunnies, string searchedSpecies)
        {
            if (searchedSpecies.Any())
            {
                bunnies = bunnies.Where(bunny => bunny.Species.ToLower().Contains(searchedSpecies.ToLower().Trim())).ToList();
            }
        }

        private void SearchByGender(ref List<Bunny> bunnies, bool isGenderSearchingEnabled, bool isFemale)
        {
            if (isGenderSearchingEnabled)
            {
                bunnies = bunnies.Where(bunny => bunny.IsFemale == isFemale).ToList();
            }
        }
    }
}
