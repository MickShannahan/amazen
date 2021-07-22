using System.ComponentModel.DataAnnotations;

namespace amazen.Models
{
  public class Product
  {
    public int Id { get; set; }
    [Required]
    public int MerchantId { get; set; }
    public string CreatorId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public double Price { get; set; }
    public string ImgUrl { get; set; }
    public int Qty { get; set; }
  }

  public class ProductMerchantView : Product
  {
    public Merchant Merchant { get; set; }

  }
}