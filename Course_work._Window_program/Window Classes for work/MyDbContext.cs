using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Course_work._Window_program
{
    internal class MyDbContext : DbContext
    {
        public MyDbContext() : base("WindowShop") { }

        public DbSet<Material> Materials { get; set; }
        public DbSet<PlasticType> PlasticTypes { get; set; }
        public DbSet<GlassType> GlassTypes { get; set; }
        public DbSet<WindowOrder> WindowOrders { get; set; }
    }
}
