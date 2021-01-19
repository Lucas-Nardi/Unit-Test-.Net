using CursoTestsCommon.Fixtures;
using FluentAssertions;
using Xunit;

namespace CursoUnityTest.ModelTests
{
    [Collection(nameof(ProdutoFixtureCollection))]
    public class ProdutoTests : IClassFixture<ProdutoFixtures>
    {
        private readonly ProdutoFixtures _fixture;

        public ProdutoTests(ProdutoFixtures fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        
        public void Produto_CorretamentePreenchido_ProdutoValido()
        {
            // Arrange
            var produto = _fixture.ProdutoValido();
            bool valido = false;
            // Act
            if (!produto.Descricao.Equals(string.Empty) && produto.Id >= 0 && produto.categoria != null && produto.Quantidade > 0 && produto.Quantidade <= 1000 && produto.CategoriaId > 0)
            {
                valido = true;
            }
            // Assert
            valido.Should().BeTrue(because: "os campos foram preenchidos corretamente");
        }

        [Fact]
        
        public void Produto_NenhumDadoPreenchido_ProdutoInvalido()
        {
            // Arrange
            var produto = _fixture.ProdutoInValidoCamposNulos();
            bool valido = true;
            // Act
            if (produto.Descricao.Equals(string.Empty) && produto.categoria == null && produto.Id == 0 && produto.CategoriaId == 0)
            {
                valido = false;
            }

            // Assert
            valido.Should().BeFalse(because: "deve possuir erros de preenchimento");

        }

        [Fact]
        
        public void Produto_DescricaoNaoPreenchida_ProdutoInvalido()
        {
            // Arrange
            var produto = _fixture.ProdutoInValidoDescricaoNula();
            bool valido = true;
            // Act
            if (produto.Descricao.Equals(string.Empty))
            {
                valido = false;
            }

            // Assert
            valido.Should().BeFalse(because: "A descrição da Produto não foi preenchida");

        }

        [Fact]
        
        public void Produto_DescricaoMaxLength_ProdutoInvalido()
        {
            // Arrange
            var Produto = _fixture.ProdutoComDescricaoEQuantidadeMaxLength();
            bool valido = true;
            // Act
            if (Produto.Descricao.Length > 150 && Produto.Quantidade >1000)
            {
                valido = false;
            }
            // Assert
            valido.Should().BeFalse(because: "tamanho máximo de campos atingidos");
        }
    }
}
