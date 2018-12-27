using System;
using System.Collections.Generic;
using System.Text;
using Back_End.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Back_End.DbContexts
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<MapModel> MapModel { get; set; }

        public ProjectDbContext()
        {

        }


        //Virtualna metoda da ignoriramo specificne entitije iz contexta
        public virtual void IgnoreEntities(ModelBuilder modelBuilder)
        {
            //Ne ignoriramo nista po defaultu
        }

        //Virtualna metoda da handlamo excepcije
        public virtual void SaveException(Exception ex)
        {
            throw ex;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySQL("Server=localhost;Database=osu;Uid=root;Pwd=domica;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Mapanje entitija i baze
            modelBuilder.Entity<MapModel>().ToTable("osu");
            modelBuilder.Entity<MapModel>().HasKey(p => p.Id).HasName("Id");
            modelBuilder.Entity<MapModel>().Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();
            modelBuilder.Entity<MapModel>().Property(p => p.Title).HasColumnName("Title").HasColumnType("varchar(255)").HasDefaultValueSql("''").IsRequired();
            modelBuilder.Entity<MapModel>().Property(p => p.Artist).HasColumnName("Artist").HasColumnType("varchar(255)").HasDefaultValueSql("''").IsRequired();
            modelBuilder.Entity<MapModel>().Property(p => p.Creator).HasColumnName("Creator").HasColumnType("varchar(255)").HasDefaultValueSql("''").IsRequired();
        }
    }
}
