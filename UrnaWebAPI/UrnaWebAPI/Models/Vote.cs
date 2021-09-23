using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaWebAPI.Models
{
    public class Vote
    {
        public Vote() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoteId { get; set; }
        public Candidate candidate { get; set; }
        public Nullable<int> CandidateId { get; set; }
        public DateTime DateVote { get; set; }

        public Vote(int id, DateTime dateVote)
        {
            this.CandidateId = id;
            this.DateVote = dateVote;
        }
    }
}
