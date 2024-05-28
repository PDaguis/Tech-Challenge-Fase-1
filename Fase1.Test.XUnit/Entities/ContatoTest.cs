using Bogus;
using Fase1.Core.Entities;

namespace Fase1.Test.Entities
{
    public class ContatoTest
    {
        private readonly Faker _faker;

        public ContatoTest()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "Validando se o nome do contato vem vazio")]
        public void Should_Verify_If_Name_Is_Empty()
        {
            var nome = string.Empty;
            var telefone = _faker.Phone.PhoneNumber();
            var email = _faker.Internet.Email();

            var result = Assert.Throws<DomainException>(() => new Contato(nome, telefone, email));

            Assert.Equal("O nome n�o pode estar vazio!", result.Message);
        }

        [Fact(DisplayName = "Validando se o email do contato � v�lido")]
        public void Should_Verify_If_Email_Is_Valid()
        {
            var nome = "Pedro";
            var telefone = "962625718";
            var email = "daguis.pedro!gmailcom";

            //var email = _faker.Internet.Email();

            var result = Assert.Throws<DomainException>(() => new Contato(nome, telefone, email));

            Assert.Equal("Email inv�lido!", result.Message);
        }

        [Fact(DisplayName = "Validando se o telefone do contato � v�lido")]
        public void Should_Verify_If_PhoneNumber_Is_Valid()
        {
            var nome = _faker.Name.FirstName();
            var telefone = "9637388";
            var email = _faker.Internet.Email();

            var result = Assert.Throws<DomainException>(() => new Contato(nome, telefone, email));

            Assert.Equal("O telefone n�o � v�lido!", result.Message);
        }
    }
}