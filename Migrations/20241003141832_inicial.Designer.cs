﻿// <auto-generated />
using System;
using BibliotecaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaWeb.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241003141832_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotecaWeb.Models.Autor", b =>
                {
                    b.Property<int>("autorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("autorId"));

                    b.Property<int>("nascimento")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("autorId");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("BibliotecaWeb.Models.Emprestimo", b =>
                {
                    b.Property<int>("emprestimoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("emprestimoId"));

                    b.Property<DateTime>("dataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataEmprestimo")
                        .HasColumnType("datetime2");

                    b.Property<int>("livroId")
                        .HasColumnType("int");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("emprestimoId");

                    b.HasIndex("livroId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("BibliotecaWeb.Models.Genero", b =>
                {
                    b.Property<int>("generoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("generoId"));

                    b.Property<int>("assunto")
                        .HasColumnType("int");

                    b.HasKey("generoId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("BibliotecaWeb.Models.Livro", b =>
                {
                    b.Property<int>("livroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("livroId"));

                    b.Property<int>("autorId")
                        .HasColumnType("int");

                    b.Property<int>("generoId")
                        .HasColumnType("int");

                    b.Property<int>("publicacao")
                        .HasColumnType("int");

                    b.Property<int>("quantiaEstoque")
                        .HasColumnType("int");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("livroId");

                    b.HasIndex("autorId");

                    b.HasIndex("generoId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("BibliotecaWeb.Models.Usuario", b =>
                {
                    b.Property<int>("usuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("usuarioId"));

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateOnly>("dataRegistro")
                        .HasColumnType("date");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("usuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BibliotecaWeb.Models.Emprestimo", b =>
                {
                    b.HasOne("BibliotecaWeb.Models.Livro", "livro")
                        .WithMany()
                        .HasForeignKey("livroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaWeb.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("livro");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BibliotecaWeb.Models.Livro", b =>
                {
                    b.HasOne("BibliotecaWeb.Models.Autor", "autor")
                        .WithMany()
                        .HasForeignKey("autorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaWeb.Models.Genero", "genero")
                        .WithMany()
                        .HasForeignKey("generoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("autor");

                    b.Navigation("genero");
                });
#pragma warning restore 612, 618
        }
    }
}
