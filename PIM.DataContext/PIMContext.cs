using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.DataContext
{
    public class PIMContext : DbContext
    {
        public PIMContext() : base("PIMContext")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
