using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities;

[Table("produto")]
public class Produto
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Altura { get; set; }
    public decimal Largura { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public bool Ativo { get; set; }
}