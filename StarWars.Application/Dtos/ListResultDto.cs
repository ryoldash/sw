using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Application.Dtos
{
    /// <summary>
    /// Generic Dto that standardize a list of items to clients.
    /// </summary>
    /// <typeparam name="T">Type of the items in the <see cref="Results"/> list</typeparam>
    public class ListResultDto<T>
    {
        /// <summary>
        /// Gets the number of items in the list.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// List of items.
        /// </summary>
        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
