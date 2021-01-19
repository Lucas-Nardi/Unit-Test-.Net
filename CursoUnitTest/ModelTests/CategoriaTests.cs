using CursoTestsCommon.Fixtures;
using FluentAssertions;
using Xunit;

namespace CursoUnityTest.ModelTests
{
   
    [Collection(nameof(CategoriaFixtureCollection))]
    public class CategoriaTests : IClassFixture<CategoriaFixtures>
    {
        private readonly CategoriaFixtures _fixture;

        public CategoriaTests(CategoriaFixtures fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [Trait("Categoria", "Categoria_CorretamentePreenchida_CategoriaValida")]
        public void Categoria_CorretamentePreenchida_CategoriaValida()
        {
            // Arrange
            var categoria = _fixture.CategoriaValida();
            bool valido = false;
            // Act
            if (!categoria.Descricao.Equals(string.Empty) && categoria.Id >=0)
            {
                valido = true;
            }
            // Assert
            valido.Should().BeTrue(because: "os campos foram preenchidos corretamente");            
        }

        [Fact]
        [Trait("Categoria", "Categoria_NenhumDadoPreenchido_CategoriaInvalida")]
        public void Categoria_NenhumDadoPreenchido_CategoriaInvalida()
        {
            // Arrange
            var categoria = _fixture.CategoriaInValidaCamposNulos();
            bool valido = true;
            // Act
            if (categoria.Descricao.Equals(string.Empty) && categoria.Id == 0)
            {
                valido = false;
            }
           
            // Assert
            valido.Should().BeFalse(because: "deve possuir erros de preenchimento");
            
        }

        [Fact]
        [Trait("Categoria", "Categoria_DescricaoNaoPreenchida_CategoriaInvalida")]
        public void Categoria_DescricaoNaoPreenchida_CategoriaInvalida()
        {
            // Arrange
            var categoria = _fixture.CategoriaInValidaDescricaoNula();
            bool valido = true;
            // Act
            if (categoria.Descricao.Equals(string.Empty))
            {
                valido = false;
            }

            // Assert
            valido.Should().BeFalse(because: "A descrição da categoria não foi preenchida");

        }

        [Fact]
        [Trait("Categoria", "Categoria_DescricaoMaxLength_CategoriaInvalida")]
        public void Categoria_DescricaoMaxLength_CategoriaInvalida()
        {
            // Arrange
            var categoria = _fixture.CategoriaComDescricaoMaxLength();
            bool valido = true;
            // Act
            if (categoria.Descricao.Length > 150)
            {
                valido = false;
            }
            // Assert
            valido.Should().BeFalse(because: "tamanho máximo de campos atingidos");            
        }
    }
}
