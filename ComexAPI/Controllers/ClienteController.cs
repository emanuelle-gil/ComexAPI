using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.DTOs;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private ProdutoContext _clienteContext;
    private IMapper _mapper;

    public ClienteController ( ProdutoContext clienteContext, IMapper mapper)
    {
        _clienteContext = clienteContext;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionaCliente([FromBody] CreateClienteDTO clienteDTO)
    {
        Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
        _clienteContext.Clientes.Add(cliente);
        _clienteContext.SaveChanges();
        return CreatedAtAction(nameof(BuscaCliente),
            new { id = cliente.ID },
            clienteDTO);
    }

    [HttpGet]
    public IEnumerable<ReadClienteDTO> ListarClientes()
    {
        return _mapper.Map<List<ReadClienteDTO>>(_clienteContext.Clientes.ToList());
    }

    [HttpGet("{ID}")]
    public IActionResult BuscaCliente(int ID)
    {
        Cliente cliente  = _clienteContext.Clientes.FirstOrDefault(cliente => cliente.ID == ID);
        if (cliente == null) return NotFound();
        ReadClienteDTO clienteDTO = _mapper.Map<ReadClienteDTO>(cliente);
        return Ok(clienteDTO);
    }

    [HttpPut("{ID}")]
    public IActionResult AtualizarCliente(int ID, [FromBody] UpdateClienteDTO clienteDTO)
    {
        Cliente cliente = _clienteContext.Clientes.FirstOrDefault(cliente => cliente.ID == ID);
        if (cliente == null) return NotFound();
        _mapper.Map(clienteDTO, cliente);
        _clienteContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{ID}")]
    public IActionResult DeletaCliente(int ID)
    {
        Cliente cliente = _clienteContext.Clientes.FirstOrDefault(cliente => cliente.ID == ID);
        if (cliente == null) return NotFound();
        _clienteContext.Remove(cliente);
        _clienteContext.SaveChanges();
        return NoContent();

    }
}
