using System;
namespace DeepTownResourcesCalculator
{
    public static class Resources
    {
        /// <summary>
        ///     This function is used to calculate the <see cref="MaterialBase.TimeToCraft"/> for base materials (e.g., Iron Ore, Emeralds, etc.) that
        ///     are gathered from mineral mines because not all resources have an area that produces 100% of the respective resource (e.g., Iron Ore).
        /// </summary>
        /// <param name="maxPercent">
        ///     <para>
        ///         This is the highest resource distribution percent that is available for a given resource. 
        ///     </para>
        ///     <para>
        ///         For many resources, this would be 1.0 (100%), but certain resources will be lower (e.g., Iron Ore will be 0.3 (30%)).
        ///     </para>
        /// </param>
        /// <returns>The best-case mining rate duration for one resource, as a <see cref="TimeSpan"/>.</returns>
        static TimeSpan GetBaseRateFromMaxMinePercent(double maxPercent) => TimeSpan.FromSeconds(60D / (17D * maxPercent));

        /// <summary>
        ///     This is the base rate of mining for a material that has a 100% resource mine location, assuming a Level 8 mine (17 RPM)
        /// </summary>
        static readonly TimeSpan BaseMineralWithMineRate = GetBaseRateFromMaxMinePercent(1.0);


        #region Mineral Mine Resources

        static readonly MaterialBase Coal = new MaterialBase { Name = "Coal", CoinValue = 1, TimeToCraft = BaseMineralWithMineRate };
        static readonly MaterialBase Amber = new MaterialBase { Name = "Amber", CoinValue = 4, TimeToCraft = BaseMineralWithMineRate };
        static readonly MaterialBase CopperOre = new MaterialBase { Name = "CopperOre", CoinValue = 2, TimeToCraft = BaseMineralWithMineRate };
        static readonly MaterialBase AluminumOre = new MaterialBase { Name = "AluminumOre", CoinValue = 5, TimeToCraft = BaseMineralWithMineRate };
        static readonly MaterialBase GoldOre = new MaterialBase { Name = "GoldOre", CoinValue = 10, TimeToCraft = BaseMineralWithMineRate };

        static readonly MaterialBase IronOre = new MaterialBase { Name = "IronOre", CoinValue = 3, TimeToCraft = GetBaseRateFromMaxMinePercent(0.30) };

        static readonly MaterialBase SilverOre = new MaterialBase { Name = "SilverOre", CoinValue = 7, TimeToCraft = GetBaseRateFromMaxMinePercent(0.55) };  // TODO: Verify Mining Rate

        static readonly MaterialBase PlatinumOre = new MaterialBase { Name = "Platinum", CoinValue = 13, TimeToCraft = GetBaseRateFromMaxMinePercent(0.035) }; // TODO: Verify Mining Rate

        #endregion

        #region Gem Resources
        static readonly MaterialBase Emerald = new MaterialBase { Name = "Emerald", CoinValue = 12, TimeToCraft = BaseMineralWithMineRate };
        static readonly MaterialBase Ruby = new MaterialBase { Name = "Ruby", CoinValue = 15, TimeToCraft = BaseMineralWithMineRate };

        static readonly MaterialBase Topaz = new MaterialBase { Name = "Topaz", CoinValue = 14, TimeToCraft = GetBaseRateFromMaxMinePercent(0.30) };
        static readonly MaterialBase Sapphire = new MaterialBase { Name = "Sapphire", CoinValue = 16, TimeToCraft = GetBaseRateFromMaxMinePercent(0.18) };
        static readonly MaterialBase Amethyst = new MaterialBase { Name = "Amethyst", CoinValue = 18, TimeToCraft = GetBaseRateFromMaxMinePercent(0.37) };
        static readonly MaterialBase Diamond = new MaterialBase { Name = "Diamond", CoinValue = 18, TimeToCraft = GetBaseRateFromMaxMinePercent(0.18) };
        #endregion

        #region Chemical Mine Resources

        static readonly MaterialBase Sulfur = new MaterialBase { Name = "Sulfur", CoinValue = 100, TimeToCraft = TimeSpan.FromMinutes(2) };

        static readonly MaterialBase Silicon = new MaterialBase { Name = "Silicon", CoinValue = 100, TimeToCraft = TimeSpan.FromMinutes(2) };

        static readonly MaterialBase Sodium = new MaterialBase { Name = "Sodium", CoinValue = 100, TimeToCraft = TimeSpan.FromMinutes(2) };

        #endregion

        #region Other Base Resources

        // TODO: Figure out what a good rate will be for Water... water collector is 5-7RPM, but need to factor in frequency of rain...
        static readonly MaterialBase Water = new MaterialBase { Name = "Water", CoinValue = 5, TimeToCraft = TimeSpan.Zero };

