using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AllatboltProject.Equipments
{
    public class Cage
    {
        public Guid Id { get; set; }
        public bool HasId => Id != Guid.Empty;
        public ImageSource ImageSrc { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Animal { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Avability { get; set; }
        public bool IsAvailable => Avability != false;

        public Cage(Guid id, ImageSource imageSrc, string brand, string name, string animal, string size, string description, int price, bool avability)
        {
            Id = id;
            ImageSrc = imageSrc;
            Brand = brand;
            Name = name;
            Animal = animal;
            Size = size;
            Description = description;
            Price = price;
            Avability = avability;
        }

        public Cage()
        {
            Id = Guid.Empty;
            Brand = string.Empty;
            Name = string.Empty;
            Animal = string.Empty;
            Size = "0 x 0 x 0 cm";
            Description = string.Empty;
            Price = 0;
            Avability = false;
            ImageSrc = new BitmapImage(new Uri("/Image/default.png", UriKind.Relative));
        }

        public void Set(Cage cage)
        {
            Id = cage.Id;
            ImageSrc = cage.ImageSrc;
            Brand = cage.Brand;
            Name = cage.Name;
            Animal = cage.Animal;
            Size = cage.Size;
            Description = cage.Description;
            Price = cage.Price;
            Avability = cage.Avability;
        }

        public override string ToString()
        {
            return $"{Brand}\t{Name}\t{Size}\t{Price} Ft";
        }
    }
}
