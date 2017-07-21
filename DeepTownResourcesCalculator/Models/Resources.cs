using System;
namespace DeepTownResourcesCalculator
{
    public static class Resources
    {
        /// <summary>
        ///     This function is used to calculate the <see cref="ResourceBaseModel.TimeToProduce"/> for base materials (e.g., Iron Ore, Emeralds, etc.) that
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


        static readonly ResourceBaseModel Coal =
                new ResourceBaseModel { Name = "Coal", CoinValue = 1, TimeToProduce = BaseMineralWithMineRate };

        static readonly ResourceBaseModel Amber =
                new ResourceBaseModel { Name = "Amber", CoinValue = 4, TimeToProduce = BaseMineralWithMineRate };

        static readonly ResourceBaseModel CopperOre =
                new ResourceBaseModel { Name = "CopperOre", CoinValue = 2, TimeToProduce = BaseMineralWithMineRate };

        static readonly ResourceBaseModel AluminumOre =
                new ResourceBaseModel { Name = "AluminumOre", CoinValue = 5, TimeToProduce = BaseMineralWithMineRate };

        static readonly ResourceBaseModel GoldOre =
                new ResourceBaseModel { Name = "GoldOre", CoinValue = 10, TimeToProduce = BaseMineralWithMineRate };

        static readonly ResourceBaseModel IronOre =
                new ResourceBaseModel { Name = "IronOre", CoinValue = 3, TimeToProduce = GetBaseRateFromMaxMinePercent(0.30) };


        static readonly ResourceBaseModel SilverOre =
                new ResourceBaseModel { Name = "SilverOre", CoinValue = 7, TimeToProduce = GetBaseRateFromMaxMinePercent(0.55) }; // TODO: Verify Mining Rate

        static readonly ResourceBaseModel PlatinumOre =
                new ResourceBaseModel { Name = "Platinum", CoinValue = 13, TimeToProduce = GetBaseRateFromMaxMinePercent(0.035) }; // TODO: Verify Mining Rate


        #endregion


        #region Gem Resources


        static readonly ResourceBaseModel Emerald =
                new ResourceBaseModel { Name = "Emerald", CoinValue = 12, TimeToProduce = BaseMineralWithMineRate };

        static readonly ResourceBaseModel Ruby =
                new ResourceBaseModel { Name = "Ruby", CoinValue = 15, TimeToProduce = BaseMineralWithMineRate };

        static readonly ResourceBaseModel Topaz =
                new ResourceBaseModel { Name = "Topaz", CoinValue = 14, TimeToProduce = GetBaseRateFromMaxMinePercent(0.30) };

        static readonly ResourceBaseModel Sapphire =
                new ResourceBaseModel { Name = "Sapphire", CoinValue = 16, TimeToProduce = GetBaseRateFromMaxMinePercent(0.18) };

        static readonly ResourceBaseModel Amethyst =
                new ResourceBaseModel { Name = "Amethyst", CoinValue = 18, TimeToProduce = GetBaseRateFromMaxMinePercent(0.37) };

        static readonly ResourceBaseModel Diamond =
                new ResourceBaseModel { Name = "Diamond", CoinValue = 18, TimeToProduce = GetBaseRateFromMaxMinePercent(0.18) };


        #endregion


        #region Chemical Mine Resources


        static readonly ResourceBaseModel Sulfur =
                new ResourceBaseModel { Name = "Sulfur", CoinValue = 100, TimeToProduce = TimeSpan.FromMinutes(2) };

        static readonly ResourceBaseModel Silicon =
                new ResourceBaseModel { Name = "Silicon", CoinValue = 100, TimeToProduce = TimeSpan.FromMinutes(2) };

        static readonly ResourceBaseModel Sodium =
                new ResourceBaseModel { Name = "Sodium", CoinValue = 100, TimeToProduce = TimeSpan.FromMinutes(2) };


        #endregion


        #region Other Base Resources


