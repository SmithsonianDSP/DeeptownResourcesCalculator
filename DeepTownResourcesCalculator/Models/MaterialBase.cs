using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace DeepTownResourcesCalculator
{
    public sealed class MaterialBase
    {
        public string Name { get; set; }

        public Dictionary<MaterialBase, double> Requires { get; } = new Dictionary<MaterialBase, double>();

        public int CoinValue { get; set; }

        public TimeSpan TimeToCraft { get; set; } = TimeSpan.FromSeconds(0);




        #region Calculated Fields and Properties


        #region Calculation Cache Backing

        double _cachedSumOfParts;

        bool _isSumOfPartsCached;

        TimeSpan _cachedSumToPartsToCraft;

        bool _isSumOfPartsToCraftCached;

        #endregion

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


        public double TotalSumOfParts => Requires.Any()
                                             ? SumOfParts + CoinValue
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
