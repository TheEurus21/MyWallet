using Microsoft.EntityFrameworkCore;

namespace Kif.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {

    }
    public DbSet<Wallet>Wallets { get; set; }
    public DbSet<ChargeTransaction> ChargeTransactions { get; set; }

}

