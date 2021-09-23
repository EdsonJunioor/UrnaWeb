using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaWebAPI.Models;

namespace UrnaWebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Candidate[]> GetAllCandidateAsync()
        {
            IQueryable<Candidate> query = _context.Candidate;

            query = query.AsNoTracking()
                         .OrderBy(c => c.CandidateId);

            return await query.ToArrayAsync();
        }
        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            IQueryable<Candidate> query = _context.Candidate;

            query = query.AsNoTracking()
                         .OrderBy(candidate => candidate)
                         .Where(candidate => candidate.CandidateId == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Candidate> GetCandidateByLegenda(int legenda)
        {
            IQueryable<Candidate> query = _context.Candidate;

            query = query.AsNoTracking()
                         .OrderBy(candidate => candidate)
                         .Where(candidate => candidate.Legenda == legenda);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Vote[]> GetAllVoteAsync(bool includeCandidate = true)
        {
            IQueryable<Vote> query = _context.Vote;

            if (includeCandidate)
            {
                query = query.Include(v => v.candidate);
            }

            query = query.AsNoTracking()
                         .OrderBy(vote => vote.VoteId);

            return await query.ToArrayAsync();
        }
        public async Task<Vote> GetVoteByIdAsync(int voteId, bool includeCandidate = true)
        {
            IQueryable<Vote> query = _context.Vote;

            if (includeCandidate)
            {
                query = query.Include(v => v.candidate);
            }

            query = query.AsNoTracking()
                         .OrderBy(vote => vote.VoteId)
                         .Where(vote => vote.VoteId == voteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
