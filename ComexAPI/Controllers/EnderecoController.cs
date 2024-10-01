using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.DTOs;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private ProdutoContext _enderecoContext;
    private IMapper _mapper;

    public EnderecoController(ProdutoContext enderecoContext, IMapper mapper)
    {
        _enderecoContext = enderecoContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
        _enderecoContext.Enderecos.Add(endereco);
        _enderecoContext.SaveChanges();
        return CreatedAtAction(nameof(BuscaEndereco),
            new { id = endereco.ID },
            enderecoDTO);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDTO> ListarEnderecos()
    {
        return _mapper.Map<List<ReadEnderecoDTO>>(_enderecoContext.Enderecos);
    }

    [HttpGet("{ID}")]
    public IActionResult BuscaEndereco(int ID)
    {
        Endereco endereco = _enderecoContext.Enderecos.FirstOrDefault(endereco => endereco.ID == ID);
        if (endereco == null) return NotFound();
        ReadEnderecoDTO enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);
        return Ok(enderecoDTO);
    }

    [HttpPut("{ID}")]
    public IActionResult AtualizarEndereco(int ID, [FromBody] UpdateEnderecoDTO enderecoDto)
    {
        Endereco endereco = _enderecoContext.Enderecos.FirstOrDefault(endereco => endereco.ID == ID);
        if (endereco == null) return NotFound();
        _mapper.Map(enderecoDto, endereco);
        _enderecoContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{ID}")]
    public IActionResult DeletaEndereco(int ID)
    {
        Endereco endereco = _enderecoContext.Enderecos.FirstOrDefault(endereco => endereco.ID == ID);
        if (endereco == null) return NotFound();
        _enderecoContext.Remove(endereco);
        _enderecoContext.SaveChanges();
        return NoContent();

    }
}
