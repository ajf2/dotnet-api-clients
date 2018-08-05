using System;
using System.Collections.Generic;

namespace ApiClients.Models.PoliceUk {
  public class StreetLevelCrime {
    public string Category { get; set; }
    public string LocationType { get; set; }
    public Location Location { get; set; }
    public string Context { get; set; }
    public IDictionary<string, dynamic> OutcomeStatus { get; set; }
    public string PersistentId { get; set; }
    public int Id { get; set; }
    public string LocationSubtype { get; set; }
    public DateTime Month { get; set; }
  }
}
