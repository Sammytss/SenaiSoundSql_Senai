using Microsoft.EntityFrameworkCore;
using SenaiSoundSql.Modelos;
namespace SenaiSoundSql.Banco
{
    public class SenaiSoundContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas { get; set; }

        private static string servidor = "127.0.0.1";
        private static string banco = "senai_sound_db";
        private static string usuario = "root";
        private static string senha = "";

        private string conexaoDb = $"Server={servidor};Database={banco};User Id={usuario};Password={senha};";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(conexaoDb);
        }

    }
}
