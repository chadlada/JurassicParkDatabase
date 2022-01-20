using System.Collections.Generic;

namespace JurassicParkDatabase
{
    public class DinosaurDatabase
    {
        private List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        public void AddDinosaur(Dinosaur newDinosaur)
        {
            Dinosaurs.Add(newDinosaur);
        }
    }
}