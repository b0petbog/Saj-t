using System.Collections.Generic;
using System;
using AllatboltProject.Animals;
using System.Linq;

namespace AllatboltProject.Repos
{
    public class GiraffeRepo
    {
        #region Database
        private List<Giraffe> _giraffes = new()
        {
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Nyakas",
                BirthsDay = new DateTime(2023, 4, 12),
                Weigh = 400,
                Species = "déli zsiráf",
                IsFemale = true,
                IsAvailable = true,
                Price = 430000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Kockás",
                BirthsDay = new DateTime(2022, 12, 4),
                Weigh = 200,
                Species = "kockás zsiráf",
                IsFemale = true,
                IsAvailable = true,
                Price = 30000
            }
        };
        #endregion

        public List<Giraffe> FindAll()
        {
            return _giraffes;
        }

        public void Insert(Giraffe giraffe)
        {
            _giraffes.Add(giraffe);
        }

        public void Update(Giraffe giraffe)
        {
            if (!giraffe.HasId)
            {
                Insert(giraffe);
            }
            else
            {
                Giraffe? giraffeToUpdate = _giraffes.FirstOrDefault(g => g.Id == giraffe.Id);
                giraffeToUpdate?.Set(giraffe);
            }
        }

        public void Delete(Giraffe giraffe)
        {
            _giraffes.Remove(giraffe);
        }

        public int GetNumberOfGiraffes()
        {
            return FindAll().Count();
        }

        public List<Giraffe> Filtering(string searchedSpecies, bool isGenderSearchingEnabled, bool isFemale)
        {
            List<Giraffe> giraffes = FindAll();
            SearchBySpecies(ref giraffes, searchedSpecies);
            SearchByGender(ref giraffes, isGenderSearchingEnabled, isFemale);
            return giraffes;
        }

        private void SearchBySpecies(ref List<Giraffe> giraffes, string searchedSpecies)
        {
            if (searchedSpecies.Any())
            {
                giraffes = giraffes.Where(giraffe => giraffe.Species.ToLower().Contains(searchedSpecies.ToLower().Trim())).ToList();
            }
        }

        private void SearchByGender(ref List<Giraffe> giraffes, bool isGenderSearchingEnabled, bool isFemale)
        {
            if (isGenderSearchingEnabled)
            {
                giraffes = giraffes.Where(giraffe => giraffe.IsFemale == isFemale).ToList();
            }
        }
    }
}
