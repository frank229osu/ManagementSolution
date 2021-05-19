using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApi.Data
{
    public class ManagementDataContext : DbContext
    {

        public ManagementDataContext(DbContextOptions<ManagementDataContext> options): base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
    }
}
