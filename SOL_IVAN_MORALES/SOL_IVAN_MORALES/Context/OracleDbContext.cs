using SOL_IVAN_MORALES.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;

namespace SOL_IVAN_MORALES.Context
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext() : base("OracleDbContext1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("IVAN");
            modelBuilder.Entity<LIBRO>().ToTable("LIBRO");
            modelBuilder.Entity<USUARIO>().ToTable("USUARIO");
            modelBuilder.Entity<PRESTAMO>().ToTable("PRESTAMO");
        }

        public DbSet<LIBRO> Libro { get; set; }
        public DbSet<USUARIO> Usuario { get; set; }
        public DbSet<PRESTAMO> Prestamo { get; set; }
    }
}