        /// Assuming a Level 3 Oil Pump rate (0.3 RPM)
        static readonly MaterialBase Oil = new MaterialBase { Name = "Oil", CoinValue = 21, TimeToCraft = TimeSpan.FromMinutes(1D / 0.3D) };
        #endregion

        #region Greenhouse Seeds

        static readonly MaterialBase TreeSeed = new MaterialBase { Name = "TreeSeed", CoinValue = 20, TimeToCraft = TimeSpan.Zero };
        static readonly MaterialBase LianaSeed = new MaterialBase { Name = "LianaSeed", CoinValue = 1000, TimeToCraft = TimeSpan.Zero };
        static readonly MaterialBase GrapeSeed = new MaterialBase { Name = "TreeSeed", CoinValue = 1200, TimeToCraft = TimeSpan.Zero };

        #endregion


        static readonly MaterialBase CopperBar = new MaterialBase
        {
            Name = "CopperBar",
            CoinValue = 25,
            TimeToCraft = TimeSpan.FromSeconds(10),
            Requires =
            {
                [CopperOre] = 5
            }
        };

        static readonly MaterialBase IronBar = new MaterialBase
        {
            Name = "IronBar",
            CoinValue = 40,
            TimeToCraft = TimeSpan.FromSeconds(15),
            Requires =
            {
                [IronOre] = 5
            }
        };

        static readonly MaterialBase AluminumBar = new MaterialBase
        {
            Name = "AluminumBar",
            CoinValue = 50,
            TimeToCraft = TimeSpan.FromSeconds(15),
            Requires =
            {
                [AluminumOre] = 5
            }
        };



        static readonly MaterialBase SilverBar = new MaterialBase
        {
            Name = "SilverBar",
            CoinValue = 200,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [SilverOre] = 5
            }
        };

