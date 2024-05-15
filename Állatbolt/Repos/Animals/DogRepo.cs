using AllatboltProject.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatboltProject.Repos
{
    public class DogRepo
    {
        #region Database
        private List<Dog> _dogs = new()
        {
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Bojti",
                BirthsDay = new DateTime(2017, 5, 12),
                Weigh = 12,
                Species = "bison",
                IsFemale = false,
                IsAvailable = true,
                Price = 200000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Kicsi",
                BirthsDay = new DateTime(2024, 2, 20),
                Weigh = 51,
                Species = "németjuhász",
                IsFemale = false,
                IsAvailable = true,
                Price = 100000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Marlin",
                BirthsDay = new DateTime(2021, 7, 14),
                Weigh = 38,
                Species = "labrador",
                IsFemale = false,
                IsAvailable = true,
                Price = 130000
            },
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Liza",
                BirthsDay = new DateTime(2012, 3, 4),
                Weigh = 8,
                Species = "tacskó",
                IsFemale = true,
                IsAvailable = false,
                Price = 32000
            }
        };
        #endregion

        public List<Dog> FindAll()
        {
            return _dogs;
        }

        public void Insert(Dog dog)
        {
            _dogs.Add(dog);
        }

        public void Update(Dog dog)
        {
            if (!dog.HasId)
            {
                Insert(dog);
            }
            else
            {
                Dog? dogToUpdate = _dogs.FirstOrDefault(s => s.Id == dog.Id);
                dogToUpdate?.Set(dog);
            }
        }

        public void Delete(Dog dog)
        {
            _dogs.Remove(dog);
        }

        public int GetNumberOfDogs()
        {
            return FindAll().Count();
        }

        public List<Dog> Filtering(string searchedSpecies, bool isGenderSearchingEnabled, bool isFemale)
        {
            List<Dog> dogs = FindAll();
            SearchBySpecies(ref dogs, searchedSpecies);
            SearchByGender(ref dogs, isGenderSearchingEnabled, isFemale);
            return dogs;
        }

        private void SearchBySpecies(ref List<Dog> dogs, string searchedSpecies)
        {
            if (searchedSpecies.Any())
            {
                dogs = dogs.Where(dog => dog.Species.ToLower().Contains(searchedSpecies.ToLower().Trim())).ToList();
            }
        }

        private void SearchByGender(ref List<Dog> dogs, bool isGenderSearchingEnabled, bool isFemale)
        {
            if (isGenderSearchingEnabled)
            {
                dogs = dogs.Where(dog => dog.IsFemale == isFemale).ToList();
            }
        }
    }
}
