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
using System.Collections.ObjectModel;
using System.Linq;
using Humanizer;

namespace DeepTownResourcesCalculator
{
    public sealed partial class ResourceBaseModel
    {
        public string Name { get; set; }

        /// <summary>
        ///     The "Humanized" version of the resource name. Ideal for human-friendly reading.
        /// </summary>
        public string PrettyName => Name.Humanize(LetterCasing.Title);

        /// <summary>
        ///     A list of the different materials and resources required to produce ONE UNIT of this material.
        /// </summary>
        /// <remarks>
        ///     For items that are only produced in multiple quantities (e.g., green laser, wood, hydrogen, etc.), the
        ///     quantity required will be FRACTIONAL values, even though the items cannot actually be consumed in fractions.
        ///     The point of this is to look at a material's various stats relative to the others, which requires all items
        ///     have a base unit of one.
        /// </remarks>
        public Dictionary<ResourceBaseModel, double> Requires { get; } = new Dictionary<ResourceBaseModel, double>();

        /// <summary>
        ///     The coin selling value for ONE UNIT of this resource
        /// </summary>
        /// <remarks>
        ///     We aren't factoring in the Trading Post due to the varying prices and the selling price multiplier based on the
        ///     building's level
        /// </remarks>
        public int CoinValue { get; set; }

        /// <summary>
        ///     The time required to mine/craft/collect ONE UNIT of this resource.
        /// </summary>
        /// <remarks>
        ///     In all cases, we assume ONLINE mining rates, NO 2x/2.5x boosts, and no drone boosts.
        /// </remarks>
        public TimeSpan TimeToProduce { get; set; } = TimeSpan.FromSeconds(0);

        /// <summary>
        ///     Where this resource is produced (e.g., iron ore = <see cref="ProductionSource.MineralMine" />, iron bar =
        ///     <see cref="ProductionSource.Smelter" />)
        /// </summary>
        public ProductionSource ProducedAt { get; set; } = ProductionSource.MineralMine;

        /// <summary>
        ///     If the <paramref name="key" /> exists in the provided <paramref name="dict" />, it will add the
        ///     <paramref name="value" /> to the <paramref name="dict" />'s current value.
        ///     If it does not exist, it will create a new entry in the <paramref name="dict" /> for the supplied
        ///     <paramref name="key" /> with the provided <paramref name="value" />
        /// </summary>
        /// <param name="dict">The Dictionary to add or increment the value for</param>
        /// <param name="key">The specified Key to check or create</param>
        /// <param name="value">The value to add to the dictionary</param>
        static void IncrementOrAddToDictionary(IDictionary<ProductionSource, double> dict, ProductionSource key, double value)
        {
            if (dict.ContainsKey(key))
                dict[key] = dict[key] + value;
            else
                dict.Add(key, value);
        }


        #region Calculated Fields and Properties
        // These are all things that are dependant upon the values set above


        #region Calculation Cache Backing
        // We cache the results of this calculation because they won't change and so we aren't doing it multiple times whenever
        // we want to look at this value.

        double _cachedSumOfSubcomponentValues;
        bool _isSumOfSubcomponentValuesCached;


        #endregion


        /// <summary>
        ///     This is the sum value of all of a material's required subcomponents. If a material does NOT have any
        ///     subcomponents (e.g., coal, copper ore, etc.), then this will be the material's own face value.
        /// </summary>
        /// <example>
        ///     For <see cref="Resources.Coal" />, this will be 1, as it does not have any subcomponents.
        ///     For <see cref="Resources.Graphite" />, this will be 5, because it requires 5 <see cref="Resources.Coal" />, each
        ///     with a value of 1.
        /// </example>
        public double SumOfSubcomponentValues
        {
            get
            {
                if (!_isSumOfSubcomponentValuesCached)
                {
                    _cachedSumOfSubcomponentValues = Requires.Any(d => d.Key.SumOfSubcomponentValues > 0)
                                                         ? Requires.Sum(d => d.Key.SumOfSubcomponentValues * d.Value)
                                                         : CoinValue;

                    _isSumOfSubcomponentValuesCached = true;
                }
                return _cachedSumOfSubcomponentValues;
            }
        }

        /// <summary>
        ///     This is the effective profit margin, which is the difference in coin value of this resource vs. the coin value of
        ///     all of the items that are required to produce it.
        /// </summary>
        public double ProfitMargin => Requires.Any()
                                          ? CoinValue - SumOfSubcomponentValues
                                          : CoinValue;


        #region Calculation Cache Backing
        // We cache the results of this calculation because they won't change and so we aren't doing it multiple times whenever
        // we want to look at this value.

