using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JeuDeCarte.Models
{
    public class CarteContext : DbContext
    {
        public CarteContext(DbContextOptions<CarteContext> options)
            : base(options)
        {
        }

        public DbSet<ModeleCarte> ModeleCartes { get; set; }
        public DbSet<UnJeuDeCarte> UnJeuDeCarte { get; set; }

    }
}
