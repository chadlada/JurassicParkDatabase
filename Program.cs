using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicParkDatabase
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine();

            var dinosaurList = new List<Dinosaur>();
            // var database = new DinosaurDatabase();
            var keepGoing = true;
            while (keepGoing)
            {
                Greeting();
                var choice = Menu();
                switch (choice)
                {
                    case "1":
                        AddDinosaur(dinosaurList);
                        break;
                    case "2":
                        RemoveDinosaur(dinosaurList);
                        break;
                    case "3":
                        ViewAllDinosaurs(dinosaurList);

                        break;
                    case "4":
                        TransferDinosaur(dinosaurList);
                        break;
                    case "5":
                        DietSummary(dinosaurList);
                        break;
                    case "6":
                        keepGoing = false;
                        break;
                }
            }
        }

        private static void DietSummary(List<Dinosaur> dinosaurList)
        {
            // SummaryDiet
            Console.Clear();
            var numCarnivores = dinosaurList.Count(dino => dino.DietType == "C");
            var numHerbivores = dinosaurList.Count(dino => dino.DietType == "H");
            if (numCarnivores == 1)
            {
                Console.WriteLine($"Carnivore Count = {numCarnivores}");
            }
            else
            {
                Console.WriteLine($"Carnivore Count = {numCarnivores}");
            }
            if (numHerbivores == 1)
            {
                Console.WriteLine($"Herbivore Count = {numHerbivores}");
            }
            else
            {
                Console.WriteLine($"Herbivore Count = {numHerbivores}");
            }

            Console.WriteLine("\n\nPress ENTER to return to exit and return to menu.");
            Console.ReadLine();
            Console.Clear();
        }



        // -------------------------------------------------METHODS--------------------------------------------------------------------------




        static void Greeting()
        {
            Console.WriteLine("**************************Welcome to Jurassic Park**************************");
        }


        static string Menu()
        {
            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("1) Add Dinosaur");
            Console.WriteLine("2) Remove Dinosaur");
            Console.WriteLine("3) View Dinosaurs");
            Console.WriteLine("4) Transfer Dinosaur");
            Console.WriteLine("5) Summary of their diet types");
            Console.WriteLine("6) Quit");

            var choice = Console.ReadLine().ToUpper();
            return choice;
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = int.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Unacceptable..Default:0 ");
                return 0;
            }
        }


        private static void TransferDinosaur(List<Dinosaur> dinosaurList)
        {
            // TransferDinosaur
            Console.Clear();
            // ask for name of dino
            var dinoTransferName = PromptForString("Name of transfer dinosaur: ");
            // search for that dino
            Dinosaur dinoToTransfer = dinosaurList.FirstOrDefault(dino => dino.Name == dinoTransferName);

            if (dinoToTransfer == null)
            {
                // if null: prompt "doesn't exist"
                Console.WriteLine("That does not exist in database");
            }
            else
            {
                // if exists: prompt which enclosure to transfer to?
                var newEnclosureNumber = PromptForInteger("Enter new enclosure number: ");
                dinoToTransfer.EnclosureNumber = newEnclosureNumber;
                Console.WriteLine($"{dinoTransferName} has been transferred to enclosure {newEnclosureNumber}");

                Console.WriteLine("\n\nPress ENTER to return to exit and return to menu.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void RemoveDinosaur(List<Dinosaur> dinosaurList)
        {
            Console.Clear();
            // RemoveDinosaur
            // Ask for dinosaur name to remove
            var dinosaurNameToRemove = PromptForString("What is the name of the dinosaur you'd like to remove?: ");
            // Search for that name in list of dino
            Dinosaur dinosaurToRemove = dinosaurList.FirstOrDefault(dino => dino.Name == dinosaurNameToRemove);
            // if null: say there's no dinos of that name
            // else
            // if there is: remove dino. Tell user that it's been done.
            if (dinosaurToRemove == null)
            {
                Console.WriteLine($"There are no dinosaurs named {dinosaurNameToRemove} in the database.");
            }
            else
            {
                dinosaurList.Remove(dinosaurToRemove);
                Console.WriteLine($"{dinosaurNameToRemove} has been removed!");
                Console.WriteLine("\n\nPress ENTER to return to exit and return to menu.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void AddDinosaur(List<Dinosaur> dinosaurList)
        {
            Console.Clear();
            Console.WriteLine("Adding");
            var newDino = new Dinosaur();
            newDino.Name = PromptForString("Enter name of dinosaur: ");
            newDino.DietType = PromptForString("Diet Type - [C]arnivore or [H]erbivore: ");
            newDino.EnclosureNumber = PromptForInteger("Enclosure Number: ");
            newDino.Weight = PromptForInteger("Weight: ");
            dinosaurList.Add(newDino);

            Console.WriteLine($"{newDino.Name} has been added to the database!");
            Console.WriteLine("\n\nPress ENTER to return to exit and return to menu.");
            Console.ReadLine();
            Console.Clear();
        }


        private static void ViewAllDinosaurs(List<Dinosaur> dinosaurList)
        {
            // ViewDinosaur();
            Console.Clear();
            if (dinosaurList.Count > 0)
            {
                var byDateAcquired = dinosaurList.OrderBy(dino => dino.WhenAcquired);
                Console.WriteLine("Displaying all dinosaurs: \n");
                foreach (var dino in byDateAcquired)
                {
                    Console.WriteLine(dino.Description());
                }
            }
            else
            {
                Console.WriteLine("There are no dinosaurs in database.");
            }
            Console.WriteLine("\n\nPress ENTER to return to exit and return to menu.");
            Console.ReadLine();
            Console.Clear();
        }



    }
}

// * View
//     * This command will ask the user if they wish to see the dinosaurs in Name or EnclosureNumber order. Based on that choice, the list of dinosaurs should be shown in the correct order. If there no dinosaurs in the park, print out a special message to the user.
// * Add
//     * This command will let the user type in the information for a dinosaur and add it to the list. Prompt for the Name, Diet Type, Weight and Enclosure Number, but the WhenAcquired must be supplied by the code.
// * Remove
//     * This command will prompt the user for a dinosaur name then find and delete the dinosaur with that name.
// * Transfer
//     * This command will prompt the user for a dinosaur name and a new EnclosureNumber and update that dino's information.
// * Summary
//     * This command will display the number of carnivores and the number of herbivores.
// * Quit
//     * This will stop the program
