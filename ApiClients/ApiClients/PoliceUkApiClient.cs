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

    /// <summary>
    /// Overload of GetAvailability.
    /// Gets a list of force IDs for forces that have provided stop and search data for this month.
    /// </summary>
    /// <returns>A list of available data sets.</returns>
    [Obsolete("GetCrimesStreetDates is deprecated. Please use GetAvailability instead.")]
    public IEnumerable<Availability> GetCrimesStreetDates() {
      return GetAvailability();
    }
  }
}
