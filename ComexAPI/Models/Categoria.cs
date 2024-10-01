using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Models;

public class Categoria
{
    [Key]
    [Required]
    public int ID { get; set; }
    [Required]
    public string Nome { get; set; }
    public virtual ICollection<Produto> Produtos { get; set; }
}
