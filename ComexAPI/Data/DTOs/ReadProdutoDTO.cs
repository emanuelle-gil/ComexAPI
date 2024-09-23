using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.DTOs;

public class ReadProdutoDTO
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
}
