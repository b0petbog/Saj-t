using System.Collections.Generic;
using System;
using AllatboltProject.Animals;
using System.Linq;

namespace AllatboltProject.Repos
{
    public class CatRepo
    {
        #region Database
        private List<Cat> _cats = new()
        {
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Maya",
                BirthsDay = new DateTime(2024, 3, 23),
                Weigh = 2,
                Species = "cornish rex",
                IsFemale = false,
                IsAvailable = true,
                Price = 2000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Arnold",
                BirthsDay = new DateTime(2024, 3, 11),
                Weigh = 5,
                Species = "bengáli",
                IsFemale = true,
                IsAvailable = true,
                Price = 1500
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Marlin",
                BirthsDay = new DateTime(2024, 1, 12),
                Weigh = 4,
                Species = "orosz kék",
                IsFemale = false,
                IsAvailable = true,
                Price = 3000
            }
        };
        #endregion

        public List<Cat> FindAll()
        {
            return _cats;
        }

        public void Insert(Cat cat)
        {
            _cats.Add(cat);
        }

        public void Update(Cat cat)
        {
            if (!cat.HasId)
            {
                Insert(cat);
            }
            else
            {
                Cat? catToUpdate = _cats.FirstOrDefault(s => s.Id == cat.Id);
                catToUpdate?.Set(cat);
            }
        }

        public void Delete(Cat cat)
        {
            _cats.Remove(cat);
        }

        public int GetNumberOfCats()
        {
            return FindAll().Count();
        }

        public List<Cat> Filtering(string searchedSpecies, bool isGenderSearchingEnabled, bool isFemale)
        {
            List<Cat> cats = FindAll();
            SearchBySpecies(ref cats, searchedSpecies);
            SearchByGender(ref cats, isGenderSearchingEnabled, isFemale);
            return cats;
        }

        private void SearchBySpecies(ref List<Cat> cats, string searchedSpecies)
        {
            if (searchedSpecies.Any())
            {
                cats = cats.Where(cat => cat.Species.ToLower().Contains(searchedSpecies.ToLower().Trim())).ToList();
            }
        }

        private void SearchByGender(ref List<Cat> cats, bool isGenderSearchingEnabled, bool isFemale)
        {
            if (isGenderSearchingEnabled)
            {
                cats = cats.Where(cat => cat.IsFemale == isFemale).ToList();
            }
        }
    }
}
