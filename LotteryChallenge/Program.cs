// See https://aka.ms/new-console-template for more information
using LotteryChallenge.Logic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace LotteryChallenge
{
    public class Program
    {
        ///*
        ///--------Task--------
        /// - Simple lottery generator
        /// 
        ///     - Generate 6 unique random numbers 
        ///     - Each number should be within 1-49 inclusive
        ///     - The numbers should be presented within numberic order 
        ///     -
        ///     -    EXTRA
        ///     - The numbers should have different coloured backgrounds
        ///         - 1-9 Grey, 10-19 Blue, 20-29 Pink, 30-39 Green, 40-49 Yellow 
        ///     - Allow for adaptation for the number of balls to change e.g. 6 to 7
        /// 
        ///--------Further actions with more time--------
        ///     - I would have liked to seperate each method into it's own file
        ///     - Added unit testing
        ///     - Implement a design pattern to give the solution some structure.
        /// 
        /// 
        /// 
        /// *///

        static void Main(string[] args)
        {
            bool showMenu = true;

            // Continually show the menu system until returned not to
            while (showMenu)
            {
                showMenu = displayMenu();
            }
        }
        // Menu System
        private static bool displayMenu()
        {
            Console.WriteLine("------Lottery Challenege------");
            Console.WriteLine("Chose from the options below:");
            Console.WriteLine("1) Generate 6 Numbers");
            Console.WriteLine("2) Choose how many numbers to generate");
            Console.WriteLine("3) Exit");
            Console.WriteLine("4) Clear screen");

            string userInput = Console.ReadLine();

            // Attemps to process the users input and outputs it as an int
            if (!Int32.TryParse(userInput, out int menuInput))
            {
                Console.WriteLine($"Incorrect input \"{userInput}\", please try again");
                displayMenu();
            }

            // Filtering the users intput into the required options
            switch (menuInput)
            {
                case 0:
                    return true;
                case 1:
                    LotteryNumbers(6);
                    break;
                case 2:
                    Console.WriteLine("How many numbers would you like to generate?");
                    if (!Int32.TryParse(Console.ReadLine(), out int chosenNumber))
                    {
                        Console.WriteLine($"Incorrect input \"{userInput}\", please try again");
                        displayMenu();
                    }
                    LotteryNumbers(chosenNumber);
                    break;
                case 3:
                    return false;
                case 4:
                    Console.Clear();
                    break;
                default:
                    return true;
            }

            return true;
        }

        // Method to display the specified amount lottery numbers 
        private static void LotteryNumbers(int amountOfNumbers)
        {
            Console.WriteLine("\tLottery Numbers are:");

            List<int> lotteryNumbers = GenerateLotteryNumbers(amountOfNumbers);
            for (int i = 0; i < lotteryNumbers.Count(); i++)
            {
                ShowColouredNumber(lotteryNumbers[i]);
               // Console.Write($"{lotteryNumbers[i]}\t");
            }
            Console.WriteLine();

        }

        // Display the lottery numbers in their required colours
        private static void ShowColouredNumber(int lotteryNumber)
        {
            if (lotteryNumber >= 1 && lotteryNumber <= 9)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"{lotteryNumber}\t", Console.ForegroundColor);
            }
            else if (lotteryNumber >= 10 && lotteryNumber <= 19)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{lotteryNumber}\t", Console.ForegroundColor);
            }
            else if (lotteryNumber >= 20 && lotteryNumber <= 29)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{lotteryNumber}\t", Console.ForegroundColor);
            }
            else if (lotteryNumber >= 30 && lotteryNumber <= 39)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{lotteryNumber}\t", Console.ForegroundColor);
            }
            else if (lotteryNumber >= 40 && lotteryNumber <= 49)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{lotteryNumber}\t", Console.ForegroundColor);
            }

            //When the colour is no longer needed set colour back to default - gray
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Method looks to only add unique numbers to the list of lottery numbers
        private static  List<int> GenerateLotteryNumbers(int amountOfNumbers)
        {
            List<int> lotteryNumbers = new List<int>(amountOfNumbers);

            bool capacityReached = true;

            while (capacityReached)
            { 
                int number = GenerateNumber();
                
                if (!lotteryNumbers.Contains(number))
                {
                    lotteryNumbers.Add(number);
                }
                if (lotteryNumbers.Count() == amountOfNumbers)
                    capacityReached = false;
                
            }

            // Sort numbers into numeric order
            lotteryNumbers.Sort();

            return lotteryNumbers;
        }

        // Method to generate random number
        private static int GenerateNumber()
        {
            Random random = new Random();
            return random.Next(1, 50);
        }

    }

}



