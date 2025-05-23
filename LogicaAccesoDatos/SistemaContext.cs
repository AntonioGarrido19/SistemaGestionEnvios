﻿using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class SistemaContext:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Envio> Envios { get; set; }

        public DbSet<EnvioComun> EnviosComun { get; set; }

        public DbSet<EnvioUrgente> EnviosUrgente { get; set; }

        public DbSet<Agencia> Agencias { get; set; }
        
        public DbSet<Auditoria> Auditorias { get; set; }

        public SistemaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Envio>().HasOne(c => c.Cliente)
                .WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Envio>().HasOne(c => c.Empleado)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }

    }
}
