namespace AnimalWars.Models
{
    public class AnimalWar
    {
        public Category Category { get; set; }
        public Animal AnimalOne { get; set; }
        public Animal AnimalTwo { get; set; }
    }

    public class Animal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
        public int Votes { get; set; }
    }

    public enum Category
    {
        Land,
        Sea,
        Flying,
        Imaginary
    }
}