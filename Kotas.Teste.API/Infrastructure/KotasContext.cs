using Kotas.Teste.API.Domain;
using SQLite.CodeFirst;
using System.Data.Entity;

namespace Kotas.Teste.API.Infrastructure
{
    public class KotasContext : DbContext
    {
        public KotasContext() : base("KotasDb")
        {
            Database.SetInitializer<KotasContext>(null);
        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<MestrePokemon> MestresPokemon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<KotasContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);            
        }
    }
}