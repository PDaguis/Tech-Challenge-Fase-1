using Fase1.Core.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Fase1.Test.XUnit
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Validando se o nome do contato vem vazio")]
        public void Should_Verify_If_Name_Is_Empty()
        {
            var nome = string.Empty;
            var telefone = "962625718";
            var email = "daguis.pedro@gmail.com";

            var result = Assert.Throws<DomainException>(() => new Contato(nome, telefone, email));

            Assert.Equal("O nome não pode estar vazio!", result.Message);
        }

        [Fact]
        public void Should_Verify_If_Email_Is_Valid()
        {
            var nome = "Pedro";
            var telefone = "962625718";
            var email = "daguis.pedrogmail.com";

            var result = Assert.Throws<DomainException>(() => new Contato(nome, telefone, email));

            Assert.Equal("Email inválido!", result.Message);
        }
    }
}