using Kotas.Teste.API.Domain;
using Kotas.Teste.API.Infrastructure;
using Kotas.Teste.API.Services;
using Kotas.Teste.API.ViewModels;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kotas.Teste.API.Controllers
{

    [RoutePrefix("api/v1/pokemons")]
    public class PokemonsController : ApiController
    {
        private readonly PokemonService _pokemonService;
        private readonly PokemonRepository _pokemonRepository;

        public PokemonsController()
        {
            _pokemonService = new PokemonService();
            _pokemonRepository = new PokemonRepository();
        }


        [Route("aleatorio")]
        [HttpGet]
        public async Task<IHttpActionResult> ObterAsync(CancellationToken cancellationToken)
        {
            var resultado = await _pokemonService.ObterAleatoriosAsync(cancellationToken);
            if (!resultado.Any())
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> ObterPorIdAsync(int id, CancellationToken cancellationToken)
        {
            var pokemon = await _pokemonService.GetPokemonPorId(id, cancellationToken);
            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [Route("mestre")]
        [HttpPost]
        public async Task<IHttpActionResult> CriarMestrePokemonAsync([FromBody] CriarMestrePokemonViewModel request, 
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var mestrePokemon = MestrePokemon.Novo(request.Nome, request.Idade, request.Documento);

            await _pokemonRepository.AdicionarMestrePokemon(mestrePokemon, cancellationToken);

            return StatusCode(HttpStatusCode.Created);
        }


        [Route("{id}/capturar")]
        [HttpPost]
        public async Task<IHttpActionResult> CapturarPokemonAsync(int id, CancellationToken cancellationToken)
        {
            var pokemon = new Pokemon(id);
            pokemon.Capturar();

            await _pokemonRepository.CapturarPokemon(pokemon, cancellationToken);

            return StatusCode(HttpStatusCode.Created);
        }


        [Route("capturados")]
        [HttpGet]
        public async Task<IHttpActionResult> ObterPokemonsCapturadosAsync(CancellationToken cancellationToken)
        {
            var pokemonsCapturados = await _pokemonRepository.ObterPokemonsCapturados(cancellationToken);

            if (!pokemonsCapturados.Any())
            {
                return NotFound();
            }

            return Ok(pokemonsCapturados);
        }
    }
}
