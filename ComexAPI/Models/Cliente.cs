﻿using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Models;

public class Cliente
{
    [Key]
    [Required]
    public int ID { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Profissao { get; set; }
    public string Telefone { get; set; }
    public int EnderecoID { get; set; }
    public virtual Endereco Endereco { get; set; }
}
