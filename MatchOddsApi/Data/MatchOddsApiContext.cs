using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchOddsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchOddsApi.Data {

    public class MatchOddsApiContext : DbContext {

        public MatchOddsApiContext(DbContextOptions<MatchOddsApiContext> opt)
            : base(opt) {
        }
                
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchOdd> MatchOdds { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<MatchOdd>()
                .Property(b => b.Odd)
                .HasColumnType("decimal(18,2)");
        }
    }
}