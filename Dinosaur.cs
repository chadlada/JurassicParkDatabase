using System;

namespace JurassicParkDatabase
{
    public class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; } = DateTime.Now;
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }
        public string Description()
        {
            return $"Name: {Name}\nAcquired: {WhenAcquired}\nEnclosure#: {EnclosureNumber}\nDiet Type: {DietType}\nWeight: {Weight}\n3";
        }


    }
}