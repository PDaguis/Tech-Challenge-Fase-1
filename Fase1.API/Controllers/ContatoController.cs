using Fase1.API.DTO.Inputs;
using Fase1.API.DTO.Results;
using Fase1.Core.Entities;
using Fase1.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fase1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var contato = _contatoRepository.GetById(id);

                if (contato == null)
                    return NotFound();

                return Ok(contato);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var contatos = _contatoRepository.GetAll();

                if (contatos == null)
                    return NotFound();

                var lista = new List<ContatoResult>();

                foreach (var item in contatos)
                {
                    lista.Add(new ContatoResult()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Email = item.Email,
                        Telefone = item.Telefone
                    });
                }

                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [HttpGet("ddd/{ddd}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetContatosPorDDD(string ddd)
        {
            try
            {
                var contatos = _contatoRepository.GetContatosPorDDD(ddd);

                if (contatos == null)
                    return NotFound();

                var lista = new List<ContatoPorDDDResult>();

                foreach (var item in contatos)
                {
                    lista.Add(new ContatoPorDDDResult()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Email = item.Email,
                        Telefone = item.Telefone,
                        Regiao = new RegiaoResult()
                        {
                            Id = item.Regiao.Id,
                            Nome = item.Regiao.Nome,
                            DDD = item.Regiao.DDD
                        }
                    });
                }

                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] ContatoPost input)
        {
            try
            {
                var contato = new Contato()
                {
                    Nome = input.Nome,
                    Telefone = input.Telefone,
                    Email = input.Email,
                    RegiaoId = input.RegiaoId
                };

                _contatoRepository.Cadastrar(contato);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] ContatoPut input)
        {
            try
            {
                var contato = _contatoRepository.GetById(input.Id);

                if (contato == null)
                    return NotFound();

                contato.Nome = input.Nome;
                contato.Telefone = input.Telefone;
                contato.Email = input.Email;

                _contatoRepository.Atualizar(contato);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var contato = _contatoRepository.GetById(id);

                if (contato == null)
                    return NotFound();

                _contatoRepository.Excluir(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
