using AllatboltProject.Animals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllatboltProject.Repos
{
    public class SnakeRepo
    {
        #region Database
        private List<Snake> _snakes = new()
        {
            new()
            {
                Id=Guid.NewGuid(),
                Name = "Kígyó",
                BirthsDay = System.DateTime.Now,
                Weigh = 2,
                Species = "királysikló",
                IsFemale = true,
                IsAvailable = true,
                Price = 25000
            }
        };
        #endregion

        public List<Snake> FindAll()
        {
            return _snakes;
        }

        public void Insert(Snake snake)
        {
            _snakes.Add(snake);
        }

        public void Update(Snake snake)
        {
            if (!snake.HasId)
            {
                Insert(snake);
            }
            else
            {
                Snake? snakeToUpdate = _snakes.FirstOrDefault(s => s.Id == snake.Id);
                snakeToUpdate?.Set(snake);
            }
        }

        public void Delete(Snake snake)
        {
            _snakes.Remove(snake);
        }

        public int GetNumberOfSnakes()
        {
            return FindAll().Count();
        }

        public List<Snake> Filtering(string searchedSpecies, bool isGenderSearchingEnabled, bool isFemale)
        {
            List<Snake> snakes = FindAll();
            SearchBySpecies(ref snakes, searchedSpecies);
            SearchByGender(ref snakes, isGenderSearchingEnabled, isFemale);
            return snakes;
        }

        private void SearchBySpecies(ref List<Snake> snakes, string searchedSpecies)
        {
            if (searchedSpecies.Any())
            {
                snakes = snakes.Where(snake => snake.Species.ToLower().Contains(searchedSpecies.ToLower().Trim())).ToList();
            }
        }

        private void SearchByGender(ref List<Snake> snakes, bool isGenderSearchingEnabled, bool isFemale)
        {
            if (isGenderSearchingEnabled)
            {
                snakes = snakes.Where(snake => snake.IsFemale == isFemale).ToList();
            }
        }
    }
}
