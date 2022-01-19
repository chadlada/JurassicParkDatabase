using System;
using System.Collections.Generic;

namespace JurassicParkDatabase
{
    class Program
    {
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
            Console.WriteLine(prompt);
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


        static void AddDinosaur()
        {
            Console.Clear();
            Console.WriteLine("Adding");
            Console.WriteLine("\n\nPress ENTER to return to exit and return to menu.");
            Console.ReadLine();
            Console.Clear();
        }
        static void RemoveDinosaur()
        {
            // Console.Clear();
            Console.WriteLine("Removing");
            // Console.ReadLine();
        }
        static void ViewDinosaur()
        {
        }
        static void TransferDinosaur()
        {
        }
        static void SummaryDiet()
        {
        }


        static void Main(string[] args)
        {
            Console.WriteLine();


            var dinoList = new List<Dinosaur>();

            var keepGoing = true;
            while (keepGoing)
            {
                Greeting();
                var choice = Menu();
                switch (choice)
                {
                    case "1":
                        // Console.WriteLine("Adding!");
                        AddDinosaur();

                        break;
                    case "2":
                        RemoveDinosaur();
                        break;
                    case "3":
                        ViewDinosaur();
                        break;
                    case "4":
                        TransferDinosaur();
                        break;
                    case "5":
                        SummaryDiet();
                        break;
                    case "6":
                        keepGoing = false;
                        break;


                }

            }

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
