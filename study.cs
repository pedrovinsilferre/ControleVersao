// Alteração realizada por Antony

// Outra alteração realizada por Antony

//Alteração realizada por Pedro Ferreira 

//Outra alteração feita por Pedro Ferreira 

using System;
using System.Collections.Generic;

namespace Program
{
    // Define a base class
    public abstract class Animal
    {
        public string Name { get; set; }
        public abstract void MakeSound();
    }

    // Define derived classes
    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }

    // Define a generic class
    public class Zoo<T> where T : Animal
    {
        private List<T> animals;

        public Zoo()
        {
            animals = new List<T>();
        }

        public void AddAnimal(T animal)
        {
            animals.Add(animal);
        }

        public void ListAnimals()
        {
            foreach (T animal in animals)
            {
                Console.WriteLine(animal.Name);
                animal.MakeSound();
            }
        }

        public IEnumerable<T> GetAnimals()
        {
            return animals;
        }
    }

    // Define a delegate
    public delegate void AnimalHandler<T>(T animal);

    public class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Zoo class
            Zoo<Animal> zoo = new Zoo<Animal>();

            // Create some animal objects
            Dog dog1 = new Dog { Name = "Buddy" };
            Dog dog2 = new Dog { Name = "Max" };
            Cat cat1 = new Cat { Name = "Whiskers" };

            // Add animals to the zoo
            zoo.AddAnimal(dog1);
            zoo.AddAnimal(dog2);
            zoo.AddAnimal(cat1);

            // List animals in the zoo
            zoo.ListAnimals();

            // Use delegate to perform an action on each animal
            AnimalHandler<Animal> animalHandler = (animal) =>
            {
                Console.WriteLine("Feeding: " + animal.Name);
            };

            foreach (Animal animal in zoo.GetAnimals())
            {
                animalHandler(animal);
            }
        }
    }
}