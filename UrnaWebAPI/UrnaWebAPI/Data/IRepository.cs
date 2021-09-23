using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaWebAPI.Models;

namespace UrnaWebAPI.Data
{
    public interface IRepository
    {
        // CRUD GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //GET CANDIDATES
        Task<Candidate[]> GetAllCandidateAsync();
        Task<Candidate> GetCandidateByIdAsync(int candidateId);
        Task<Candidate> GetCandidateByLegenda(int legenda);

        //GET VOTES
        Task<Vote[]> GetAllVoteAsync(bool includeCandidate);
        Task<Vote> GetVoteByIdAsync(int voteId, bool includeCandidate);
    }
}
