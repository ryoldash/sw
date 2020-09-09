using StarWars.Core.Models.Starships;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.Starships.Dto
{
    /// <summary>
    /// Starship data transfer object.
    /// </summary>
    public class StarshipDto : Starship
    {
        /// <summary>
        /// Gets or Sets total resupply needed for the Starship to reach the 
        /// distination planet.
        /// </summary>
        public ulong ResupplyCount { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.ResupplyCount}";
        }
    }
}
