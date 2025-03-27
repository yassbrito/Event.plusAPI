using Event_.Domains;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Event_.Context
{
    public class Event_Context : DbContext
    {
        public Event_Context()
        {
        }

        public Event_Context(DbContextOptions<Event_Context> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<TiposEventos> TiposEventos { get; set; }

        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }

        public DbSet<PresencasEventos> PresencasEventos { get; set; }

        public DbSet<Instituicoes> Instituicoes { get; set; }   

        public DbSet<Evento> Evento { get; set; }   

        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NOTE31-S28\\SQLEXPRESS; DataBase = EventPlus; User Id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            }


        }




    }
}
