using System;

namespace Kotas.Teste.API.Domain
{
    public class Pokemon
    {
        public Pokemon()
        {
        }

        public int Id { get; private set; }
        public int PokemonId { get; private set; }
        public DateTime CapturadoEm { get; private set; }
        public StatusPokemon Status { get; private set; }


        public Pokemon(int id)
        {
            PokemonId = id;
        }


        public void Capturar()
        {
            CapturadoEm = DateTime.Now;
            Status = StatusPokemon.Capturado;
        }
    }
}