using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.DTOs;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private ProdutoContext _categoriaContext;
    private IMapper _mapper;

    public CategoriaController(ProdutoContext categoriaContext, IMapper mapper)
    {
        _categoriaContext = categoriaContext;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionaCategoria([FromBody] CreateCategoriaDTO categoriaDTO)
    {
        Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);
        _categoriaContext.Categorias.Add(categoria);
        _categoriaContext.SaveChanges();
        return CreatedAtAction(nameof(BuscaCategoria),
            new { nome = categoria.Nome },
            categoriaDTO);
    }

    [HttpGet]
    public IEnumerable<ReadCategoriaDTO> ListarCategorias()
    {
        return _mapper.Map<List<ReadCategoriaDTO>>(_categoriaContext.Categorias.ToList());
    }

    [HttpGet("{nome}")]
    public IActionResult BuscaCategoria(string nome)
    {
        Categoria categoria = _categoriaContext.Categorias.FirstOrDefault(categoria => categoria.Nome == nome);
        if (categoria == null) return NotFound();
        ReadCategoriaDTO categoriaDTO = _mapper.Map<ReadCategoriaDTO>(categoria);
        return Ok(categoriaDTO);
    }

    [HttpPut("{Nome}")]
    public IActionResult AtualizarCategoria(string Nome, [FromBody] UpdateCategoriaDTO categoriaDTO)
    {
        Categoria categoria = _categoriaContext.Categorias.FirstOrDefault(categoria => categoria.Nome == Nome);
        if (categoria == null) return NotFound();
        _mapper.Map(categoriaDTO, categoria);
        _categoriaContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{Nome}")]
    public IActionResult DeletaCategoria(string Nome)
    {
        Categoria categoria = _categoriaContext.Categorias.FirstOrDefault(categoria => categoria.Nome == Nome);
        if (categoria == null) return NotFound();
        _categoriaContext.Remove(categoria);
        _categoriaContext.SaveChanges();
        return NoContent();

    }
}
