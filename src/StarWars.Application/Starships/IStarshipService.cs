using StarWars.Application.Starships.Dto;
using StarWars.Core.Models.Starships;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Application.Starships
{
    /// <summary>
    /// Starship service to manipulate swapi.dev APIs.
    /// </summary>
    public interface IStarshipService
    {
        /// <summary>
        /// Gets list of all Starships.
        /// </summary>
        Task<List<Starship>> GetAllAsync();

        /// <summary>
        /// Gets list of all Starships with Resupply count for given distance. 
        /// </summary>
        /// <param name="distance">The distance to destination planet in megalights.</param>
        Task<List<StarshipDto>> GetAllWithResupplyCountAsync(ulong distance);
    }
}
