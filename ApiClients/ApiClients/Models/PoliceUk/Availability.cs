using System;
using System.Collections.Generic;

namespace ApiClients.Models.PoliceUk {
  public class Availability {
    /// <summary>
    /// Year and month of all available street level crime data.
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// A list of force IDs for forces that have provided stop and search data for this month.
    /// </summary>
    public IEnumerable<string> StopAndSearch { get; set; }
  }
}
