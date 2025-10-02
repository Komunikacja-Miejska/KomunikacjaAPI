using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Trasa> Trasy { get; set; }
        public DbSet<Kurs> Kursy { get; set; }
        public DbSet<KursyPrzystanek> KursyPrzystanki { get; set; }
        public DbSet<Przystanek> Przystanki { get; set; }
    }
}