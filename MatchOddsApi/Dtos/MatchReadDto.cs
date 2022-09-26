using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsApi.Dtos {

    public class MatchReadDto {

        public int Id { get; set; }
        public string Description { get; set; }
        public string MatchDate { get; set; }
        public string MatchTime { get; set; }
        public string Sport { get; set; }

    }
}