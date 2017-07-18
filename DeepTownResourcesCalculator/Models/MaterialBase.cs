using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepTownResourcesCalculator.Models
{
    public class MaterialBase
    {
        public string Name { get; set; }

        public virtual Dictionary<MaterialBase, int> Requires { get; set; } = new Dictionary<MaterialBase, int>();

        public virtual int CoinValue { get; set; } = 0;

        public virtual TimeSpan TimeToCraft { get; set; } = TimeSpan.FromSeconds(0);

        public virtual int SumOfParts => Requires.Any() && Requires.Sum(d => d.Key.SumOfParts * d.Value) > 0
                                            ? Requires.Sum(d => d.Key.SumOfParts * d.Value)
                                            : CoinValue;

        public virtual TimeSpan SumToPartsToCraft => Requires.Any() && sumOfPartsInSeconds > 0
                                                        ? TimeSpan.FromSeconds(Requires.Sum(d => d.Key.SumToPartsToCraft.TotalSeconds * d.Value))
                                                        : TimeToCraft;


        double sumOfPartsInSeconds => Requires.Sum(d => d.Key.SumToPartsToCraft.TotalSeconds * d.Value);

    }


    public static class BaseResources
    {
        public static MaterialBase Coal = new MaterialBase { Name = "Coal", CoinValue = 1, TimeToCraft = TimeSpan.Zero };

        public static MaterialBase Amber = new MaterialBase { Name = "Amber", CoinValue = 4, TimeToCraft = TimeSpan.Zero };

        public static MaterialBase CopperOre = new MaterialBase { Name = "Copper Ore", CoinValue = 2, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase IronOre = new MaterialBase { Name = "Iron Ore", CoinValue = 3, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase AluminumOre = new MaterialBase { Name = "Alum. Ore", CoinValue = 5, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase SilverOre = new MaterialBase { Name = "Silver Ore", CoinValue = 7, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase GoldOre = new MaterialBase { Name = "Gold Ore", CoinValue = 10, TimeToCraft = TimeSpan.Zero };
        
        public static MaterialBase PlatinumOre = new MaterialBase { Name = "Platinum", CoinValue = 13, TimeToCraft = TimeSpan.Zero };

        public static MaterialBase Emerald = new MaterialBase { Name = "Emerald", CoinValue = 12, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase Topaz = new MaterialBase { Name = "Topaz", CoinValue = 14, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase Ruby = new MaterialBase { Name = "Ruby", CoinValue = 15, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase Sapphire = new MaterialBase { Name = "Sapphire", CoinValue = 16, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase Amethyst = new MaterialBase { Name = "Amethyst", CoinValue = 18, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase Diamond = new MaterialBase { Name = "Diamond", CoinValue = 18, TimeToCraft = TimeSpan.Zero };

        public static MaterialBase Sulfur = new MaterialBase { Name = "Sulfur", CoinValue = 100, TimeToCraft = TimeSpan.FromMinutes(2) };
        public static MaterialBase Silicon = new MaterialBase { Name = "Silicon", CoinValue = 100, TimeToCraft = TimeSpan.FromMinutes(2) };
        public static MaterialBase Sodium = new MaterialBase { Name = "Sodium", CoinValue = 100, TimeToCraft = TimeSpan.FromMinutes(2) };

        public static MaterialBase Water = new MaterialBase { Name = "Water", CoinValue = 5, TimeToCraft = TimeSpan.Zero };

        public static MaterialBase Oil = new MaterialBase { Name = "Oil", CoinValue = 21, TimeToCraft = TimeSpan.FromMinutes(3) };

        // 0:03

        public static MaterialBase Graphite = new MaterialBase
        {
            Name = "Graphite",
            CoinValue = 15,
            TimeToCraft = TimeSpan.FromSeconds(5),
            Requires =
            {
                [Coal] = 5
            }
        };

        public static MaterialBase CopperBar = new MaterialBase
        {
            Name = "CopperBar",
            CoinValue = 25,
            TimeToCraft = TimeSpan.FromSeconds(10),
            Requires =
            {
                [CopperOre] = 5
            }
        };

        public static MaterialBase IronBar = new MaterialBase
        {
            Name = "IronBar",
            CoinValue = 40,
            TimeToCraft = TimeSpan.FromSeconds(15),
            Requires =
            {
                [IronOre] = 5
            }
        };

        public static MaterialBase AluminumBar = new MaterialBase
        {
            Name = "AluminumBar",
            CoinValue = 50,
            TimeToCraft = TimeSpan.FromSeconds(15),
            Requires =
            {
                [AluminumOre] = 5
            }
        };

        public static MaterialBase SteelBar = new MaterialBase
        {
            Name = "SteelBar",
            CoinValue = 180,
            TimeToCraft = TimeSpan.FromSeconds(45),
            Requires =
            {
                [IronBar] = 1,
                [Graphite] = 1
            }
        };

        public static MaterialBase SilverBar = new MaterialBase
        {
            Name = "SilverBar",
            CoinValue = 200,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [SilverOre] = 5
            }
        };

        public static MaterialBase GoldBar = new MaterialBase
        {
            Name = "GoldBar",
            CoinValue = 250,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [GoldOre] = 5
            }
        };

        public static MaterialBase Glass = new MaterialBase
        {
            Name = "Glass",
            CoinValue = 450,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [Silicon] = 2
            }
        };





        public static MaterialBase Circuit = new MaterialBase
        {
            Name = "Circuit",
            CoinValue = 2070,
            TimeToCraft = TimeSpan.FromMinutes(3),
            Requires =
            {
                [IronBar] = 10,
                [Graphite] = 50,
                [CopperBar] = 20
            }
        };

        public static MaterialBase Motherboard = new MaterialBase
        {
            Name = "Motherboard",
            CoinValue = 2070,
            TimeToCraft = TimeSpan.FromMinutes(30),
            Requires =
            {
                [Circuit] = 3,
                [GoldBar] = 1,
                [Silicon] = 3
            }
        };


    }


}
