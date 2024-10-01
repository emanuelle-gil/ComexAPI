﻿using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int ID { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Complemento { get; set; }
    public string Estado { get; set; }
    public string Rua { get; set; }
    public int Numero { get; set; }
    public virtual Cliente Cliente { get; set; }
}