        static readonly MaterialBase GoldBar = new MaterialBase
        {
            Name = "GoldBar",
            CoinValue = 250,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [GoldOre] = 5
            }
        };

        static readonly MaterialBase Glass = new MaterialBase
        {
            Name = "Glass",
            CoinValue = 450,
            TimeToCraft = TimeSpan.FromSeconds(60),
            Requires =
            {
                [Silicon] = 2
            }
        };


        static readonly MaterialBase PolishedAmber = new MaterialBase
        {
            Name = "PolishedAmber",
            CoinValue = 70,
            TimeToCraft = TimeSpan.FromSeconds(30),
            Requires =
            {
                [Amber] = 5
            }
        };
        static readonly MaterialBase PolishedEmerald = new MaterialBase
        {
            Name = "PolishedEmerald",
            CoinValue = 160,
            TimeToCraft = TimeSpan.FromSeconds(30),
            Requires =
            {
                [Emerald] = 5
            }
        };
        static readonly MaterialBase AmberBracelet = new MaterialBase
        {
            Name = "AmberBracelet",
            CoinValue = 280,
            TimeToCraft = TimeSpan.FromMinutes(2),
            Requires =
            {
                [SilverBar] = 1,
                [PolishedAmber] = 1
            }
        };
        static readonly MaterialBase EmeraldRing = new MaterialBase
        {
            Name = "EmeraldRing",
            CoinValue = 450,
            TimeToCraft = TimeSpan.FromMinutes(5),
            Requires =
            {
                [GoldBar] = 1,
                [PolishedEmerald] = 1
            }
        };
        static readonly MaterialBase PolishedTopaz = new MaterialBase
        {
            Name = "PolishedTopaz",
            CoinValue = 200,
            TimeToCraft = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Topaz] = 5
            }
        };
        static readonly MaterialBase PolishedRuby = new MaterialBase
        {
            Name = "PolishedRuby",
            CoinValue = 250,
            TimeToCraft = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Ruby] = 5
            }
        };
        static readonly MaterialBase PolishedDiamond = new MaterialBase
        {
            Name = "PolishedDiamond",
            CoinValue = 300,
            TimeToCraft = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Diamond] = 5
            }
        };
        static readonly MaterialBase PolishedSapphire = new MaterialBase
        {
            Name = "PolishedSapphire",
            CoinValue = 230,
            TimeToCraft = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Sapphire] = 5
            }
        };
        static readonly MaterialBase PolishedAmethyst = new MaterialBase
        {
            Name = "PolishedAmethyst",
            CoinValue = 260,
            TimeToCraft = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Amethyst] = 0
            }
        };

        // Produced in 10-unit quantities
        static readonly MaterialBase Wood = new MaterialBase
        {
            Name = "Wood",
            CoinValue = 193,
            TimeToCraft = TimeSpan.FromMinutes(30D / 10D),
            Requires =
            {
                [Water] = 10D / 10D,
                [TreeSeed] = 1D / 10D
            }
        };

        static readonly MaterialBase Liana = new MaterialBase
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
        static readonly MaterialBase Grapes = new MaterialBase
        {
            Name = "Grapes",
            CoinValue = 1500,
            TimeToCraft = TimeSpan.FromMinutes(30D / 2D),
            Requires =
            {
                [Water] = 15D / 2D,
                [GrapeSeed] = 1D / 2D
            }
        };


        // Produced in 2-unit quantities
        static readonly MaterialBase Rubber = new MaterialBase
        {
            Name = "Rubber",
            CoinValue = 4000,
            TimeToCraft = TimeSpan.FromMinutes(30D / 2D),
            Requires =
            {
                [Liana] = 1D / 2D
            }
        };

        static readonly MaterialBase LabFlask = new MaterialBase
        {
            Name = "LabFlask",
            CoinValue = 800,
            TimeToCraft = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Glass] = 1
            }
        };

        static readonly MaterialBase CleanWater = new MaterialBase
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
        static readonly MaterialBase Hydrogen = new MaterialBase
        {
            Name = "Hydrogen",
            CoinValue = 400,
            TimeToCraft = TimeSpan.FromMinutes(15D / 2D),
            Requires =
            {
                [CleanWater] = 1 / 2D
            }
        };
        static readonly MaterialBase Oxygen = new MaterialBase
        {
            Name = "Oxygen",
            CoinValue = 900,
            TimeToCraft = TimeSpan.FromMinutes(15),
            Requires =
            {
                [CleanWater] = 1
            }
        };
        static readonly MaterialBase SulfuricAcid = new MaterialBase
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

        static readonly MaterialBase RefinedOil = new MaterialBase
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

        static readonly MaterialBase Graphite = new MaterialBase
        {
            Name = "Graphite",
            CoinValue = 15,
            TimeToCraft = TimeSpan.FromSeconds(5),
            Requires =
            {
                [Coal] = 5
            }
        };


        static readonly MaterialBase SteelBar = new MaterialBase
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

        static readonly MaterialBase SteelPlate = new MaterialBase
        {
            Name = "SteelPlate",
            CoinValue = 1800,
            TimeToCraft = TimeSpan.FromMinutes(2),
            Requires =
            {
                [SteelBar] = 5
            }
        };


        // produced in 10 unit quantities
        static readonly MaterialBase CopperNails = new MaterialBase
        {
            Name = "CopperNails",
            CoinValue = 7,
            TimeToCraft = TimeSpan.FromSeconds(20D / 10),
            Requires =
            {
                [CopperBar] = 1D / 10
            }
        };

        // Produced in 5 unit quantities
        static readonly MaterialBase CopperWire = new MaterialBase
        {
            Name = "CopperWire",
            CoinValue = 5,
            TimeToCraft = TimeSpan.FromSeconds(30D / 5D),
            Requires =
            {
                [CopperBar] = 1D / 5D
            }
        };

        static readonly MaterialBase Battery = new MaterialBase
        {
            Name = "Battery",
            CoinValue = 200,
            TimeToCraft = TimeSpan.FromMinutes(2),
            Requires =
            {
                [Amber] = 1,
                [IronBar] = 1,
                [CopperBar] = 5
            }
        };

        static readonly MaterialBase Circuit = new MaterialBase
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

        static readonly MaterialBase Lamp = new MaterialBase
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

        static readonly MaterialBase AmberCharger = new MaterialBase
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
        static readonly MaterialBase AluminumBottle = new MaterialBase
        {
            Name = "AluminumBottle",
            CoinValue = 55,
            TimeToCraft = TimeSpan.FromSeconds(30D / 2D),
            Requires =
            {
                [AluminumBar] = 1D / 2D
            }
        };

        static readonly MaterialBase Ethanol = new MaterialBase
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

        static readonly MaterialBase AmberInsulation = new MaterialBase
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

        static readonly MaterialBase InsulatedWire = new MaterialBase
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
        static readonly MaterialBase GreenLaser = new MaterialBase
        {
            Name = "GreenLaser",
            CoinValue = 400,
            TimeToCraft = TimeSpan.FromSeconds(20D / 5D),
            Requires =
            {
                [PolishedEmerald] = 1D / 5D,
                [InsulatedWire] = 1D / 5D,
                [Lamp] = 1D / 5D
            }
        };

        static readonly MaterialBase Plastic = new MaterialBase
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

        static readonly MaterialBase DiamondCutter = new MaterialBase
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

        static readonly MaterialBase Motherboard = new MaterialBase
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

        static readonly MaterialBase SolidPropellant = new MaterialBase
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

        static readonly MaterialBase Accumulator = new MaterialBase
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

        static readonly MaterialBase SolarPanel = new MaterialBase
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
