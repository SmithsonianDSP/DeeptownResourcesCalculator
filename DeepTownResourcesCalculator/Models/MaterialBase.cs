using System;
using System.Collections.Generic;
using System.Linq;

namespace DeepTownResourcesCalculator
{
    public sealed class MaterialBase
    {
        public string Name { get; set; }

        /// <summary>
        ///     A list of the different materials and resources required to produce ONE UNIT of this material. 
        /// </summary>
        /// <remarks>
        ///     For items that are only produced in multiple quantities (e.g., green laser, wood, hydrogen, etc.), the
        ///     quantity required will be FRACTIONAL values, even though the items cannot actually be consumed in fractions.
        ///     The point of this is to look at a material's various stats relative to the others, which requires all items
        ///     have a base unit of one.
        /// </remarks>
        public Dictionary<MaterialBase, double> Requires { get; } = new Dictionary<MaterialBase, double>();

        /// <summary>
        ///     The coin selling value for ONE UNIT of this resource
        /// </summary>
        /// <remarks>
        ///     We aren't factoring in the Trading Post due to the varying prices and the selling price multiplier based on the building's level
        /// </remarks>
        public int CoinValue { get; set; }

        /// <summary>
        ///     The time required to mine/craft/collect ONE UNIT of this resource. 
        /// </summary>
        /// <remarks>
        ///     In all cases, we assume ONLINE mining rates, NO 2x/2.5x boosts, and no drone boosts. 
        /// </remarks>
        public TimeSpan TimeToCraft { get; set; } = TimeSpan.FromSeconds(0);




        #region Calculated Fields and Properties
        #region Calculation Cache Backing

        double _cachedSumOfParts;

        bool _isSumOfPartsCached;

        TimeSpan _cachedSumToPartsToCraft;

        bool _isSumOfPartsToCraftCached;

        #endregion

        /// <summary>
        ///     This is the sum face-value of all of a material's required subcomponents. If a material does NOT have any subcomponents
        ///     (e.g., coal, copper ore, etc.), then this will be the material's own face value.
        /// </summary>
        /// <example>
        ///     For <see cref="Resources.Coal"/>, this will be 1, as it does not have any subcomponents.
        ///     For <see cref="Resources.Graphite"/>, this will be 5, because it requires 5 <see cref="Resources.Coal"/>, each with a value of 1.
        /// </example>
        public double SumOfParts
        {
            get
            {
                if (!_isSumOfPartsCached)
                {

                    _cachedSumOfParts = Requires.Any() && Requires.Sum(d => d.Key.SumOfParts * d.Value) > 0
                                            ? Requires.Sum(d => d.Key.SumOfParts * d.Value)
                                            : CoinValue;

                    _isSumOfPartsCached = true;
                }
                return _cachedSumOfParts;
            }
        }

        /// <summary>
        ///     This is the effective profit margin, which is the difference in coin value of this resource vs. the coin value of all of the items 
        ///     that are required to produce it. 
        /// </summary>
        public double ProfitMargin => Requires.Any()
                                          ? CoinValue - SumOfParts
                                          : CoinValue;


        /// <summary>
        ///     The length of time it takes to craft all required sub-components (and their sub-components) EXCLUDING its own crafting time
        /// </summary>
        public TimeSpan SumOfPartsToCraft
        {
            get
            {
                if (!_isSumOfPartsToCraftCached)
                {

                    _cachedSumToPartsToCraft = Requires.Any() && SumOfPartsInSeconds > 0
                                                   ? TimeSpan.FromSeconds(Requires.Sum(d => d.Key.TotalTimeToCraft.TotalSeconds * d.Value))
                                                   : TimeSpan.Zero;

                    _isSumOfPartsToCraftCached = true;
                }

                return _cachedSumToPartsToCraft;
            }
        }

        /// <summary>
        ///     The length of time it takes to craft all required sub-components (and their sub-components) PLUS the <see cref="TimeToCraft"/> the material, itself
        /// </summary>
        public TimeSpan TotalTimeToCraft => SumOfPartsToCraft.Add(TimeToCraft);


        double SumOfPartsInSeconds => TimeSpan.FromMilliseconds(Requires.Sum(d => d.Key.TotalTimeToCraft.TotalMilliseconds * d.Value)).TotalSeconds;


        public double ProfitToTimeRequiredRatio => (CoinValue - SumOfParts) / TotalTimeToCraft.TotalMinutes;

        #endregion

    }


}
