using System;

namespace AllatboltProject.Animals
{
    public class Dog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthsDay { get; set; }
        public int Weigh { get; set; }
        public string Species { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsntAvailable => !IsAvailable;
        public int Price { get; set; }
        public bool HasId => Id != Guid.Empty;
        public bool IsFemale { get; set; }
        public bool IsMale => !IsFemale;

        public Dog(Guid id, string name, DateTime birthsday, int weigh, string species, bool isFemale, bool avability, int price)
        {
            Id = id;
            Name = name;
            BirthsDay = birthsday;
            Weigh = weigh;
            Species = species;
            IsFemale = isFemale;
            IsAvailable = avability;
            Price = price;
        }

        public Dog()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            BirthsDay = DateTime.UtcNow;
            Weigh = 50;
            Species = string.Empty;
            IsFemale = false;
            IsAvailable = false;
            Price = 0;
        }

        public void Set(Dog dog)
        {
            Id = dog.Id;
            Name = dog.Name;
            BirthsDay = dog.BirthsDay;
            Weigh = dog.Weigh;
            Species = dog.Species;
            IsFemale = dog.IsFemale;
            IsAvailable = dog.IsAvailable;
            Price = dog.Price;
        }

        public string Gender()
        {
            if (IsFemale == true)
            {
                return "szuka";
            }
            else
            {
                return "kan";
            }
        }

        public string Avability()
        {
            if (IsAvailable == true)
            {
                return "elérhető";
            }
            else
            {
                return "elkelt";
            }
        }

        public override string ToString()
        {
            return $"{Name}\t{String.Format("{0:yyyy.MM.dd.}", BirthsDay)}\t{Weigh}kg\t{Species}\t{Gender()}\t{Price} Ft\t{Avability()}";
        }
    }
}
