using Bogus;
using Decola_Dev.Models;
using System;
using Xunit;
namespace CursoTestsCommon.Fixtures
{
    public class ProdutoFixtureCollection : ICollectionFixture<ProdutoFixtures>
    {

    }
    public class ProdutoFixtures
    {
        public Produto ProdutoValido()
        {
            var faker = new Faker<Produto>("pt_BR");

            faker.RuleFor(c => c.Descricao, (f, c) => f.Lorem.Sentence(50));
            faker.RuleFor(c => c.Id, (f, c) => f.Random.Int(1, 100000));
            faker.RuleFor(c => c.Quantidade, (f, c) => f.Random.Int(1,1000));
            faker.RuleFor(c => c.CategoriaId, (f, c) => f.Random.Int(1, 100000));
            faker.RuleFor(c => c.categoria, (f, c) => new Categoria());

            Console.WriteLine(faker.Generate());

            return faker.Generate();
        }
        public Produto ProdutoInValidoDescricaoNula()
        {            
            var faker = new Faker<Produto>("pt_BR");
            faker.RuleFor(c => c.Descricao, (f, c) => string.Empty);
            faker.RuleFor(c => c.Id, (f, c) => f.Random.Int(1, 100000));
            faker.RuleFor(c => c.Quantidade, (f, c) => f.Random.Int(1, 1000));
            faker.RuleFor(c => c.CategoriaId, (f, c) => f.Random.Int(1, 100000));
            faker.RuleFor(c => c.categoria, (f, c) => new Categoria());

            return faker.Generate();
        }

        public Produto ProdutoInValidoCamposNulos()
        {
            Produto p = new Produto();
            p.Descricao = string.Empty;
            p.categoria = null;
            
            return p;
        }

        public Produto ProdutoComDescricaoEQuantidadeMaxLength()
        {
            var id = new Faker().Random.Int(1, 100000);
            var idCategoria = new Faker().Random.Int(1, 100000);
            const string TEXTO_COM_MAIS_DE_150_CARACTERES = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            Produto p = new Produto();
            p.Id = id;
            p.Descricao = TEXTO_COM_MAIS_DE_150_CARACTERES;
            p.Quantidade = 1001;
            p.CategoriaId = idCategoria;
            p.categoria = new Categoria();
            return p;
        }
    }
}
