﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWeb.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Autor> autor { get; set; }

        public DbSet<Emprestimo> emprestimo { get; set; }

        public DbSet<Genero> genero { get; set; }

        public DbSet<Livro> livro { get; set; }

        public DbSet<Usuario> usuario { get; set; }
    }

}
