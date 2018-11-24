using System;
using System.Linq;
using ArmadilloLib;

namespace CoreConsoleApp
{
    using ArmadilloExtensions;
    class Program
    {
        static void Main(string[] args)
        {
            ArmadilloFarm myFarm = new ArmadilloFarm();

            myFarm.FarmAnimals.Add(new Armadillo()
            {
                Name = "Apple",
                Age = 18,
                ShellHardness = 5,
                IsPainted = true
            });

            myFarm.FarmAnimals.Add(new Armadillo()
            {
                Name = "Orange",
                Age = 22,
                ShellHardness = 8,
                IsPainted = false
            });

            myFarm.FarmAnimals.Add(new Armadillo()
            {
                Name = "Watermelon",
                Age = 33,
                ShellHardness = 20,
                IsPainted = false
            });

            myFarm.FarmAnimals.Add(new Armadillo()
            {
                Name = "Mangosteen",
                Age = 10,
                ShellHardness = 3,
                IsPainted = true
            });

            for (int i = 0; i < 30; i++)
            {
                myFarm.AddRandomAnimal();
            }

            foreach (Armadillo armadillo in myFarm.FarmAnimals)
            {
                System.Console.WriteLine($"My name is {armadillo?.Name ?? "Dead"} and I am {armadillo?.Age ?? 0} years old.");
            }

            var list = myFarm.FarmAnimals
                .Where(s => (s?.Age ?? 0) > 10)
                .OrderBy(s => s.Age)
                .Select(s => s.Name)
                .Aggregate((a, b) => a + "," + b);
            System.Console.WriteLine($"All armadillos that are older than 10 years old: {list}");

            list = myFarm.FarmAnimals
                .Where(s => (s?.Age ?? 0) < 5)
                .Where(s => (s?.IsPainted ?? false) == true)
                .OrderBy(s => s.Age)
                .Select(s => s.Name)
                .Aggregate((a, b) => a + "," + b);
            System.Console.WriteLine($"All armadillos that are younger than 5 and painted: {list}");
            
            list = myFarm.FarmAnimals
                .Where(s => (s?.ShellHardness ?? 0) > 7)
                .Where(s => (s?.Age ?? 0) > 13)
                .OrderBy(s => s.ShellHardness)
                .Select(s => s.Name)
                .Aggregate((a, b) => a + "," + b);
            System.Console.WriteLine($"All armadillos with a shell hardness of 7 or greater and age 13 or greater: {list}");
        
            var deadarmadillo = myFarm.FarmAnimals
            //.Where()
                //.Select(s => (s?.Name ?? "Dead"))
                //.Where(s => s == "Dead")
                //.ToList()
                .Count(s => s == null);
            System.Console.WriteLine($"# of dead armadillo: {deadarmadillo}");
        
        }
    }
}

namespace ArmadilloExtensions
{
    public static class ArmadilloExtension
    {
        public static void AddAnimal(this ArmadilloFarm farm, string name, int age, int shell_hardness, bool is_painted)
        {
            farm.FarmAnimals.Add(new Armadillo()
            {
                Name = name,
                Age = age,
                ShellHardness = shell_hardness,
                IsPainted = is_painted
            });
        }

        public static void AddRandomAnimal(this ArmadilloFarm farm)
        {
            string[] names = { "Raspberry", "Nectarine", "Kiwi", "Huckleberry",
                               "Satsuma", "Korrot", "Oggerel", "Xebejube", "Griomber",
                               "Nappiarrot", "TheEleventh", "Dead"};

            Random rand = new Random();
            int index = rand.Next(0, 12);

            if (index == 11)
            {
                farm.FarmAnimals.Add(null);
            }
            else
            {
                farm.FarmAnimals.Add(new Armadillo()
                {
                    Name = names[index],
                    Age = rand.Next(1, 21),
                    ShellHardness = rand.Next(1, 11),
                    IsPainted = Convert.ToBoolean(rand.Next(0, 2))
                });
            }
        }
    }
}