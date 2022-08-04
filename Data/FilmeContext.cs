using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data
{
    // Classe para cuidar do banco tem que herdar o DbContext
    public class FilmeContext : DbContext
    {

        // O Construtor vai passar as OPT para o construtor base
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base (opt)
        {

        }

        public DbSet<Filme> Filmes { get; set; }

    }
}
