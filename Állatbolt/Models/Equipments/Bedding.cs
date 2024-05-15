using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AllatboltProject.Equipments
{
    public class Bedding
    {
        public Guid Id { get; set; }
        public bool HasId => Id != Guid.Empty;
        public ImageSource ImageSrc { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public int Price { get; set; }
        public bool Avability { get; set; }
        public bool IsAvailable => Avability != false;

        public Bedding(Guid id, ImageSource imageSrc, string brand, string name, double volume, string description, string material, int price, bool avability)
        {
            Id = id;
            ImageSrc = imageSrc;
            Brand = brand;
            Name = name;
            Volume = volume;
            Description = description;
            Material = material;
            Price = price;
            Avability = avability;
        }

        public Bedding()
        {
            Id = Guid.Empty;
            Brand = string.Empty;
            Name = string.Empty;
            Volume = 0;
            Description = string.Empty;
            Material = string.Empty;
            Price = 0;
            Avability = false;
            ImageSrc = new BitmapImage(new Uri("/Image/default.png", UriKind.Relative));
        }

        public void Set(Bedding bedding)
        {
            Id = bedding.Id;
            ImageSrc = bedding.ImageSrc;
            Brand = bedding.Brand;
            Name = bedding.Name;
            Volume = bedding.Volume;
            Description = bedding.Description;
            Material = bedding.Material;
            Price = bedding.Price;
            Avability = bedding.Avability;
        }

        public override string ToString()
        {
            return $"{Brand}\t{Name}\t{Volume} kg\t{Price} Ft";
        }
    }
}