        // Using the best estimated on-line effective water collection rate (as it is not *always* raining...) of 2.5 RPM
        static readonly ResourceBaseModel Water =
                new ResourceBaseModel { Name = "Water", CoinValue = 5, TimeToProduce = TimeSpan.FromMinutes(1D / 2.5D) };

        /// Assuming a Level 3 Oil Pump rate (0.3 RPM)
        static readonly ResourceBaseModel Oil =
                new ResourceBaseModel { Name = "Oil", CoinValue = 21, TimeToProduce = TimeSpan.FromMinutes(1D / 0.3D) };


        #endregion


        #region Greenhouse Seeds


        static readonly ResourceBaseModel TreeSeed =
                new ResourceBaseModel { Name = "TreeSeed", CoinValue = 20, TimeToProduce = TimeSpan.Zero };

        static readonly ResourceBaseModel LianaSeed =
                new ResourceBaseModel { Name = "LianaSeed", CoinValue = 1000, TimeToProduce = TimeSpan.Zero };

        static readonly ResourceBaseModel GrapeSeed =
                new ResourceBaseModel { Name = "TreeSeed", CoinValue = 1200, TimeToProduce = TimeSpan.Zero };


        #endregion

        static readonly ResourceBaseModel CopperBar = new ResourceBaseModel
        {
            Name = "CopperBar",
            CoinValue = 25,
            TimeToProduce = TimeSpan.FromSeconds(10),
            Requires =
            {
                [CopperOre] = 5
            }
        };

        static readonly ResourceBaseModel IronBar = new ResourceBaseModel
        {
            Name = "IronBar",
            CoinValue = 40,
            TimeToProduce = TimeSpan.FromSeconds(15),
            Requires =
            {
                [IronOre] = 5
            }
        };

        static readonly ResourceBaseModel AluminumBar = new ResourceBaseModel
        {
            Name = "AluminumBar",
            CoinValue = 50,
            TimeToProduce = TimeSpan.FromSeconds(15),
            Requires =
            {
                [AluminumOre] = 5
            }
        };

        static readonly ResourceBaseModel SilverBar = new ResourceBaseModel
        {
            Name = "SilverBar",
            CoinValue = 200,
            TimeToProduce = TimeSpan.FromSeconds(60),
            Requires =
            {
                [SilverOre] = 5
            }
        };

        static readonly ResourceBaseModel GoldBar = new ResourceBaseModel
        {
            Name = "GoldBar",
            CoinValue = 250,
            TimeToProduce = TimeSpan.FromSeconds(60),
            Requires =
            {
                [GoldOre] = 5
            }
        };

        static readonly ResourceBaseModel Glass = new ResourceBaseModel
        {
            Name = "Glass",
            CoinValue = 450,
            TimeToProduce = TimeSpan.FromSeconds(60),
            Requires =
            {
                [Silicon] = 2
            }
        };

        static readonly ResourceBaseModel PolishedAmber = new ResourceBaseModel
        {
            Name = "PolishedAmber",
            CoinValue = 70,
            TimeToProduce = TimeSpan.FromSeconds(30),
            Requires =
            {
                [Amber] = 5
            }
        };

        static readonly ResourceBaseModel PolishedEmerald = new ResourceBaseModel
        {
            Name = "PolishedEmerald",
            CoinValue = 160,
            TimeToProduce = TimeSpan.FromSeconds(30),
            Requires =
            {
                [Emerald] = 5
            }
        };

        static readonly ResourceBaseModel AmberBracelet = new ResourceBaseModel
        {
            Name = "AmberBracelet",
            CoinValue = 280,
            TimeToProduce = TimeSpan.FromMinutes(2),
            Requires =
            {
                [SilverBar] = 1,
                [PolishedAmber] = 1
            }
        };

        static readonly ResourceBaseModel EmeraldRing = new ResourceBaseModel
        {
            Name = "EmeraldRing",
            CoinValue = 450,
            TimeToProduce = TimeSpan.FromMinutes(5),
            Requires =
            {
                [GoldBar] = 1,
                [PolishedEmerald] = 1
            }
        };

