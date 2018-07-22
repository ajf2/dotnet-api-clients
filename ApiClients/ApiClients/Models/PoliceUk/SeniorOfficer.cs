namespace ApiClients.Models.PoliceUk {
  public class SeniorOfficer {
    /// <summary>
    /// Senior officer biography (if available).
    /// </summary>
    public string Bio { get; set; }
    /// <summary>
    /// Contact details for the senior officer.
    /// </summary>
    public ContactDetails ContactDetails { get; set; }
    /// <summary>
    /// Name of the person.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Force rank.
    /// </summary>
    public string Rank { get; set; }
  }
}
