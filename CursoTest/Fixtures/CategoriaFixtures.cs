using Bogus;
using Decola_Dev.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoTestsCommon.Fixtures
{
    public class CategoriaFixtureCollection : ICollectionFixture<CategoriaFixtures>
    {

    }

    public class CategoriaFixtures 
    {

        public Categoria CategoriaValida()
        {
            
            var id = new Faker().Random.Int(1, 100000);
            var faker = new Faker<Categoria>("pt_BR");

            faker.RuleFor(c => c.Descricao, (f, c) => f.Lorem.Sentence(50));
            faker.RuleFor(c => c.Id, (f, c) => c.Id = id);

            Console.WriteLine(faker.Generate());
            return faker.Generate();
        }
        public Categoria CategoriaInValidaDescricaoNula()
        {
            // assets
            var id = new Faker().Random.Int(-100000, 0);
            Categoria c = new Categoria();
            c.Descricao = string.Empty;
            c.Id = id;
            return c;
        }

        public Categoria CategoriaInValidaCamposNulos()
        {                      
            Categoria c = new Categoria();
            c.Descricao = string.Empty;           
            return c;
        }
        public Categoria CategoriaComDescricaoMaxLength()
        {
            var id = new Faker().Random.Int(1, 100000);
            const string TEXTO_COM_MAIS_DE_150_CARACTERES = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            Categoria c = new Categoria();
            c.Id = id;
            c.Descricao = TEXTO_COM_MAIS_DE_150_CARACTERES;
            return c;
         }
    }
}
