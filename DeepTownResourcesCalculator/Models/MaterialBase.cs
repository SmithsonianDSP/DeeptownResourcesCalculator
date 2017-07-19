using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace DeepTownResourcesCalculator
{
    public class MaterialBase
    {
        public string Name { get; set; }

        public virtual Dictionary<MaterialBase, double> Requires { get; } = new Dictionary<MaterialBase, double>();

        public virtual int CoinValue { get; set; } = 0;

        public virtual TimeSpan TimeToCraft { get; set; } = TimeSpan.FromSeconds(0);


        double _cachedSumOfParts;
        bool _isSumOfPartsCached;
        public virtual double SumOfParts
        {
            get
            {
                if (_isSumOfPartsCached)
                    return _cachedSumOfParts;

                _cachedSumOfParts = Requires.Any() && Requires.Sum(d => d.Key.SumOfParts * d.Value) > 0
                                        ? Requires.Sum(d => d.Key.SumOfParts * d.Value)
                                        : CoinValue;

                _isSumOfPartsCached = true;

                return _cachedSumOfParts;
            }
        }

        public virtual double TotalSumOfParts => SumOfParts + CoinValue;

        TimeSpan _cachedSumToPartsToCraft;
        bool _isSumOfPartsToCraftCached;

        /// <summary>
        ///     The length of time it takes to craft all required sub-components (and their sub-components) PLUS the <see cref="TimeToCraft"/> the material, itself
        /// </summary>
        public virtual TimeSpan SumOfPartsToCraft
        {
            get
            {
                if (_isSumOfPartsToCraftCached)
                    return _cachedSumToPartsToCraft;

                _cachedSumToPartsToCraft = Requires.Any() && sumOfPartsInSeconds > 0
                                               ? TimeSpan.FromSeconds(Requires.Sum(d => d.Key.TotalTimeToCraft.TotalSeconds * d.Value))
                                               : TimeToCraft;

                _isSumOfPartsToCraftCached = true;

                return _cachedSumToPartsToCraft;
            }
        }

        public virtual TimeSpan TotalTimeToCraft => SumOfPartsToCraft.Add(TimeToCraft);


        double sumOfPartsInSeconds => Requires.Sum(d => d.Key.SumOfPartsToCraft.TotalSeconds * d.Value);


        public double ProfitToTimeRequiredRatio => (CoinValue - SumOfParts) / TotalTimeToCraft.TotalMinutes;

    }


    public static class BaseResources
    {
        /// <summary>
        ///     This is the base rate of mining for a material that has a 100% resource mine location, assuming a Level 8 mine (17 RPM)
        /// </summary>
        static readonly TimeSpan BaseMineralWithMineRate = TimeSpan.FromSeconds(60D / 17D);

        /// <summary>
        ///     This is the mining rate for Iron Ore, which has no dedicated mines, and the max iron ore area is 30%
        /// </summary>
        static readonly TimeSpan BaseIronOreRate = TimeSpan.FromSeconds(60D / (17D * 0.30));

        static TimeSpan GetBaseRateFromMaxMinePercent(double maxPercent) => TimeSpan.FromSeconds(60D / (17D * maxPercent));


        #region Mineral Mine Resources
        public static MaterialBase Coal = new MaterialBase { Name = "Coal", CoinValue = 1, TimeToCraft = BaseMineralWithMineRate };
        public static MaterialBase Amber = new MaterialBase { Name = "Amber", CoinValue = 4, TimeToCraft = BaseMineralWithMineRate };
        public static MaterialBase CopperOre = new MaterialBase { Name = "CopperOre", CoinValue = 2, TimeToCraft = BaseMineralWithMineRate };
        public static MaterialBase IronOre = new MaterialBase { Name = "IronOre", CoinValue = 3, TimeToCraft = BaseIronOreRate };
        public static MaterialBase AluminumOre = new MaterialBase { Name = "AluminumOre", CoinValue = 5, TimeToCraft = BaseMineralWithMineRate };

        public static MaterialBase SilverOre = new MaterialBase { Name = "SilverOre", CoinValue = 7, TimeToCraft = GetBaseRateFromMaxMinePercent(0.55) };  // TODO: Verify Mining Rate

        public static MaterialBase GoldOre = new MaterialBase { Name = "GoldOre", CoinValue = 10, TimeToCraft = BaseMineralWithMineRate };

        public static MaterialBase PlatinumOre = new MaterialBase { Name = "Platinum", CoinValue = 13, TimeToCraft = GetBaseRateFromMaxMinePercent(0.035) }; // TODO: Verify Mining Rate
        #endregion

        #region Gem Resources
        public static MaterialBase Emerald = new MaterialBase { Name = "Emerald", CoinValue = 12, TimeToCraft = BaseMineralWithMineRate };
        public static MaterialBase Ruby = new MaterialBase { Name = "Ruby", CoinValue = 15, TimeToCraft = BaseMineralWithMineRate };

        public static MaterialBase Topaz = new MaterialBase { Name = "Topaz", CoinValue = 14, TimeToCraft = GetBaseRateFromMaxMinePercent(0.105) };         // TODO: Verify Mining Rate
        public static MaterialBase Sapphire = new MaterialBase { Name = "Sapphire", CoinValue = 16, TimeToCraft = GetBaseRateFromMaxMinePercent(0.30) };    // TODO: Verify Mining Rate
        public static MaterialBase Amethyst = new MaterialBase { Name = "Amethyst", CoinValue = 18, TimeToCraft = GetBaseRateFromMaxMinePercent(0.30) };    // TODO: Verify Mining Rate
        public static MaterialBase Diamond = new MaterialBase { Name = "Diamond", CoinValue = 18, TimeToCraft = GetBaseRateFromMaxMinePercent(0.18) };      // TODO: Verify Mining Rate
        #endregion

        #region Chemical Mine Resources
        public static MaterialBase Sulfur = new MaterialBase { Name = "Sulfur", CoinValue = 100, TimeToCraft = TimeSpan.FromMinutes(2) };
        public static MaterialBase Silicon = new MaterialBase { Name = "Silicon", CoinValue = 100, TimeToCraft = TimeSpan.FromMinutes(2) };
        public static MaterialBase Sodium = new MaterialBase { Name = "Sodium", CoinValue = 100, TimeToCraft = TimeSpan.FromMinutes(2) };
        #endregion
        #region Other Base Resources
        public static MaterialBase Water = new MaterialBase { Name = "Water", CoinValue = 5, TimeToCraft = TimeSpan.Zero };

        public static MaterialBase Oil = new MaterialBase { Name = "Oil", CoinValue = 21, TimeToCraft = TimeSpan.FromMinutes(3) };
        #endregion
        #region Greenhouse Seeds


        public static MaterialBase TreeSeed = new MaterialBase { Name = "TreeSeed", CoinValue = 20, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase LianaSeed = new MaterialBase { Name = "LianaSeed", CoinValue = 1000, TimeToCraft = TimeSpan.Zero };
        public static MaterialBase GrapeSeed = new MaterialBase { Name = "TreeSeed", CoinValue = 1200, TimeToCraft = TimeSpan.Zero };

        #endregion


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


        public static MaterialBase PolishedAmber = new MaterialBase
        {
            Name = "PolishedAmber",
            CoinValue = 70,
            TimeToCraft = TimeSpan.FromSeconds(30),
            Requires =
            {
                [Amber] = 5
            }
        };
        public static MaterialBase PolishedEmerald = new MaterialBase
        {
            Name = "PolishedEmerald",
            CoinValue = 160,
            TimeToCraft = TimeSpan.FromSeconds(30),
            Requires =
            {
                [Emerald] = 5
            }
        };
        public static MaterialBase AmberBracelet = new MaterialBase
        {
            Name = "AmberBracelet",
            CoinValue = 280,
            TimeToCraft = TimeSpan.FromSeconds(120),
            Requires =
            {
                [SilverBar] = 1,
                [PolishedAmber] = 1
            }
        };
        public static MaterialBase EmeraldRing = new MaterialBase
        {
            Name = "EmeraldRing",
            CoinValue = 450,
            TimeToCraft = TimeSpan.FromSeconds(300),
            Requires =
            {
                [GoldBar] = 1,
                [PolishedEmerald] = 1
            }
        };
        public static MaterialBase PolishedTopaz = new MaterialBase
        {
            Name = "PolishedTopaz",
            CoinValue = 200,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [Topaz] = 5
            }
        };
        public static MaterialBase PolishedRuby = new MaterialBase
        {
            Name = "PolishedRuby",
            CoinValue = 250,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [Ruby] = 5
            }
        };
        public static MaterialBase PolishedDiamond = new MaterialBase
        {
            Name = "PolishedDiamond",
            CoinValue = 300,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [Diamond] = 5
            }
        };
        public static MaterialBase PolishedSapphire = new MaterialBase
        {
            Name = "PolishedSapphire",
            CoinValue = 230,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [Sapphire] = 5
            }
        };
        public static MaterialBase PolishedAmethyst = new MaterialBase
        {
            Name = "PolishedAmethyst",
            CoinValue = 260,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [Amethyst] = 0
            }
        };



        // Produced in 10-unit quantities
        public static MaterialBase Wood = new MaterialBase
        {
            Name = "Wood",
            CoinValue = 193,
            TimeToCraft = TimeSpan.FromMinutes(3),
            Requires =
            {
                [Water] = 1,
                [TreeSeed] = 0.1
            }
        };

        public static MaterialBase Liana = new MaterialBase
        {
            Name = "Liana",
            CoinValue = 1700,
            TimeToCraft = TimeSpan.FromMinutes(30),
            Requires =
            {
                [Water] = 20,
                [LianaSeed] = 1
            }
        };

        // Produced in 2-unit quantities
        public static MaterialBase Grapes = new MaterialBase
        {
            Name = "Grapes",
            CoinValue = 1500,
            TimeToCraft = TimeSpan.FromMinutes(15),
            Requires =
            {
                [Water] = 7.5,
                [GrapeSeed] = 0.5
            }
        };


        // Produced in 2-unit quantities
        public static MaterialBase Rubber = new MaterialBase
        {
            Name = "Rubber",
            CoinValue = 4000,
            TimeToCraft = TimeSpan.FromMinutes(15),
            Requires =
            {
                [Liana] = 0.5
            }
        };

        public static MaterialBase LabFlask = new MaterialBase
        {
            Name = "LabFlask",
            CoinValue = 800,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
                                                  {
                                                      [Glass] = 1
                                                  }
        };

        public static MaterialBase CleanWater = new MaterialBase
        {
            Name = "CleanWater",
            CoinValue = 1200,
            TimeToCraft = TimeSpan.FromMinutes(10),
            Requires =
            {
                [Water] = 1,
                [LabFlask] = 1
            }
        };


        // Produced in 2-unit quantities along with 1 oxygen
        public static MaterialBase Hydrogen = new MaterialBase
        {
            Name = "Hydrogen",
            CoinValue = 400,
            TimeToCraft = TimeSpan.FromMinutes(7.5),
            Requires =
            {
                [CleanWater] = 0.5
            }
        };
        public static MaterialBase Oxygen = new MaterialBase
        {
            Name = "Oxygen",
            CoinValue = 900,
            TimeToCraft = TimeSpan.FromMinutes(15),
            Requires =
            {
                [CleanWater] = 1
            }
        };
        public static MaterialBase SulfuricAcid = new MaterialBase
        {
            Name = "SulfuricAcid",
            CoinValue = 3500,
            TimeToCraft = TimeSpan.FromMinutes(30),
            Requires =
            {
                [CleanWater] = 1,
                [Sulfur] = 2
            }
        };

        public static MaterialBase RefinedOil = new MaterialBase
        {
            Name = "RefinedOil",
            CoinValue = 16500,
            TimeToCraft = TimeSpan.FromMinutes(30),
            Requires =
            {
                [Oil] = 10,
                [Hydrogen] = 10,
                [LabFlask] = 1
            }
        };

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

        public static MaterialBase SteelPlate = new MaterialBase
        {
            Name = "SteelPlate",
            CoinValue = 1800,
            TimeToCraft = TimeSpan.FromSeconds(120),
            Requires =
                                                    {
                                                        [SteelBar] = 5
                                                    }
        };


        // produced in 10 unit quantities
        public static MaterialBase CopperNails = new MaterialBase
        {
            Name = "CopperNails",
            CoinValue = 7,
            TimeToCraft = TimeSpan.FromSeconds(2),
            Requires =
            {
                [CopperBar] = 0.1
            }
        };

        // Produced in 5 unit quantities
        public static MaterialBase CopperWire = new MaterialBase
        {
            Name = "CopperWire",
            CoinValue = 5,
            TimeToCraft = TimeSpan.FromSeconds(6),
            Requires =
            {
                [CopperBar] = 0.2
            }
        };

        public static MaterialBase Battery = new MaterialBase
        {
            Name = "Battery",
            CoinValue = 200,
            TimeToCraft = TimeSpan.FromSeconds(120),
            Requires =
            {
                [Amber] = 1,
                [IronBar] = 1,
                [CopperBar] = 5
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

        public static MaterialBase Lamp = new MaterialBase
        {
            Name = "Lamp",
            CoinValue = 760,
            TimeToCraft = TimeSpan.FromSeconds(80),
            Requires =
            {
                [CopperBar] = 5,
                [CopperWire] = 10,
                [Graphite] = 20
            }
        };



        public static MaterialBase AmberCharger = new MaterialBase
        {
            Name = "AmberCharger",
            CoinValue = 4,
            TimeToCraft = TimeSpan.FromSeconds(5),
            Requires =
            {
                [Amber] = 1
            }
        };

        // Produced in 2-unit quantities
        public static MaterialBase AluminumBottle = new MaterialBase
        {
            Name = "AluminumBottle",
            CoinValue = 55,
            TimeToCraft = TimeSpan.FromSeconds(15),
            Requires =
            {
                [AluminumBar] = 0.5
            }
        };

        public static MaterialBase Ethanol = new MaterialBase
        {
            Name = "Ethanol",
            CoinValue = 4200,
            TimeToCraft = TimeSpan.FromMinutes(30),
            Requires =
            {
                [AluminumBottle] = 1,
                [Grapes] = 2
            }
        };

        public static MaterialBase AmberInsulation = new MaterialBase
        {
            Name = "AmberInsulation",
            CoinValue = 125,
            TimeToCraft = TimeSpan.FromSeconds(20),
            Requires =
            {
                [Amber] = 10,
                [AluminumBottle] = 1
            }
        };

        public static MaterialBase InsulatedWire = new MaterialBase
        {
            Name = "InsulatedWire",
            CoinValue = 750,
            TimeToCraft = TimeSpan.FromSeconds(200),
            Requires =
            {
                [CopperWire] = 1,
                [AmberInsulation] = 1
            }
        };

        // Produced in 5-unit quantities
        public static MaterialBase GreenLaser = new MaterialBase
        {
            Name = "GreenLaser",
            CoinValue = 400,
            TimeToCraft = TimeSpan.FromSeconds(4),
            Requires =
            {
                [PolishedEmerald] = 0.2,
                [InsulatedWire] = 0.2,
                [Lamp] = 0.2
            }
        };


        public static MaterialBase Plastic = new MaterialBase
        {
            Name = "Plastic",
            CoinValue = 220000,
            TimeToCraft = TimeSpan.FromMinutes(30),
            Requires =
                                                 {
                                                     [RefinedOil] = 1,
                                                     [Coal] = 1000,
                                                     [GreenLaser] = 200
                                                 }
        };


        public static MaterialBase DiamondCutter = new MaterialBase
        {
            Name = "DiamondCutter",
            CoinValue = 5000,
            TimeToCraft = TimeSpan.FromSeconds(30),
            Requires =
            {
                [SteelPlate] = 1,
                [PolishedDiamond] = 5
            }
        };

        public static MaterialBase Motherboard = new MaterialBase
        {
            Name = "Motherboard",
            CoinValue = 17000,
            TimeToCraft = TimeSpan.FromMinutes(30),
            Requires =
            {
                [Circuit] = 3,
                [GoldBar] = 1,
                [Silicon] = 3
            }
        };

        public static MaterialBase SolidPropellant = new MaterialBase
        {
            Name = "SolidPropellant",
            CoinValue = 27000,
            TimeToCraft = TimeSpan.FromMinutes(20),
            Requires =
            {
                [Rubber] = 3,
                [AluminumBar] = 10
            }
        };

        public static MaterialBase Accumulator = new MaterialBase
        {
            Name = "Accumulator",
            CoinValue = 9000,
            TimeToCraft = TimeSpan.FromMinutes(3),
            Requires =
            {
                [Sodium] = 20,
                [Sulfur] = 20
            }
        };

        public static MaterialBase SolarPanel = new MaterialBase
        {
            Name = "SolarPanel",
            CoinValue = 69000,
            TimeToCraft = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Rubber] = 1,
                [Silicon] = 10,
                [Glass] = 50
            }
        };

        public static readonly MaterialBase[] AllMaterialsCollection =
        {
            Coal, Amber, CopperOre, IronOre, AluminumOre, SilverOre, GoldOre, PlatinumOre,
            Emerald, Ruby, Topaz, Sapphire, Amethyst, Diamond,
            Sulfur, Sodium, Silicon, Water, Oil,
            CopperBar, IronBar, AluminumBar, SteelBar, SilverBar, GoldBar,
            Glass, SteelPlate,
            PolishedAmber, PolishedAmethyst, PolishedDiamond, PolishedEmerald, PolishedRuby, PolishedSapphire, PolishedTopaz,
            AmberBracelet, EmeraldRing,
            Wood, Liana, Grapes,
            Rubber, CleanWater, Hydrogen, Oxygen, SulfuricAcid, Ethanol, RefinedOil, Plastic,
            Graphite, CopperNails, CopperWire, Battery, Circuit, Lamp, LabFlask, AmberCharger, AluminumBottle, AmberInsulation, InsulatedWire,
            GreenLaser, DiamondCutter, Motherboard, SolidPropellant, Accumulator, SolarPanel
        };

    }


}
