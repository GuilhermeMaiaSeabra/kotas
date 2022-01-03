using System;

namespace Kotas.Teste.API.Domain
{
    public class MestrePokemon
    {
        public MestrePokemon()
        {
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Documento { get; private set; }


        public static MestrePokemon Novo(string nome, int idade, string documento)
        {
            return new MestrePokemon
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Idade = idade,
                Documento = documento
            };
        }
    }
}