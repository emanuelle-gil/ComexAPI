using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.DTOs;
using ComexAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private ProdutoContext _produtoContext;
    private IMapper _mapper;

    public ProdutoController(ProdutoContext produtoContext, IMapper mapper)
    {
        _produtoContext = produtoContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um produto ao banco de dados
    /// </summary>
    /// <param name="produtoDTO">Objeto com os campos necessários para criação de um produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaProduto([FromBody] CreateProdutoDTO produtoDTO)
    {
        Produto produto = _mapper.Map<Produto>(produtoDTO);
        _produtoContext.Produtos.Add(produto);
        _produtoContext.SaveChanges();
        return CreatedAtAction(nameof(BuscaProduto),
            new { nome = produto.Nome },
            produto);
    }

    /// <summary>
    /// Lista todos os produtos cadastrados no banco de dados.
    /// </summary>
    /// <response code="200">Retorna uma lista de produtos se obtiver sucesso.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadProdutoDTO> ListarProdutos()
    {
        return _mapper.Map<List<ReadProdutoDTO>>(_produtoContext.Produtos);
    }

    /// <summary>
    /// Busca um produto no banco de dados pelo nome.
    /// </summary>
    /// <param name="Nome">O nome do produto a ser buscado.</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Retorna o produto encontrado com sucesso.</response>
    [HttpGet("{Nome}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult BuscaProduto(string Nome)
    {
        var produto = _produtoContext.Produtos.FirstOrDefault(produto => produto.Nome == Nome);
        if (produto == null) return NotFound();
        var produtoDTO = _mapper.Map<ReadProdutoDTO>(produto);
        return Ok(produtoDTO);
    }

    /// <summary>
    /// Atualiza um produto existente no banco de dados pelo nome.
    /// </summary>
    /// <param name="Nome">O nome do produto a ser atualizado.</param>
    /// <param name="produtoDto">Objeto contendo os campos a serem atualizados.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Produto atualizado com sucesso.</response>
    [HttpPut("{Nome}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizarProduto(string Nome, [FromBody] UpdateProdutoDTO produtoDto)
    {
        var produto = _produtoContext.Produtos.FirstOrDefault(produto=>produto.Nome == Nome);
        if (produto == null) return NotFound();
        _mapper.Map(produtoDto, produto);
        _produtoContext.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um produto existente no banco de dados pelo nome.
    /// </summary>
    /// <param name="Nome">O nome do produto a ser deletado.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Produto deletado com sucesso.</response>
    [HttpDelete("{Nome}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletaProduto(string Nome)
    {
        var produto = _produtoContext.Produtos.FirstOrDefault(produto => produto.Nome == Nome);
        if (produto == null) return NotFound();
        _produtoContext.Remove(produto);
        _produtoContext.SaveChanges();
        return NoContent();

    }


}
