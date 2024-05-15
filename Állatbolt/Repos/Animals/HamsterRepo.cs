using System.Collections.Generic;
using System;
using AllatboltProject.Animals;
using System.Linq;

namespace AllatboltProject.Repos
{
    public class HamsterRepo
    {
        #region Database
        private List<Hamster> _hamsters = new()
        {
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Nugát",
                BirthsDay = new DateTime(2023, 8, 12),
                Weigh = 49,
                Species = "dzsungáriai törpehörcsög",
                IsFemale = false,
                IsAvailable = true,
                Price = 3000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Karamell",
                BirthsDay = new DateTime(2023, 6, 24),
                Weigh = 51,
                Species = "dzsungáriai törpehörcsög",
                IsFemale = true,
                IsAvailable = true,
                Price = 1500
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Szotyi",
                BirthsDay = new DateTime(2022, 4, 21),
                Weigh = 38,
                Species = "dzsungáriai törpehörcsög",
                IsFemale = true,
                IsAvailable = true,
                Price = 500
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Tollpihe",
                BirthsDay = new DateTime(2021, 9, 15),
                Weigh = 43,
                Species = "dzsungáriai törpehörcsög",
                IsFemale = false,
                IsAvailable = false,
                Price = 3000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Sztracsatella",
                BirthsDay = new DateTime(2020, 8, 22),
                Weigh = 46,
                Species = "dzsungáriai törpehörcsög",
                IsFemale = true,
                IsAvailable = true,
                Price = 500
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Kormi",
                BirthsDay = new DateTime(2019, 4, 6),
                Weigh = 43,
                Species = "dzsungáriai törpehörcsög",
                IsFemale = true,
                IsAvailable = true,
                Price = 500
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Bodza",
                BirthsDay = new DateTime(2018, 6, 24),
                Weigh = 56,
                Species = "dzsungáriai törpehörcsög",
                IsFemale = true,
                IsAvailable = false,
                Price = 500
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Hópihe",
                BirthsDay = new DateTime(2017, 10, 12),
                Weigh = 49,
                Species = "dzsungáriai törpehörcsög",
                IsFemale = false,
                IsAvailable = false,
                Price = 500
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Mogyi",
                BirthsDay = new DateTime(2015, 9, 7),
                Weigh = 53,
                Species = "dzsungáriai törpehörcsög",
                IsFemale = true,
                IsAvailable = false,
                Price = 1000
            }

        };
        #endregion

        public List<Hamster> FindAll()
        {
            return _hamsters;
        }

        public void Insert(Hamster hamster)
        {
            _hamsters.Add(hamster);
        }

        public void Update(Hamster hamster)
        {
            if (!hamster.HasId)
            {
                Insert(hamster);
            }
            else
            {
                Hamster? hamsterToUpdate = _hamsters.FirstOrDefault(s => s.Id == hamster.Id);
                hamsterToUpdate?.Set(hamster);
            }
        }

        public void Delete(Hamster hamster)
        {
            _hamsters.Remove(hamster);
        }

        public int GetNumberOfHamsters()
        {
            return FindAll().Count();
        }

        public List<Hamster> Filtering(string searchedSpecies, bool isGenderSearchingEnabled, bool isFemale, bool isAvabilitySearchingEnabled, bool isAvailable)
        {
            List<Hamster> hamsters = FindAll();
            SearchBySpecies(ref hamsters, searchedSpecies);
            SearchByGender(ref hamsters, isGenderSearchingEnabled, isFemale);
            SearchByAvability(ref hamsters, isAvabilitySearchingEnabled, isAvailable);
            return hamsters;
        }

        private void SearchBySpecies(ref List<Hamster> hamsters, string searchedSpecies)
        {
            if (searchedSpecies.Any())
            {
                hamsters = hamsters.Where(hamster => hamster.Species.ToLower().Contains(searchedSpecies.ToLower().Trim())).ToList();
            }
        }

        private void SearchByGender(ref List<Hamster> hamsters, bool isGenderSearchingEnabled, bool isFemale)
        {
            if (isGenderSearchingEnabled)
            {
                hamsters = hamsters.Where(hamster => hamster.IsFemale == isFemale).ToList();
            }
        }

        private void SearchByAvability(ref List<Hamster> hamsters, bool isAvabilitySearchingEnabled, bool isAvailable)
        {
            if (isAvabilitySearchingEnabled)
            {
                hamsters = hamsters.Where(hamster => hamster.IsAvailable == isAvailable).ToList();
            }
        }
    }
}
