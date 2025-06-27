using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiosEntreNos.Models;

[Table("product")]
public class ProductModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Height { get; set; }
    public decimal Width { get; set; }
    public decimal Price { get; set; }
    public DateTime DateInclude { get; set; }
    public DateTime DateChange { get; set; }
    public bool Active { get; set; }
    
    public virtual ICollection<ProductImageModel> ProductImages { get; set; } = new List<ProductImageModel>();
}