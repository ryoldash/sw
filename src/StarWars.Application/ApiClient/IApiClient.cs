using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Application.ApiClient
{
    /// <summary>
    /// The interface to call Rest APIs.
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// Calls HTTP GET method for a given resource. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">Resource to be called.</param>
        /// <param name="payload">Obejct to be added to the payload</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string resource, object payload = null) where T : new();
    }
}
