using FiosEntreNos.Models;
using Microsoft.EntityFrameworkCore;

namespace FiosEntreNos.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }
    public DbSet<ProductModel> Product { get; set; }
    public DbSet<ProductImageModel> ProductImage { get; set; }
}