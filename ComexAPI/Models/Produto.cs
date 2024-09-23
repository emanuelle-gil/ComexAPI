using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Models;

public class Produto
{
    [Key]
    [Required]
    public int ID { get; set; }
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    [MaxLength(100)]
    public string Nome { get; set; }
    [MaxLength(500)]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "O valor do produto é obrigatório")]
    [Range(0.01, double.MaxValue)]
    public double PrecoUnitario { get; set; }
    [Required(ErrorMessage = "A quantidade do produto é obrigatória")]
    [Range(0, int.MaxValue)]
    public int Quantidade { get; set; }
}
