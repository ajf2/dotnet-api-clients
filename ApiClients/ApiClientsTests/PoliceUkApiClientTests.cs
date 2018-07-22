using ApiClients;
using ApiClients.Models.PoliceUk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientsTests {
  [TestClass]
  public class PoliceUkApiClientTests {
    [TestMethod]
    public void TestAvailability() {
      var api = new PoliceUkApiClient();
      var availability = api.GetAvailability();
      Assert.IsTrue(availability.Count() > 0);
    }

    // This was intended to test the API call limits, but all tasks seem to complete normally.
    // I expect an exception to be thrown in the case of an HTTP 429 response.
    // For reference: https://data.police.uk/docs/api-call-limits/
    [TestMethod]
    public void HandlesTooManyRequestsErrorResponse() {
      var api = new PoliceUkApiClient();
      var tasks = new List<Task>();
      for(int i = 0; i < 1000; i++) {
        tasks.Add(api.GetAvailabilityAsync());
      }
      Task.WaitAll(tasks.ToArray());
      Assert.IsTrue(tasks.All(t => t.Status == TaskStatus.RanToCompletion));
    }
  }
}
