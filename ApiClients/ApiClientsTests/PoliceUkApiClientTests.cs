using ApiClients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ApiClientsTests {
  [TestClass]
  public class PoliceUkApiClientTests {
    [TestMethod]
    public void TestAvailability() {
      var api = new PoliceUkApiClient();
      var availability = api.GetAvailability();
      Assert.IsTrue(availability.Count() > 0);
    }
  }
}
