using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaWebAPI.Data;
using UrnaWebAPI.Models;

namespace UrnaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly IRepository repository;

        public CandidateController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidate()
        {
            var result = await this.repository.GetAllCandidateAsync();
            return Ok(result);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            try
            {
                var result = await this.repository.GetCandidateByIdAsync(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Candidato não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpGet, Route("legenda/{legenda}")]
        public async Task<IActionResult> CandidateByLegenda(int legenda)
        {
            try
            {
                var result = await this.repository.GetCandidateByLegenda(legenda);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Candidato não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody]Candidate candidateModel)
        {
            try
            {
                    var dataLocal = DateTime.Now;
                    candidateModel.DataRegistro = dataLocal;
                    repository.Add(candidateModel);

                    if (await repository.SaveChangesAsync())
                    {
                        return Ok(candidateModel);
                    }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut, Route("edit/{id}")]
        public async Task<IActionResult> EditCandidate(int id, [FromBody]Candidate candidateModel)
        {
            try
            {
                var result = await repository.GetCandidateByIdAsync(id);

                if (result != null)
                {
                    repository.Update(candidateModel);
                    await repository.SaveChangesAsync();
                    return Ok("Candidato atualizado com sucesso.");
                }
                else
                {
                    return NotFound("Candidato não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            try
            {
                var result = await repository.GetCandidateByIdAsync(id);
                if (result != null)
                {
                    repository.Delete(result);
                    await repository.SaveChangesAsync();
                    return Ok("Candidato excluido com sucesso.");
                }
                else
                {
                    return NotFound("Candidato não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
