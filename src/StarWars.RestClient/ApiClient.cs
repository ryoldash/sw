using RestSharp;
using StarWars.Application.ApiClient;
using System;
using System.Net;
using System.Threading.Tasks;

namespace StarWars.RestSharp
{
    /// <summary>
    /// The Api client implementation with RestClient.
    /// </summary>
    public class ApiClient : IApiClient
    {
        private readonly IRestClient client;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="baseUrl">Base URL of API.</param>
        public ApiClient(string baseUrl)
        {
            this.client = new RestClient(baseUrl);
        }

        /// <summary>
        /// Calls HTTP GET method for a given resource. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">Resource to be called.</param>
        /// <param name="payload">Obejct to be added to the payload</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string resource, object payload = null) where T : new()
        {
            TaskCompletionSource<IRestResponse<T>> taskCompletion = new TaskCompletionSource<IRestResponse<T>>();
            var request = new RestRequest(resource, Method.GET);
            request.JsonSerializer = new global::RestSharp.Newtonsoft.Json.NetCore.NewtonsoftJsonSerializer();

            if (payload != null)
            {               
                request.AddJsonBody(payload);
            }

            RestRequestAsyncHandle handle = this.client.ExecuteAsync<T>(request, r => taskCompletion.SetResult(r));
            var result = await taskCompletion.Task;
            if (result.ErrorException != null)
            {
                throw result.ErrorException;
            }

            // response error
            if (result.StatusCode != HttpStatusCode.OK && result.StatusCode != HttpStatusCode.Accepted && result.StatusCode != HttpStatusCode.NoContent && result.StatusCode != HttpStatusCode.Created)
            {
                throw new Exception($"Request error. Status Code: {result.StatusCode}. Content: {result.Content}");
            }

            return result.Data;
        }
    }
}
