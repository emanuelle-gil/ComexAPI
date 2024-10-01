using ComexAPI.Models;

namespace ComexAPI.Data.DTOs;

public class ReadClienteDTO
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Profissao { get; set; }
    public string Telefone { get; set; }
    public ReadEnderecoDTO Endereco { get; set; }
}
