using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities;

[Table("produto")]
public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Height { get; set; }
    public decimal Width { get; set; }
    public decimal Price { get; set; }
    public DateTime DateIncluded { get; set; }
    public DateTime DateChange { get; set; }
    public bool Active { get; set; }
}