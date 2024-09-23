using Microsoft.EntityFrameworkCore;
using ComexAPI.Models;

namespace ComexAPI.Data;

public class ProdutoContext : DbContext
{
    public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts)
    {

    }
    public DbSet<Produto> Produtos { get; set; }
}
