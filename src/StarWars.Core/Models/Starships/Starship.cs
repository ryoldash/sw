using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Core.Models.Starships
{
    /// <summary>
    /// A Starship resource is a single transport craft that has hyperdrive capability.
    /// </summary>
    public class Starship
    {
        /// <summary>
        /// The name of this Starship.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The model or official name of this starship. Such as "T-65 X-wing" or "DS-1 Orbital Battle Station".
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// The class of this starship, such as "Starfighter" or "Deep Space Mobile Battlestation"
        /// </summary>
        [JsonProperty("starship_class")]
        public string StarshipClass { get; set; }

        /// <summary>
        /// The manufacturer of this starship. Comma separated if more than one.
        /// </summary>
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// The cost of this starship new, in galactic credits.
        /// </summary>
        [JsonProperty("cost_in_credits")]
        public string CostInCredits { get; set; }

        /// <summary>
        /// The length of this starship in meters.
        /// </summary>
        [JsonProperty("length")]
        public string Length { get; set; }

        /// <summary>
        /// The number of personnel needed to run or pilot this starship.
        /// </summary>
        [JsonProperty("crew")]
        public string Crew { get; set; }

        /// <summary>
        ///  The number of non-essential people this starship can transport.
        /// </summary>
        [JsonProperty("passengers")]
        public string Passengers { get; set; }

        /// <summary>
        /// The maximum speed of this starship in the atmosphere. "N/A" if this starship is incapable of atmospheric flight.
        /// </summary>
        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        /// <summary>
        /// The class of this starships hyperdrive.
        /// </summary>
        [JsonProperty("hyperdrive_rating")]
        public string HyperdriveRating { get; set; }

        /// <summary>
        /// The Maximum number of Megalights this starship can travel in a standard hour. 
        /// A "Megalight" is a standard unit of distance and has never been defined before within the Star Wars universe. 
        /// This figure is only really useful for measuring the difference in speed of starships. We can assume it is similar to AU, 
        /// the distance between our Sun (Sol) and Earth.
        /// </summary>
        [JsonProperty("MGLT")]
        public string MGLT { get; set; }

        /// <summary>
        /// The maximum number of kilograms that this starship can transport.
        /// </summary>
        [JsonProperty("cargo_capacity")]
        public string CargoCapacity { get; set; }

        /// <summary>
        /// The maximum length of time that this starship can provide consumables for its entire crew without having to resupply.
        /// </summary>
        [JsonProperty("consumables")]
        public string Consumables { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
