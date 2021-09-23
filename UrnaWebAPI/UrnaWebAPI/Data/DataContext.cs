using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaWebAPI.Models;

namespace UrnaWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Vote> Vote { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Candidate>()
               .HasKey(C => C.CandidateId);

            builder.Entity<Candidate>().Property(x => x.CandidateId).ValueGeneratedOnAdd();

            builder.Entity<Vote>()
                .HasKey(v => v.VoteId);

            builder.Entity<Vote>().Property(x => x.VoteId).ValueGeneratedOnAdd();

        }
    }
}
