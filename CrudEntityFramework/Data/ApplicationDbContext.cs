using CrudEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//contexto. tablas mapeadas 
namespace CrudEntityFramework.Data
{
    public class ApplicationDbContext : DbContext
    {



        //constructor: const + 2tab
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //creo la variable dbset Usuario, clase generica usando clase Usuario
        public DbSet<Usuario> Usuario {get; set;}



    }
}
