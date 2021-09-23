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
    public class VoteController : ControllerBase
    {
        private readonly IRepository repository;

        public VoteController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetVote()
        {
            var result = await this.repository.GetAllVoteAsync(true);
            return Ok(result);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetVoteById(int id)
        {
            try
            {

                var result = await this.repository.GetVoteByIdAsync(id, true);
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

        [HttpGet, Route("total-votes")]
        public async Task<IActionResult> TotalVotes()
        {
            try
            {
                var result = await this.repository.GetAllVoteAsync(true);
                if (result != null)
                {
                    var totalVotos = result.Where(x => x.CandidateId != null).GroupBy(v => v.CandidateId).Select(x => new { Candidato = x.FirstOrDefault().candidate.Nome, TotalVotos = x.Count() }).ToList();
                    var totalVotosBranco = result.Count(x => x.CandidateId == null);
                    totalVotos.Add(new { Candidato = "Voto em Branco", TotalVotos = totalVotosBranco });

                    return Ok(totalVotos);
                }
                else
                {
                    return NotFound("Nenhum voto encotrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Vote([FromBody]Candidate candidato)
        {
            try
            {
                var votoModel = new Vote();
                votoModel.DateVote = DateTime.Now;

                if (candidato.Legenda > 0)
                {
                    var candidatoRetornado = await this.repository.GetCandidateByLegenda(candidato.Legenda);

                    votoModel.CandidateId = candidatoRetornado.CandidateId;
                    if (candidatoRetornado != null)
                    {
                        repository.Add(votoModel);
                        await repository.SaveChangesAsync();
                        return Ok("Voto realizado com sucesso.");

                    }
                    else
                    {
                        return NotFound($"Candidato não encontrado.");
                    }
                }
                else if(candidato.Legenda == 0)
                {
                    repository.Add(votoModel);
                    await repository.SaveChangesAsync();
                    return Ok("Voto em branco salvo.");
                }

                return BadRequest("Não foi possível realizar o voto.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
