using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Core.Models.Starships
{
    /// <summary>
    /// 
    /// </summary>
    public class StarshipManager
    {
        /// <summary>
        /// Converts consumables to hours.
        /// </summary>
        /// <param name="consumables">The maximum length of time that this starship can provide consumables for its entire crew without having to resupply.
        ///     example input: 6 months
        /// </param>
        public static ulong ConsumablesToHours(string consumables)
        {
            // verify that input is not null
            if (string.IsNullOrEmpty(consumables))
                throw new ArgumentNullException(nameof(consumables));

            // verif that consumable is splitted in two 
            try
            {
                // split the consumables into a temporary array
                var consumableArray = consumables.Split(' ');

                // the first index of the array is a numeric value so convert it to double
                ulong multiplicand = Convert.ToUInt64(consumableArray[0]);

                // holds the product of consumables in hours
                ulong product;

                switch (consumableArray[1])
                {
                    case "hour":
                    case "hours":
                        product = multiplicand;
                        break;
                    case "day":
                    case "days":
                        product = multiplicand * 24;
                        break;
                    case "week":
                    case "weeks":
                        product = multiplicand * 7 * 24;
                        break;
                    case "month":
                    case "months":
                        product = multiplicand * 30 * 24;
                        break;
                    case "year":
                    case "years":
                        product = multiplicand * 365 * 24;
                        break;
                    default:
                        throw new ArgumentException($"Argument: {consumableArray[1]} is not known.");
                }

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="megalight"></param>
        /// <param name="consumables"></param>
        public static ulong CalculateResupplyCount(ulong distance, string megalight, string consumables)
        {
            if (distance <= 0)
                throw new ArgumentException("Distance cannot be less than zero", nameof(distance));

            if (string.IsNullOrEmpty(megalight))
                throw new ArgumentNullException(nameof(megalight));

            if (string.IsNullOrEmpty(consumables))
                throw new ArgumentNullException(nameof(consumables));

            try
            {
                var mglt = Convert.ToUInt64(megalight);
                var consumablesToHours = ConsumablesToHours(consumables);

                return Convert.ToUInt64(Math.Truncate((distance / mglt) / (double)consumablesToHours)); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
