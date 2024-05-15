using Fase1.API.DTO.Inputs;
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

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var regiao = _regiaoRepository.GetById(id);

                if (regiao == null)
                    return NotFound();

                return Ok(regiao);
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
                var regioes = _regiaoRepository.GetAll();

                if (regioes == null)
                    return NotFound();

                return Ok(regioes);
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
