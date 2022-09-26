using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchOddsApi.Models;

namespace MatchOddsApi.Data {

    public interface IMatchRepo {

        bool SaveChanges();
                
        IEnumerable<Match> GetAllMatches();
        Match GetMatchById(int id);
                
        void CreateMatch(Match match);
        void UpdateMatch(Match match);
        void DeleteMatch(Match match);

    }
}