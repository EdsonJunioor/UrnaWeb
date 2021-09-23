using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaWebAPI.Models
{
    public class Candidate
    {
        public Candidate() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateId { get; set; }
        public string Nome { get; set; }
        public string Vice { get; set; }
        public int Legenda { get; set; }
        public DateTime DataRegistro { get; set; }

        public Candidate(string nome, string vice, int legenda, DateTime dataRegistro)
        {
            this.Nome = nome;
            this.Vice = vice;
            this.Legenda = legenda;
            this.DataRegistro = dataRegistro;
        }
    }
}
