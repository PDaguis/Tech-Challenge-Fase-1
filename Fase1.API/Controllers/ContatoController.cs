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

        /// <summary>
        /// Endpoint para retornar o objeto de Contato por código Id
        /// </summary>
        /// <param name="id">Código identificador do Contato</param>
        /// <returns>Retorna o objeto Contato identificado pelo Id informado</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var obj = _contatoRepository.GetById(id);

                if (obj == null)
                    return NotFound();

                var contato = new ContatoResult()
                {
                    Id = obj.Id,
                    Nome = obj.Nome,
                    Email = obj.Email,
                    Telefone = obj.Telefone,
                    CadastradoEm = obj.CadastradoEm,
                    RegiaoId = obj.RegiaoId
                };

                return Ok(contato);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///  Endpoint para retornar todos os contatos
        /// </summary>
        /// <returns>Retorna todos os contatos</returns>
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
                        Telefone = item.Telefone,
                        CadastradoEm = item.CadastradoEm
                    });
                }

                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

        /// <summary>
        /// Endpoint para retornar os contatos por Região, mais especificamente, por DDD
        /// </summary>
        /// <param name="ddd">DDD da Região</param>
        /// <returns>Contatos por Região</returns>
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
                        CadastradoEm = item.CadastradoEm,
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

        /// <summary>
        /// Endpoint para cadastro de Contato
        /// </summary>
        /// <param name="input">Objeto Contato</param>
        /// <returns></returns>
        /// <response code="201">Sucesso no cadastro do contato</response>
        /// <response code="400">Erro na requisição</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
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

        /// <summary>
        /// Endpoint para atualização do Contato
        /// </summary>
        /// <param name="input">Objeto contato com informações atualizadas</param>
        /// <returns></returns>
        /// <response code="200">Sucesso na atualização do contato</response>
        /// <response code="404">Contato não encontrado</response>
        /// <response code="400">Erro na requisição</response>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
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
                contato.RegiaoId = input.RegiaoId;

                _contatoRepository.Atualizar(contato);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Endpoint para excluir um contato
        /// </summary>
        /// <param name="id">Código identificados do contato</param>
        /// <returns></returns>
        /// <response code="200">Sucesso na exclusão do contato</response>
        /// <response code="404">Contato não encontrado</response>
        /// <response code="400">Erro na requisição</response>
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
