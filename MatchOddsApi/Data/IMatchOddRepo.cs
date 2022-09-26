using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchOddsApi.Models;

namespace MatchOddsApi.Data {

    public interface IMatchOddRepo {

        bool SaveChanges();

        IEnumerable<MatchOdd> GetAllMatchOdds();
        MatchOdd GetMatchOddById(int id);

        void CreateMatchOdd(MatchOdd matchOdd);        
        void UpdateMatchOdd(MatchOdd matchOdd);
        void DeleteMatchOdd(MatchOdd matchOdd);

    }
}