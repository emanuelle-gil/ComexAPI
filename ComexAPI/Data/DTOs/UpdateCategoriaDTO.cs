using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.DTOs;

public class UpdateCategoriaDTO
{
    [Required]
    public string Nome { get; set; }
}
