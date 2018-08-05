using ApiClients.Models.PoliceUk;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients {
  public class PoliceUkApiClient {
    private const string baseUrl = "https://data.police.uk/api";

    private T Execute<T>(RestRequest request) where T : new() {
      var client = new RestClient {
        BaseUrl = new Uri(baseUrl)
      };
      var response = client.Execute<T>(request);
      return HandleResponse(response);
    }

    private async Task<T> ExecuteAsync<T>(RestRequest request) where T : new() {
      var client = new RestClient {
        BaseUrl = new Uri(baseUrl)
      };
      var response = await client.ExecuteTaskAsync<T>(request);
      return HandleResponse(response);
    }

    private T HandleResponse<T>(IRestResponse<T> response) {
      if (response.ErrorException != null) {
        const string message = "Error retrieving response.  Check inner details for more info.";
        var exceptionFromApi = new ApplicationException(message, response.ErrorException);
        throw exceptionFromApi;
      }
      return response.Data;
    }

    /// <summary>
    /// Gets a list of force IDs for forces that have provided stop and search data for this month.
    /// </summary>
    /// <returns>A list of available data sets.</returns>
    public IEnumerable<Availability> GetAvailability() {
      var request = new RestRequest {
        Resource = "crimes-street-dates"
      };
      return Execute<List<Availability>>(request);
    }

    public Task<List<Availability>> GetAvailabilityAsync() {
      var request = new RestRequest {
        Resource = "crimes-street-dates"
      };
      return ExecuteAsync<List<Availability>>(request);
    }

    /// <summary>
    /// Overload of GetAvailability.
    /// Gets a list of force IDs for forces that have provided stop and search data for this month.
    /// </summary>
    /// <returns>A list of available data sets.</returns>
    [Obsolete("GetCrimesStreetDates is deprecated. Please use GetAvailability instead.")]
    public IEnumerable<Availability> GetCrimesStreetDates() {
      return GetAvailability();
    }

    /// <summary>
    /// Gets a list of all the police forces available via the API. Unique force identifiers obtained here are used in requests for force-specific data via other methods.
    /// </summary>
    /// <returns></returns>
    public Task<List<Force>> GetForcesAsync() {
      var request = new RestRequest {
        Resource = "forces"
      };
      return ExecuteAsync<List<Force>>(request);
    }

    /// <summary>
    /// Gets full information about a specific force.
    /// </summary>
    /// <param name="id">The id of the force to look up.</param>
    /// <returns>The detail of the specified force.</returns>
    public Task<ForceDetail> GetForceAsync(string id) {
      var request = new RestRequest {
        Resource = "forces/{id}"
      };
      request.AddUrlSegment("id", id);
      return ExecuteAsync<ForceDetail>(request);
    }

    /// <summary>
    /// Gets a list of all the senior officers of a specfic force.
    /// </summary>
    /// <param name="id">The id of the force to look up.</param>
    /// <returns>The list of the specified force's senior officers.</returns>
    public Task<List<SeniorOfficer>> GetSeniorOfficersAsync(string id) {
      var request = new RestRequest {
        Resource = "forces/{id}/people"
      };
      request.AddUrlSegment("id", id);
      return ExecuteAsync<List<SeniorOfficer>>(request);
    }
  }
}
