using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace Persistencia
{
    public class SeguroDbContext : DbContext
    {
        public DbSet<Apolice> Apolice { get; set; }

        public SeguroDbContext(DbContextOptions<SeguroDbContext> options)
           : base(options)
        { }
    }
}
