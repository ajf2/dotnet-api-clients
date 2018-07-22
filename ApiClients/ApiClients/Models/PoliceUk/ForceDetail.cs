using System.Collections.Generic;

namespace ApiClients.Models.PoliceUk {
  public class ForceDetail {
    public string Description { get; set; }
    /// <summary>
    /// Force website URL.
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// Ways to keep informed.
    /// </summary>
    public IEnumerable<EngagementMethod> EngagementMethods { get; set; }
    /// <summary>
    /// Force telephone number.
    /// </summary>
    public string Telephone { get; set; }
    /// <summary>
    /// Unique force identifier.
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Force name.
    /// </summary>
    public string Name { get; set; }
  }
}
