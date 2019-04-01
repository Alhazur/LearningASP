using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningASP.Models
{
    public class CakeDbContext : DbContext//Databas
    {
        public CakeDbContext (DbContextOptions<CakeDbContext> options) : base(options) {}
        public DbSet<Cake> Cakes { get; set; }//class kotorij soderjit variable nazvanie i nazvanie lista nada pisat
    }

}
