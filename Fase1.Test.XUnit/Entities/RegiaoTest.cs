using Bogus;
using Fase1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1.Test.Entities
{
    public class RegiaoTest
    {
        private readonly Faker _faker;

        public RegiaoTest()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "Validando se o nome da região vem vazio")]
        public void Should_Verify_If_Nome_Is_Empty()
        {
            var nome = string.Empty;
            var ddd = "011";

            var result = Assert.Throws<DomainException>(() => new Regiao(nome, ddd));
            Assert.Equal("Nome cannot be null or empty", result.Message);
        }

        [Fact(DisplayName = "Validando se o ddd da região vem vazio teste")]
        public void Should_Verify_If_DDD_Is_Empty()
        {
            var nome = _faker.Name.FirstName();
            var ddd = string.Empty;

            var result = Assert.Throws<DomainException>(() => new Regiao(nome, ddd));

            Assert.Equal("DDD cannot be null or empty", result.Message);
        }

        [Fact(DisplayName = "Validando se o ddd da região é válido")]
        public void Should_Verify_If_DDD_Is_Valid()
        {
            var nome = _faker.Address.City();
            var ddd = "002";

            var result = Assert.Throws<DomainException>(() => new Regiao(nome, ddd));

            Assert.Equal("DDD incorrect", result.Message);
        }
    }
}
