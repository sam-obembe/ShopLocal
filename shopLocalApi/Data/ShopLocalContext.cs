using Microsoft.EntityFrameworkCore;
//using shopLocalApi.Data.Entities;
using shopLocalCommonModels.DbEntities;

namespace shopLocalApi.Data
{
    public class ShopLocalContext : DbContext
    {

        public DbSet<ShopEntity> Shops { get; set; }
        public DbSet<ItemEntity> Items { get; set; }

        public ShopLocalContext(DbContextOptions<ShopLocalContext> options) : base(options)
        {

        }

    }
}