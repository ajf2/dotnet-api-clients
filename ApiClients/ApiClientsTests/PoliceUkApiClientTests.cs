using System;
using System.Collections.Generic;
using System.Linq;
using ApiClients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiClientsTests {
  [TestClass]
  public class PoliceUkApiClientTests {
    [TestMethod]
    public void TestAvailability() {
      var api = new PoliceUkApiClient();
      IEnumerable<dynamic> availability = api.GetAvailability();
      Assert.IsTrue(availability.Count() > 0);
    }
  }
}