        static readonly ResourceBaseModel PolishedTopaz = new ResourceBaseModel
        {
            Name = "PolishedTopaz",
            CoinValue = 200,
            TimeToProduce = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Topaz] = 5
            }
        };

        static readonly ResourceBaseModel PolishedRuby = new ResourceBaseModel
        {
            Name = "PolishedRuby",
            CoinValue = 250,
            TimeToProduce = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Ruby] = 5
            }
        };

        static readonly ResourceBaseModel PolishedDiamond = new ResourceBaseModel
        {
            Name = "PolishedDiamond",
            CoinValue = 300,
            TimeToProduce = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Diamond] = 5
            }
        };

        static readonly ResourceBaseModel PolishedSapphire = new ResourceBaseModel
        {
            Name = "PolishedSapphire",
            CoinValue = 230,
            TimeToProduce = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Sapphire] = 5
            }
        };

        static readonly ResourceBaseModel PolishedAmethyst = new ResourceBaseModel
        {
            Name = "PolishedAmethyst",
            CoinValue = 260,
            TimeToProduce = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Amethyst] = 5
            }
        };

        // Produced in 10-unit quantities
        static readonly ResourceBaseModel Wood = new ResourceBaseModel
        {
            Name = "Wood",
            CoinValue = 193,
            TimeToProduce = TimeSpan.FromMinutes(30D / 10D),
            Requires =
            {
                [Water] = 10D / 10D,
                [TreeSeed] = 1D / 10D
            }
        };

        static readonly ResourceBaseModel Liana = new ResourceBaseModel
        {
            Name = "Liana",
            CoinValue = 1700,
            TimeToProduce = TimeSpan.FromMinutes(30),
            Requires =
            {
                [Water] = 20,
                [LianaSeed] = 1
            }
        };

        // Produced in 2-unit quantities
        static readonly ResourceBaseModel Grapes = new ResourceBaseModel
        {
            Name = "Grapes",
            CoinValue = 1500,
            TimeToProduce = TimeSpan.FromMinutes(30D / 2D),
            Requires =
            {
                [Water] = 15D / 2D,
                [GrapeSeed] = 1D / 2D
            }
        };

        // Produced in 2-unit quantities
        static readonly ResourceBaseModel Rubber = new ResourceBaseModel
        {
            Name = "Rubber",
            CoinValue = 4000,
            TimeToProduce = TimeSpan.FromMinutes(30D / 2D),
            Requires =
            {
                [Liana] = 1D / 2D
            }
        };

        static readonly ResourceBaseModel LabFlask = new ResourceBaseModel
        {
            Name = "LabFlask",
            CoinValue = 800,
            TimeToProduce = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Glass] = 1
            }
        };

        static readonly ResourceBaseModel CleanWater = new ResourceBaseModel
        {
            Name = "CleanWater",
            CoinValue = 1200,
            TimeToProduce = TimeSpan.FromMinutes(10),
            Requires =
            {
                [Water] = 1,
                [LabFlask] = 1
            }
        };

        // Produced in 2-unit quantities along with 1 oxygen
        // Note: the actual values for this might be a bit off due to it being produced simultaneously with Oxygen...
        static readonly ResourceBaseModel Hydrogen = new ResourceBaseModel
        {
            Name = "Hydrogen",
            CoinValue = 400,
            TimeToProduce = TimeSpan.FromMinutes(15D / 2D),
            Requires =
            {
                [CleanWater] = 1 / 2D
            }
        };

        // Note: the actual values for this might be a bit off due to it being produced simultaneously with Hydrogen...
        static readonly ResourceBaseModel Oxygen = new ResourceBaseModel
        {
            Name = "Oxygen",
            CoinValue = 900,
            TimeToProduce = TimeSpan.FromMinutes(15),
            Requires =
            {
                [CleanWater] = 1
            }
        };

        static readonly ResourceBaseModel SulfuricAcid = new ResourceBaseModel
        {
            Name = "SulfuricAcid",
            CoinValue = 3500,
            TimeToProduce = TimeSpan.FromMinutes(30),
            Requires =
            {
                [CleanWater] = 1,
                [Sulfur] = 2
            }
        };

        static readonly ResourceBaseModel RefinedOil = new ResourceBaseModel
        {
            Name = "RefinedOil",
            CoinValue = 16500,
            TimeToProduce = TimeSpan.FromMinutes(30),
            Requires =
            {
                [Oil] = 10,
                [Hydrogen] = 10,
                [LabFlask] = 1
            }
        };

        static readonly ResourceBaseModel Graphite = new ResourceBaseModel
        {
            Name = "Graphite",
            CoinValue = 15,
            TimeToProduce = TimeSpan.FromSeconds(5),
            Requires =
            {
                [Coal] = 5
            }
        };

        static readonly ResourceBaseModel SteelBar = new ResourceBaseModel
        {
            Name = "SteelBar",
            CoinValue = 180,
            TimeToProduce = TimeSpan.FromSeconds(45),
            Requires =
            {
                [IronBar] = 1,
                [Graphite] = 1
            }
        };

        static readonly ResourceBaseModel SteelPlate = new ResourceBaseModel
        {
            Name = "SteelPlate",
            CoinValue = 1800,
            TimeToProduce = TimeSpan.FromMinutes(2),
            Requires =
            {
                [SteelBar] = 5
            }
        };

        // produced in 10 unit quantities
        static readonly ResourceBaseModel CopperNails = new ResourceBaseModel
        {
            Name = "CopperNails",
            CoinValue = 7,
            TimeToProduce = TimeSpan.FromSeconds(20D / 10),
            Requires =
            {
                [CopperBar] = 1D / 10
            }
        };

        // Produced in 5 unit quantities
        static readonly ResourceBaseModel CopperWire = new ResourceBaseModel
        {
            Name = "CopperWire",
            CoinValue = 5,
            TimeToProduce = TimeSpan.FromSeconds(30D / 5D),
            Requires =
            {
                [CopperBar] = 1D / 5D
            }
        };

        static readonly ResourceBaseModel Battery = new ResourceBaseModel
        {
            Name = "Battery",
            CoinValue = 200,
            TimeToProduce = TimeSpan.FromMinutes(2),
            Requires =
            {
                [Amber] = 1,
                [IronBar] = 1,
                [CopperBar] = 5
            }
        };

        static readonly ResourceBaseModel Circuit = new ResourceBaseModel
        {
            Name = "Circuit",
            CoinValue = 2070,
            TimeToProduce = TimeSpan.FromMinutes(3),
            Requires =
            {
                [IronBar] = 10,
                [Graphite] = 50,
                [CopperBar] = 20
            }
        };

        static readonly ResourceBaseModel Lamp = new ResourceBaseModel
        {
            Name = "Lamp",
            CoinValue = 760,
            TimeToProduce = TimeSpan.FromSeconds(80),
            Requires =
            {
                [CopperBar] = 5,
                [CopperWire] = 10,
                [Graphite] = 20
            }
        };

        static readonly ResourceBaseModel AmberCharger = new ResourceBaseModel
        {
            Name = "AmberCharger",
            CoinValue = 4,
            TimeToProduce = TimeSpan.FromSeconds(5),
            Requires =
            {
                [Amber] = 1
            }
        };

        // Produced in 2-unit quantities
        static readonly ResourceBaseModel AluminumBottle = new ResourceBaseModel
        {
            Name = "AluminumBottle",
            CoinValue = 55,
            TimeToProduce = TimeSpan.FromSeconds(30D / 2D),
            Requires =
            {
                [AluminumBar] = 1D / 2D
            }
        };

        static readonly ResourceBaseModel Ethanol = new ResourceBaseModel
        {
            Name = "Ethanol",
            CoinValue = 4200,
            TimeToProduce = TimeSpan.FromMinutes(30),
            Requires =
            {
                [AluminumBottle] = 1,
                [Grapes] = 2
            }
        };

        static readonly ResourceBaseModel AmberInsulation = new ResourceBaseModel
        {
            Name = "AmberInsulation",
            CoinValue = 125,
            TimeToProduce = TimeSpan.FromSeconds(20),
            Requires =
            {
                [Amber] = 10,
                [AluminumBottle] = 1
            }
        };

        static readonly ResourceBaseModel InsulatedWire = new ResourceBaseModel
        {
            Name = "InsulatedWire",
            CoinValue = 750,
            TimeToProduce = TimeSpan.FromSeconds(200),
            Requires =
            {
                [CopperWire] = 1,
                [AmberInsulation] = 1
            }
        };

        // Produced in 5-unit quantities
        static readonly ResourceBaseModel GreenLaser = new ResourceBaseModel
        {
            Name = "GreenLaser",
            CoinValue = 400,
            TimeToProduce = TimeSpan.FromSeconds(20D / 5D),
            Requires =
            {
                [PolishedEmerald] = 1D / 5D,
                [InsulatedWire] = 1D / 5D,
                [Lamp] = 1D / 5D
            }
        };

        static readonly ResourceBaseModel Plastic = new ResourceBaseModel
        {
            Name = "Plastic",
            CoinValue = 220000,
            TimeToProduce = TimeSpan.FromMinutes(30),
            Requires =
            {
                [RefinedOil] = 1,
                [Coal] = 1000,
                [GreenLaser] = 200
            }
        };

        static readonly ResourceBaseModel DiamondCutter = new ResourceBaseModel
        {
            Name = "DiamondCutter",
            CoinValue = 5000,
            TimeToProduce = TimeSpan.FromSeconds(30),
            Requires =
            {
                [SteelPlate] = 1,
                [PolishedDiamond] = 5
            }
        };

        static readonly ResourceBaseModel Motherboard = new ResourceBaseModel
        {
            Name = "Motherboard",
            CoinValue = 17000,
            TimeToProduce = TimeSpan.FromMinutes(30),
            Requires =
            {
                [Circuit] = 3,
                [GoldBar] = 1,
                [Silicon] = 3
            }
        };

        static readonly ResourceBaseModel SolidPropellant = new ResourceBaseModel
        {
            Name = "SolidPropellant",
            CoinValue = 27000,
            TimeToProduce = TimeSpan.FromMinutes(20),
            Requires =
            {
                [Rubber] = 3,
                [AluminumBar] = 10
            }
        };

        static readonly ResourceBaseModel Accumulator = new ResourceBaseModel
        {
            Name = "Accumulator",
            CoinValue = 9000,
            TimeToProduce = TimeSpan.FromMinutes(3),
            Requires =
            {
                [Sodium] = 20,
                [Sulfur] = 20
            }
        };

        static readonly ResourceBaseModel SolarPanel = new ResourceBaseModel
        {
            Name = "SolarPanel",
            CoinValue = 69000,
            TimeToProduce = TimeSpan.FromMinutes(1),
            Requires =
            {
                [Rubber] = 1,
                [Silicon] = 10,
                [Glass] = 50
            }
        };

        // Note: recording "charcoal" (smelted) separately from mined coal, mainly for comparison's sake
        //       1 wood produces 50 [char]coal
        static readonly ResourceBaseModel Charcoal = new ResourceBaseModel
        {
            Name = "Charcoal",
            CoinValue = Coal.CoinValue,
            TimeToProduce = TimeSpan.FromSeconds(60D / 50D),
            Requires =
            {
                [Wood] = 1D / 50D
            }
        };


        public static readonly ResourceBaseModel[] AllResourcesCollection =
        {
            Coal, Amber, CopperOre, IronOre, AluminumOre, SilverOre, GoldOre, PlatinumOre,
            Emerald, Ruby, Topaz, Sapphire, Amethyst, Diamond,
            Sulfur, Sodium, Silicon, Water, Oil,
            CopperBar, IronBar, AluminumBar, SteelBar, SilverBar, GoldBar, Charcoal,
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
