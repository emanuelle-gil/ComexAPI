﻿using ComexAPI.Models;

namespace ComexAPI.Data.DTOs;

public class UpdateEnderecoDTO
{
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Complemento { get; set; }
    public string Estado { get; set; }
    public string Rua { get; set; }
    public int Numero { get; set; }
}
