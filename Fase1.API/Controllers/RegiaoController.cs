using Fase1.API.DTO.Inputs;
using Fase1.API.DTO.Results;
using Fase1.Core.Entities;
using Fase1.Core.Interfaces;
using Fase1.Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fase1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegiaoController : ControllerBase
    {
        private readonly IRegiaoRepository _regiaoRepository;

        public RegiaoController(IRegiaoRepository regiaoRepository)
        {
            _regiaoRepository = regiaoRepository;
        }

        /// <summary>
        /// Endpoint para retornar o objeto de Região por código Id
        /// </summary>
        /// <param name="id">Código identificador da Região</param>
        /// <returns>Retorna o objeto Região identificado pelo Id informado</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var obj = _regiaoRepository.GetById(id);

                if (obj == null)
                    return NotFound();

                var regiao = new RegiaoResult()
                {
                    Id = obj.Id,
                    Nome = obj.Nome,
                    DDD = obj.DDD
                };

                return Ok(regiao);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Endpoint para retornar todas as regiões
        /// </summary>
        /// <returns>Retorna todas as regiões</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetAll()
        {
            try
            {
                var regioes = _regiaoRepository.GetAll();

                if (regioes == null)
                    return NotFound();

                var lista = new List<RegiaoResult>();

                foreach (var item in regioes)
                {
                    lista.Add(new RegiaoResult()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        DDD = item.DDD
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
        /// Endpoint para cadastro de Região
        /// </summary>
        /// <param name="input">Objeto Região</param>
        /// <returns></returns>
        /// <response code="201">Sucesso no cadastro da região</response>
        /// <response code="400">Erro na requisição</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] RegiaoPost input)
        {
            try
            {
                var regiao = new Regiao()
                {
                    Nome = input.Nome,
                    DDD = input.DDD
                };

                _regiaoRepository.Cadastrar(regiao);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Endpoint para atualização da Região
        /// </summary>
        /// <param name="input">Objeto região com informações atualizadas</param>
        /// <returns></returns>
        /// <response code="200">Sucesso na atualização da região</response>
        /// <response code="404">Região não encontrada</response>
        /// <response code="400">Erro na requisição</response>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] RegiaoPut input)
        {
            try
            {
                var regiao = _regiaoRepository.GetById(input.Id);

                if (regiao == null)
                    return NotFound();

                regiao.Nome = input.Nome;
                regiao.DDD = input.DDD;

                _regiaoRepository.Atualizar(regiao);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Endpoint para excluir uma região
        /// </summary>
        /// <param name="id">Código identificados da região</param>
        /// <returns></returns>
        /// <response code="200">Sucesso na exclusão da região</response>
        /// <response code="404">Região não encontrada</response>
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
                var regiao = _regiaoRepository.GetById(id);

                if (regiao == null)
                    return NotFound();

                _regiaoRepository.Excluir(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
