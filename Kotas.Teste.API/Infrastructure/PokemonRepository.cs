using Kotas.Teste.API.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kotas.Teste.API.Infrastructure
{
    public class PokemonRepository
    {

        private readonly KotasContext _kotasContext;

        public PokemonRepository()
        {
            _kotasContext = new KotasContext();
        }

        public async Task AdicionarMestrePokemon(MestrePokemon mestrePokemon, CancellationToken cancellationToken)
        {
            _kotasContext.MestresPokemon.Add(mestrePokemon);
            await _kotasContext.SaveChangesAsync(cancellationToken);
        }


        public async Task CapturarPokemon(Pokemon pokemon, CancellationToken cancellationToken)
        {
            _kotasContext.Pokemons.Add(pokemon);
            await _kotasContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Pokemon>> ObterPokemonsCapturados(CancellationToken cancellationToken)
        {
            return _kotasContext.Pokemons.Where(x => x.Status == StatusPokemon.Capturado);
        }
    }
}