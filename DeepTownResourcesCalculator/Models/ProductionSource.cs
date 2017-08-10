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


namespace DeepTownResourcesCalculator
{
    public sealed partial class ResourceBaseModel
    {
        /// <summary>
        ///     An enumeration of the possible locations where a material is produced
        /// </summary>
        public enum ProductionSource
        {
            MineralMine,
            ChemicalMine,
            OilPump,
            Smelter,
            Crafting,
            Chemistry,
            Jeweler,
            GreenHouse,
            WaterCollector,
            UraniumEnrichment
        }
    }
}