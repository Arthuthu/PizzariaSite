using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzariaLibrary.Models;

    public class PizzariaContext : DbContext
    {
        public PizzariaContext (DbContextOptions<PizzariaContext> options)
            : base(options)
        {
        }

        public DbSet<PizzariaLibrary.Models.Pizza> Pizza { get; set; } = default!;
    }
