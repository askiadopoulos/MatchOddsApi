using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchOddsApi.Models;

namespace MatchOddsApi.Data {

    public class SqlMatchOddsApiRepo : IMatchRepo, IMatchOddRepo {

        private readonly MatchOddsApiContext _context;
                
        public SqlMatchOddsApiRepo(MatchOddsApiContext context) {
            _context = context;
        }

        public void CreateMatch(Match match) {
            if (match == null) {
                throw new ArgumentNullException(nameof(match));
            }

            _context.Matches.Add(match);
        }

        public void CreateMatchOdd(MatchOdd matchOdd) {
            if (matchOdd == null) {
                throw new ArgumentNullException(nameof(matchOdd));
            }

            _context.MatchOdds.Add(matchOdd);
        }

        public void DeleteMatch(Match match) {
            if (match == null) {
                throw new ArgumentNullException(nameof(match));
            }

            _context.Matches.Remove(match);
        }

        public void DeleteMatchOdd(MatchOdd matchOdd) {
            if (matchOdd == null) {
                throw new ArgumentNullException(nameof(matchOdd));
            }

            _context.MatchOdds.Remove(matchOdd);
        }

        public IEnumerable<Match> GetAllMatches() {
            return _context.Matches.ToList();
        }

        public IEnumerable<MatchOdd> GetAllMatchOdds() {
            return _context.MatchOdds.ToList();
        }

        public Match GetMatchById(int id) {
            return _context.Matches.FirstOrDefault(p => p.Id == id);
        }

        public MatchOdd GetMatchOddById(int id) {
            return _context.MatchOdds.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges() {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMatch(Match matchOdd) {
            //do nothing...
        }

        public void UpdateMatchOdd(MatchOdd matchOdd) {
            //do nothing...
        }

    }
}