using System.ComponentModel.DataAnnotations;
using ComexAPI.Models;

namespace ComexAPI.Data.DTOs;

public class ReadCategoriaDTO
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public ICollection<Produto> Produtos { get; set; }
}
