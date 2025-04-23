using Microsoft.EntityFrameworkCore;
using SenaiSoundSql.Modelos;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql;
namespace SenaiSoundSql.Banco
{
    public class SenaiSoundContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas { get; set; }

        private static string servidor = "localhost";
        private static string banco = "senaisound_db";
        private static string usuario = "root";
        private static string senha = "";

        private string conexaoDb = $"Server={servidor};Database={banco};User Id={usuario};Password={senha};Connection Timeout=60;";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(conexaoDb, ServerVersion.AutoDetect(conexaoDb))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

    }
}
