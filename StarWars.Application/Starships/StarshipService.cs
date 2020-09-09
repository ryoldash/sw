using StarWars.Application.ApiClient;
using StarWars.Application.Dtos;
using StarWars.Application.Starships.Dto;
using StarWars.Core;
using StarWars.Core.Models.Starships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Application.Starships
{
    /// <summary>
    /// The implementation for Starship. 
    /// </summary>
    public class StarshipService : IStarshipService
    {
        private readonly IApiClient apiClient;

        /// <summary>
        /// The constructor. 
        /// </summary>
        /// <param name="apiClient">Api Client to call external REST APIs.</param>
        public StarshipService(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// Gets list of all Starships.
        /// </summary>
        public async Task<List<Starship>> GetAllAsync()
        {
            return (await this.apiClient.GetAsync<ListResultDto<Starship>>(Constants.Endpoints.Starships.Base)).Results;
        }

        /// <summary>
        /// Gets list of all Starships with Resupply count for given distance. 
        /// </summary>
        /// <param name="distance">The distance to destination planet in megalights.</param>
        public async Task<List<StarshipDto>> GetAllWithResupplyCountAsync(ulong distance)
        {
            if (distance <= 0)
                throw new ArgumentException("Distance cannot be less than zero", nameof(distance));

            // get all starships
            var starships = await this.GetAllAsync();

            // calculate the resupply count for each starship in the list
            var starshipListDto = from starship in starships
                                  select new StarshipDto
                                  {
                                      // TODO: Auto Mapper could be used for object to object mapping.
                                      Name = starship.Name,
                                      Model = starship.Model,
                                      StarshipClass = starship.StarshipClass,
                                      Manufacturer = starship.Manufacturer,
                                      CostInCredits = starship.CostInCredits,
                                      Length = starship.Length,
                                      Crew = starship.Crew,
                                      Passengers = starship.Passengers,
                                      MaxAtmospheringSpeed = starship.MaxAtmospheringSpeed,
                                      HyperdriveRating = starship.HyperdriveRating,
                                      MGLT = starship.MGLT,
                                      CargoCapacity = starship.CargoCapacity,
                                      Consumables = starship.Consumables,
                                      ResupplyCount = StarshipManager.CalculateResupplyCount(distance, starship.MGLT, starship.Consumables)
                                  };
            
            return starshipListDto.ToList();
        }
    }
}
