using System.Collections.Generic;

namespace JurassicParkDatabase
{
    public class DinosaurDatabase
    {
        public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        public void AddDinosaur(Dinosaur newDinosaur)
        {
            Dinosaurs.Add(newDinosaur);
        }
    }
}