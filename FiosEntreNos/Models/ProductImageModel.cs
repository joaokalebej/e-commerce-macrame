using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiosEntreNos.Models;

[Table("productimage")]
public class ProductImageModel
{
    [Key]
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public bool IsMain { get; set; }
    public int ProductId { get; set; }
    public ProductModel Product { get; set; }
}