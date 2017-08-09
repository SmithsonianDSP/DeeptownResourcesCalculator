#region license header
//  DeepTownResourcesCalculator - Statistical Analysis of Game Resources
//      Code Copyright (C) 2017    -    SmithsonianDSP
// 
//     Deep Town (c) is the property of Rockbite Games and is unaffiliated 
//     with this program. 
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Humanizer;
using Humanizer.Localisation;

namespace DeepTownResourcesCalculator
{
    internal static class Program
    {
        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static void Main(string[] args)
        {
            var quit = false;

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

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        IndividualTimeRequiredAtMaxRequest();
                        PressAnyKeyToContinue();
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        IndividualValueAtMaxRequest();
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
            Console.Write("Best Time-to-Value Ratio\r\n");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\t[5]\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Individual Time Required @ Max Request (5,000)\r\n");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\t[6]\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Resource Value @ Max Request (5,000)\r\n");
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

        /// <summary>
        ///     [1]
        /// </summary>
        static void HighestTotalCraftingTimeRequired()
        {
            Console.Clear();
            Console.WriteLine();

            var mats = Resources.AllResourcesCollection;

            var longestToCraft = mats.Where(m => m.TotalTimeToProduce > TimeSpan.Zero)
                                     .OrderByDescending(m => m.TotalTimeToProduce);

            var x = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Top Crafting Time Required For Subcomponents:");
            Console.ForegroundColor = ConsoleColor.White;

            WriteThreeColumnTableHeader("Production Time Req'd", false);

            foreach (var m in longestToCraft)
            {
                WriteThreeColumnLine(x.ToString(), m.PrettyName, m.TotalTimeToProduce.Humanize(5, maxUnit: TimeUnit.Day, minUnit: TimeUnit.Second));
                x++;
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     [2]
        /// </summary>
        static void HighestSubcomponentCosts()
        {
            Console.Clear();
            Console.WriteLine();

            var mats = Resources.AllResourcesCollection;
            var highestPartsCost = mats.Where(m => m.SumOfSubcomponentValues > 0)
                                       .OrderByDescending(m => m.SumOfSubcomponentValues)
                                       .ThenBy(m => m.Name);

            var x = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Highest Parts Cost Sum:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            WriteThreeColumnTableHeader("Value");
            foreach (var m in highestPartsCost)
            {
                var toStringFormat = m.SumOfSubcomponentValues > 1
                                                ? "N0"
                                                : "N1";

                var leftPadding = m.SumOfSubcomponentValues > 1
                                                ? 8
                                                : 10;

                WriteThreeColumnLine(x.ToString(), m.PrettyName, m.SumOfSubcomponentValues.ToString(toStringFormat).PadLeft(leftPadding));
                x++;
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     [3]
        /// </summary>
        static void HighestProfitMarginMaterials()
        {
            Console.Clear();
            Console.WriteLine();

            var mats = Resources.AllResourcesCollection;
            var mostProfit = mats.Where(m => m.ProfitMargin >= 1)
                                 .Where(m => Math.Abs(m.ProfitMargin - m.CoinValue) > 0.1)
                                 .OrderByDescending(m => m.ProfitMargin)
                                 .ThenBy(m => m.Name);

            var faceValue = mats.Where(m => Math.Abs(m.ProfitMargin - m.CoinValue) < 0.1)
                                .OrderByDescending(m => m.ProfitMargin)
                                .ThenBy(m => m.Name);

            var noProfit = mats.Where(m => m.ProfitMargin < 1)
                               .OrderBy(m => m.Name);

            var x = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Most Profit Items (item value vs. sum of subcomponent values):");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            WriteThreeColumnTableHeader("Profit Margin");

            foreach (var m in mostProfit)
            {
                WriteThreeColumnLine(x.ToString(), m.PrettyName, m.ProfitMargin.ToString("N0"));
                x++;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Zero Cost (all profit):");
            Console.ForegroundColor = ConsoleColor.White;

            WriteNoHeaderTable(faceValue);
            Console.WriteLine();


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Zero Values:");
            Console.ForegroundColor = ConsoleColor.White;

            WriteNoHeaderTable(noProfit);
            Console.WriteLine();
        }

        /// <summary>
        ///     [4]
        /// </summary>
        static void HighestProfitToTimeRatio()
        {
            Console.Clear();
            Console.WriteLine();

            var mats = Resources.AllResourcesCollection;
            var mostProfit = mats.Where(m => m.ProfitToTimeRequiredRatio >= 1)
                                 .OrderByDescending(m => m.ProfitToTimeRequiredRatio)
                                 .ThenBy(m => m.Name);

            var noProfit = mats.Where(m => m.ProfitToTimeRequiredRatio < 1)
                               .OrderBy(m => m.Name);

            var x = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Best \"Profit to Total Production Time\" Materials:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    CPMSC == Coins Per Minute Spent Crafting");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("     (includes time spent on subcomponents)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            WriteThreeColumnTableHeader("CPMSC");

            foreach (var m in mostProfit)
            {
                WriteThreeColumnLine(x.ToString(), m.PrettyName, m.ProfitToTimeRequiredRatio.ToString("N2").PadLeft(7) + " CPMSC");
                x++;
            }

            Console.WriteLine();

            if (noProfit.Any())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Zero Values:");
                Console.ForegroundColor = ConsoleColor.White;

                WriteNoHeaderTable(noProfit);
            }
            Console.WriteLine();
        }

        /// <summary>
        ///     [5]     How much time it would take to produce 5,000 of each material (not including sub-compontent crafting time)
        /// </summary>
        static void IndividualTimeRequiredAtMaxRequest()
        {
            Console.Clear();
            Console.WriteLine();

            var mats = Resources.AllResourcesCollection;
            var mostProfit = mats.OrderByDescending(m => m.TimeToProduce.TotalSeconds * 5000)
                                 .ThenBy(m => m.Name);

            var x = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   Time to Produce 5,000 of each resource:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("     (does not include subcomponents)");
            Console.ForegroundColor = ConsoleColor.White;

            WriteThreeColumnTableHeader("Total Production Time", false);
            foreach (var m in mostProfit)
            {
                WriteThreeColumnLine(x.ToString(), m.PrettyName, TimeSpan.FromSeconds(m.TimeToProduce.TotalSeconds * 5000).Humanize(5, maxUnit: TimeUnit.Day, minUnit: TimeUnit.Minute));
                x++;
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     [6]     The total coin value for 5,000 of each material (not including sub-components)
        /// </summary>
        static void IndividualValueAtMaxRequest()
        {
            Console.Clear();
            Console.WriteLine();

            var mats = Resources.AllResourcesCollection;
            var mostProfit = mats.OrderByDescending(m => m.CoinValue * 5000)
                                 .ThenBy(m => m.Name);

            var x = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   Coin value for 5,000 of each resource:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("     (does not include subcomponents)");
            Console.ForegroundColor = ConsoleColor.White;
            WriteThreeColumnTableHeader("Value per 5,000");

            foreach (var m in mostProfit)
            {
                WriteThreeColumnLine(x.ToString(), m.PrettyName, (m.CoinValue * 5000).ToString("N0"));
                x++;
            }

            Console.WriteLine();
        }




        static void WriteThreeColumnLine(string arg1, string arg2, string arg3)
        {
            WriteVerticalBar();
            Console.Write(arg1.PadRight(5));

            WriteVerticalBar();
            Console.Write(arg2.PadRight(25));

            WriteVerticalBar();
            Console.Write(arg3.PadRight(40));

            WriteVerticalBar();
            Console.WriteLine();
        }

        static void WriteThreeColumnTableHeader(string column3Title, bool rightAlignColumn3 = true)
        {
            WriteThreeColumnLine("**#**", "**Resource**", $"**{column3Title}**");

            const string arg1 = "| ----:";
            const string arg2 = "|------------------";
            const string arg3A = "|--------------------------------";
            const string arg3B = "|-------------------------------:";

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(arg1.PadRight(7));
            Console.Write(arg2.PadRight(27));
            Console.Write(rightAlignColumn3 ? arg3B.PadRight(42) : arg3A.PadRight(42));
            Console.WriteLine("|");
        }

        static void WriteVerticalBar()
        {
            const string vert = "| ";

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(vert);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void WriteNoHeaderTable(IOrderedEnumerable<ResourceBaseModel> items)
        {
            var num = items.Count();
            var cols = FigureColumnCount(num);

            var padWidth = items.Max(r => r.PrettyName.Length) + 2;

            CreateNoHeaderTableHeader(cols, padWidth);


            var itemStack = new Stack<ResourceBaseModel>(items);


            while (itemStack.Count > 0)
            {
                for (var i = 0; i < cols; i++)
                {
                    WriteVerticalBar();

                    var m = itemStack.Count > 0
                                ? itemStack.Pop().PrettyName
                                : string.Empty;

                    Console.Write(m.PadRight(padWidth));

                }

                WriteVerticalBar();
                Console.WriteLine();
            }


            void CreateNoHeaderTableHeader(int columns, int length)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Create empty header row
                for (var i = 0; i < columns; i++)
                {
                    Console.Write("|");
                    Console.Write(new string(' ', length + 1));
                }
                Console.WriteLine("|");

                for (var i = 0; i < columns; i++)
                {
                    Console.Write("|");
                    Console.Write(new string('-', length + 1));
                }
                Console.WriteLine("|");

            }


        }

        /// <summary>
        ///     Determines the number of columns that should be created based on the
        ///     number of items. Tries to find best-fit width.
        /// </summary>
        /// <param name="num">Number of items for the table</param>
        /// <returns>The number of columns that the table should have</returns>
        static int FigureColumnCount(int num)
        {
            if (num <= 5)
                return num;

            var altColumns = 7;
            var altOddballs = num % 7;

            for (var i = 7 - 1; i >= 3; i--)
            {
                var oddballs = num % i;
                if (oddballs == 0)
                    return i;

                if (oddballs > altOddballs)
                    altColumns = i;
            }

            return altColumns;
        }


    }
}