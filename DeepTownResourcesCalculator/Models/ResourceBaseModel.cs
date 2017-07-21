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
using System.Linq;

namespace DeepTownResourcesCalculator
{
    public sealed class ResourceBaseModel
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


        #region Calculated Fields and Properties


        #region Calculation Cache Backing

        double _cachedSumOfSubcomponentValues;

        bool _isSumOfSubcomponentValuesCached;

        #endregion

        /// <summary>
        ///     This is the sum face-value of all of a material's required subcomponents. If a material does NOT have any
        ///     subcomponents
        ///     (e.g., coal, copper ore, etc.), then this will be the material's own face value.
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
                    _cachedSumOfSubcomponentValues = Requires.Any() && Requires.Sum(d => d.Key.SumOfSubcomponentValues * d.Value) > 0
                                                         ? Requires.Sum(d => d.Key.SumOfSubcomponentValues * d.Value)
                                                         : CoinValue;

                    _isSumOfSubcomponentValuesCached = true;
                }
                return _cachedSumOfSubcomponentValues;
            }
        }

        /// <summary>
        ///     This is the effective profit margin, which is the difference in coin value of this resource vs. the coin value of
        ///     all of the items
        ///     that are required to produce it.
        /// </summary>
        public double ProfitMargin => Requires.Any()
                                          ? CoinValue - SumOfSubcomponentValues
                                          : CoinValue;

        #region Calculation Cache Backing

        TimeSpan _cachedTimeToProduceSubcomponents;

        bool _isTimeToProduceSubcomponentsCached;

        #endregion

        /// <summary>
        ///     The length of time it takes to craft all required sub-components (and their sub-components) EXCLUDING its own
        ///     crafting time
        /// </summary>
        public TimeSpan TimeToProduceSubcomponents
        {
            get
            {
                if (!_isTimeToProduceSubcomponentsCached)
                {
                    _cachedTimeToProduceSubcomponents = Requires.Any() && TimeToProduceSubcomponentsInSeconds > 0
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


        double TimeToProduceSubcomponentsInSeconds => TimeSpan.FromMilliseconds(Requires.Sum(d => d.Key.TotalTimeToProduce.TotalMilliseconds * d.Value)).TotalSeconds;


        /// <summary>
        ///     This is the ratio of the item's coin value to the TOTAL time required (*including* subcomponent production time).
        /// </summary>
        /// <remarks>
        ///     This value could be thought of in "Coins per minute spent producting all required subcomponents"
        /// </remarks>
        public double ProfitToTimeRequiredRatio => CoinValue / TotalTimeToProduce.TotalMinutes;


        #endregion
    }
}