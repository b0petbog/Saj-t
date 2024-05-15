using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AllatboltProject.Equipments
{
    public class Food
    {
        public Guid Id { get; set; }
        public bool HasId => Id != Guid.Empty;
        public ImageSource ImageSrc { get; set; }
        public string Brand {  get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public string Description { get; set; }
        public string Composition {  get; set; }
        public int Price { get; set; }
        public bool Avability { get; set; }
        public bool IsAvailable => Avability != false;

        public Food(Guid id, ImageSource imageSrc, string brand, string name, double volume, string description, string composition, int price, bool avability)
        {
            Id = id;
            ImageSrc = imageSrc;
            Brand = brand;
            Name = name;
            Volume = volume;
            Description = description;
            Composition = composition;
            Price = price;
            Avability = avability;
        }

        public Food()
        {
            Id = Guid.Empty;
            Brand = string.Empty;
            Name = string.Empty;
            Volume = 0;
            Description = string.Empty;
            Composition = string.Empty;
            Price = 0;
            Avability = false;
            ImageSrc = new BitmapImage(new Uri("/Image/default.png", UriKind.Relative));
        }

        public void Set(Food food)
        {
            Id = food.Id;
            ImageSrc = food.ImageSrc;
            Brand = food.Brand;
            Name = food.Name;
            Volume = food.Volume;
            Description = food.Description;
            Composition = food.Composition;
            Price = food.Price;
            Avability = food.Avability;
        }

        public override string ToString()
        {
            return $"{Brand}\t{Name}\t{Volume} kg\t{Price} Ft";
        }
    }
}