        TimeSpan _cachedTimeToProduceSubcomponents;

        bool _isTimeToProduceSubcomponentsCached;


        #endregion


        /// <summary>
        ///     The length of time it takes to craft all required sub-components (and their sub-components) EXCLUDING its own
        ///     crafting time.
        /// </summary>
        public TimeSpan TimeToProduceSubcomponents
        {
            get
            {
                if (!_isTimeToProduceSubcomponentsCached)
                {
                    _cachedTimeToProduceSubcomponents = Requires.Any(m => m.Key.TimeToProduce > TimeSpan.Zero)
                                                            ? TimeSpan.FromSeconds(Requires.Sum(d => d.Key.TotalTimeToProduce.TotalSeconds * d.Value))
                                                            : TimeSpan.Zero;

                    _isTimeToProduceSubcomponentsCached = true;
                }

                return _cachedTimeToProduceSubcomponents;
            }
        }

        /// <summary>
        ///     The length of time it takes to craft all required sub-components (and their sub-components) PLUS the
        ///     <see cref="TimeToProduce" /> the material, itself
        /// </summary>
        public TimeSpan TotalTimeToProduce => TimeToProduceSubcomponents.Add(TimeToProduce);

        /// <summary>
        ///     This is the ratio of the item's coin value to the TOTAL time required (*including* subcomponent production time).
        /// </summary>
        /// <remarks>
        ///     This value could be thought of in "Coins per minute spent producting all required subcomponents"
        /// </remarks>
        public double ProfitToTimeRequiredRatio => CoinValue / TotalTimeToProduce.TotalMinutes;


        #region  Calculation Cache Backing
        // We cache the results of this calculation because they won't change and so we aren't doing it multiple times whenever
        // we want to look at this value.

        IDictionary<ProductionSource, double> _cachedSubcomponentProductionTimeByType;
        bool _isSubcomponentProductionTimeByTypeCached;


        #endregion


        /// <summary>
        ///     The total time required, by production source, for this resource's subcomponents.
        /// </summary>
        /// <remarks>
        ///     If it does not have any subcomponents, this value will its own <see cref="ProducedAt" /> and
        ///     <see cref="TimeToProduce" />.
        ///     This largely exists solely to complement the <see cref="TotalProductionTimeByType" /> calculation.
        /// </remarks>
        IDictionary<ProductionSource, double> SubcomponentProductionTimeByType
        {
            get
            {
                if (!_isSubcomponentProductionTimeByTypeCached)
                {
                    var subs = new Dictionary<ProductionSource, double>();

                    if (Requires.Any())
                    {
                        // We need to iterate through all of the required items...
                        foreach (var s in Requires)
                        {
                            // ...and then iterate through each of the component's different product type times...
                            foreach (var t in s.Key.TotalProductionTimeByType)

                                // ...and add the total production time req'd for each production time, multiplied by the quantity required.
                                IncrementOrAddToDictionary(subs, t.Key, t.Value.TotalMinutes * s.Value);
                        }
                    }
                    else
                    {
                        IncrementOrAddToDictionary(subs, ProducedAt, TimeToProduce.TotalMinutes);
                    }

                    _cachedSubcomponentProductionTimeByType = subs;
                    _isSubcomponentProductionTimeByTypeCached = true;
                }

                return _cachedSubcomponentProductionTimeByType;
            }
        }


        #region  Calculation Cache Backing
        // We cache the results of this calculation because they won't change and so we aren't doing it multiple times whenever
        // we want to look at this value.

        IDictionary<ProductionSource, TimeSpan> _cachedTotalProductionTimeByType;
        bool _isTotalProductionTimeByTypeCached;


        #endregion


        /// <summary>
        ///     The total time required, by each production source, to produce one of the given resource.
        /// </summary>
        public IDictionary<ProductionSource, TimeSpan> TotalProductionTimeByType
        {
            get
            {
                if (!_isTotalProductionTimeByTypeCached)
                {
                    var subs = SubcomponentProductionTimeByType;

                    if (Requires.Any())
                        IncrementOrAddToDictionary(subs, ProducedAt, TimeToProduce.TotalMinutes);

                    _cachedTotalProductionTimeByType = new ReadOnlyDictionary<ProductionSource, TimeSpan>(subs.ToDictionary(t => t.Key, t => TimeSpan.FromMinutes(t.Value)));
                    _isTotalProductionTimeByTypeCached = true;
                }

                return _cachedTotalProductionTimeByType;
            }
        }


        #endregion
    }
}