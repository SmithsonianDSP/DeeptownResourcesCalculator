using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Humanizer;

namespace DeepTownResourcesCalculator
{
    internal static class Program
    {
        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static void Main(string[] args)
        {

            bool quit = false;

            while (quit == false)
            {
                PrintMenuChoices();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Selection: ");
                Console.ForegroundColor = ConsoleColor.White;

                var selection = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine();

                switch (selection)
                {
                    case ConsoleKey.Escape:
                    case ConsoleKey.Q:
                        quit = true;
                        break;

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        HighestTotalCraftingTimeRequired();
                        PressAnyKeyToContinue();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        HighestSubcomponentCosts();
                        PressAnyKeyToContinue();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        HighestProfitMarginMaterials();
                        PressAnyKeyToContinue();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        HighestProfitToTimeRatio();
                        PressAnyKeyToContinue();
                        break;


                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That is not a valid option. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        break;
                }


            }
        }

        static void PrintMenuChoices()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Make a Selection:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=================");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\t[1]\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Longest Time To Craft Required Subcomponents\r\n");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\t[2]\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Most Expensive Subcomponents\r\n");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\t[3]\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Highest Profit Margins\r\n");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\t[4]\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Best Cost-to-Value Ratio\r\n");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\t[Q]\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Quit / Exit\r\n");
        }

        static void PressAnyKeyToContinue()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine();
        }


        static void HighestTotalCraftingTimeRequired()
        {
            Console.Clear();
            Console.WriteLine();

            var mats = Resources.AllMaterialsCollection;

            var longestToCraft = mats.OrderByDescending(m => m.SumOfPartsToCraft).Take(25);

            int x = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Top Crafting Time Required For Subcomponents:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var m in longestToCraft)
            {
                Console.WriteLine($"{x}:\t{m.Name.Humanize().PadRight(25)}{m.SumOfPartsToCraft.Humanize(precision: 5, maxUnit: Humanizer.Localisation.TimeUnit.Year, minUnit: Humanizer.Localisation.TimeUnit.Second)}");
                x++;
            }
        }

        static void HighestSubcomponentCosts()
        {
            Console.Clear();
            Console.WriteLine();

            var mats = Resources.AllMaterialsCollection;
            var highestPartsCost = mats.OrderByDescending(m => m.SumOfParts).Take(15);

            int x = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Highest Parts Cost Sum:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var m in highestPartsCost)
            {
                Console.WriteLine($"{x}:\t{m.Name.Humanize().PadRight(25)}{m.SumOfParts:N0}");
                x++;
            }
        }

        static void HighestProfitMarginMaterials()
        {
            Console.Clear();
            Console.WriteLine();

            var mats = Resources.AllMaterialsCollection;
            var mostProfit = mats.OrderByDescending(m => m.CoinValue - m.SumOfParts).Take(25);

            int x = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Most Profit? Items:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var m in mostProfit)
            {
                Console.WriteLine($"{x}:\t{m.Name.Humanize().PadRight(25)}{(m.CoinValue - (m.SumOfParts)):N0}");
                x++;
            }
        }


        static void HighestProfitToTimeRatio()
        {
            Console.Clear();
            Console.WriteLine();

            var mats = Resources.AllMaterialsCollection;
            var mostProfit = mats.OrderByDescending(m => m.ProfitToTimeRequiredRatio).Take(25);

            int x = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Best Profit to Time Required Materials:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    CPMSC == Coins Per Minute Spent Crafting");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("     (includes time spent on subcomponents)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            foreach (var m in mostProfit)
            {
                Console.WriteLine($"{x}:\t{m.Name.Humanize().PadRight(25)}{m.ProfitToTimeRequiredRatio.ToString("N2").PadLeft(7)} CPMSC");
                x++;
            }
        }

    }
}
