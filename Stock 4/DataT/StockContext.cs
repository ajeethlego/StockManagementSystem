using Microsoft.EntityFrameworkCore;
using Stock_4.Models;
using Stock4.Models;

namespace Stock4.DataT
{
    public class StockContext : DbContext
    {
        public StockContext() { }
        public StockContext(DbContextOptions<StockContext> options) : base(options) { }

        public DbSet<StockList> stockLists { get; set; }
        
        public DbSet<AdminDetails> adminDetails { get; set; }
        public DbSet<AuthorizedUser> authorizedUsers { get; set; }
        public DbSet<UserWatchlist1> UserWatchlist1 { get; set; }
        public DbSet<UserPortfolio> userPortfolios { get; set; }
        //public DbSet<API_HolidayLocal> aPI_HolidayLocals { get; set; }


        


        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<AuthorizedUser>()
            //    .HasMany(s => s.stockLists)
            //    .WithOne(u => u.User)
            //    .Isrequired();


            builder.Entity<StockList>()
                .HasMany(w => w.UserWatchlist1)
                .WithOne(s => s.Stock)
                .IsRequired();

            builder.Entity<AuthorizedUser>()
                .HasMany(w => w.UserWatchlist1)
                .WithOne(u => u.User)
                .IsRequired();

            builder.Entity<StockList>()
                .HasMany(w => w.userPortfolios)
                .WithOne(s => s.Stock)
                .IsRequired();

            builder.Entity<AuthorizedUser>()
                .HasMany(w => w.userPortfolios)
                .WithOne(u => u.User)
                .IsRequired();

            base.OnModelCreating(builder);


        }
        //public DbSet<API_HolidayLocal> aPI_HolidayLocals { get; set; }


        


        
        public DbSet<Stock_4.Models.API_HolidayLocal> API_HolidayLocal { get; set; }
        
    }
}
