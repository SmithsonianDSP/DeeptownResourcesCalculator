using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace DeepTownResourcesCalculator
{
    public sealed class MaterialBase
    {
        public string Name { get; set; }

        public Dictionary<MaterialBase, double> Requires { get; } = new Dictionary<MaterialBase, double>();

        public int CoinValue { get; set; } = 0;

        public TimeSpan TimeToCraft { get; set; } = TimeSpan.FromSeconds(0);


        double _cachedSumOfParts;
        bool _isSumOfPartsCached;
        public double SumOfParts
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

        public double TotalSumOfParts => SumOfParts + CoinValue;

        TimeSpan _cachedSumToPartsToCraft;
        bool _isSumOfPartsToCraftCached;

        /// <summary>
        ///     The length of time it takes to craft all required sub-components (and their sub-components) PLUS the <see cref="TimeToCraft"/> the material, itself
        /// </summary>
        public TimeSpan SumOfPartsToCraft
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

        public TimeSpan TotalTimeToCraft => SumOfPartsToCraft.Add(TimeToCraft);


        double sumOfPartsInSeconds => Requires.Sum(d => d.Key.SumOfPartsToCraft.TotalSeconds * d.Value);


        public double ProfitToTimeRequiredRatio => (CoinValue - SumOfParts) / TotalTimeToCraft.TotalMinutes;

    }


}
