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
        private readonly ILogger<ContatoController> _logger;

        public RegiaoController(IRegiaoRepository regiaoRepository, ILogger<ContatoController> logger)
        {
            _regiaoRepository = regiaoRepository;
            _logger = logger;
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
                _logger.LogInformation("Obtendo região por id...");
                var obj = _regiaoRepository.GetById(id);

                if (obj == null)
                {
                    _logger.LogInformation("Região não encontrada");
                    return NotFound();
                }

                _logger.LogInformation("Construindo objeto de região...");
                var regiao = new RegiaoResult()
                {
                    Id = obj.Id,
                    Nome = obj.Nome,
                    DDD = obj.DDD
                };

                _logger.LogInformation("Retornando objeto de região...");
                return Ok(regiao);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro na requisição: {e.Message}");
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
                _logger.LogInformation("Obtendo regiões...");
                var regioes = _regiaoRepository.GetAll();

                if (regioes == null)
                {
                    _logger.LogInformation("Regiões não encontradas");
                    return NotFound();
                }

                var lista = new List<RegiaoResult>();

                _logger.LogInformation("Construindo objetos de região...");
                foreach (var item in regioes)
                {
                    lista.Add(new RegiaoResult()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        DDD = item.DDD
                    });
                }

                _logger.LogInformation("Retornando regiões...");
                return Ok(lista);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro na requisição: {e.Message}");
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
                _logger.LogInformation("Construindo objeto de região...");
                var regiao = new Regiao()
                {
                    Nome = input.Nome,
                    DDD = input.DDD
                };

                _logger.LogInformation("Cadastrando região...");
                _regiaoRepository.Cadastrar(regiao);

                _logger.LogInformation("Região cadastrada");
                return Created();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro na requisição: {e.Message}");
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
                _logger.LogInformation("Obtendo região por id...");
                var regiao = _regiaoRepository.GetById(input.Id);

                if (regiao == null)
                {
                    _logger.LogInformation("Região não encontrada");
                    return NotFound();
                }

                _logger.LogInformation("Construindo objeto de região...");
                regiao.Nome = input.Nome;
                regiao.DDD = input.DDD;

                _logger.LogInformation("Atualizando região...");
                _regiaoRepository.Atualizar(regiao);

                _logger.LogInformation("Região atualizada");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro na requisição: {e.Message}");
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
                _logger.LogInformation("Obtendo região por id...");
                var regiao = _regiaoRepository.GetById(id);

                if (regiao == null)
                {
                    _logger.LogInformation("Região não encontrada");
                    return NotFound();
                }

                _logger.LogInformation("Excluindo região...");
                _regiaoRepository.Excluir(id);

                _logger.LogInformation("Região excluída");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro na requisição: {e.Message}");
                return BadRequest(e);
            }
        }
    }
}
