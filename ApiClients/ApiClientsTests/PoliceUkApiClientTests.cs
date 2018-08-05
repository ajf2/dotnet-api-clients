using ApiClients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientsTests {
  [TestClass]
  public class PoliceUkApiClientTests {
    PoliceUkApiClient api = new PoliceUkApiClient();

    [TestMethod]
    public void TestAvailability() {
      var availability = api.GetAvailability();
      Assert.IsTrue(availability.Count() > 0);
    }

    // This was intended to test the API call limits, but all tasks seem to complete normally.
    // I expect an exception to be thrown in the case of an HTTP 429 response.
    // For reference: https://data.police.uk/docs/api-call-limits/
    [TestMethod]
    public void HandlesTooManyRequestsErrorResponse() {
      var tasks = new List<Task>();
      for(int i = 0; i < 1000; i++) {
        tasks.Add(api.GetAvailabilityAsync());
      }
      Task.WaitAll(tasks.ToArray());
      Assert.IsTrue(tasks.All(t => t.Status == TaskStatus.RanToCompletion));
    }

    [TestMethod]
    public async Task TestForceMethods() {
      var forces = await api.GetForcesAsync();
      var detail = await api.GetForceAsync(forces.First().Id);
      var officers = await api.GetSeniorOfficersAsync("leicestershire");
      Assert.IsTrue(forces.Count() > 0);
      Assert.AreEqual(forces.First().Id, detail.Id);
      Assert.IsTrue(officers.Count() > 0);
    }

    [TestMethod]
    public async Task TestCrimeMethods() {
      var slc_specific = await api.GetStreetLevelCrimes(52.629729, -1.131592, new DateTime(2017, 01, 01));
      var v = slc_specific.Where(c => c.OutcomeStatus != null);
      //var slc_custom = await api.GetStreetLevelCrimes();
      //var streetLevelOutcomes = await api.GetStreetLevelOutcomes();
      //var crimesAtLocation = await api.GetCrimesAtLocation();
      //var crimeCategories = await api.GetCrimeCategories();
      //var lastUpdated = await api.GetLastUpdated();
      //var outcomes = await api.GetOutcomes();
    }
  }
}
