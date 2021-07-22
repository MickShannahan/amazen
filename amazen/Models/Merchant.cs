using System.ComponentModel.DataAnnotations;

namespace amazen.Models
{
  public class Merchant
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Category { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
  }
}