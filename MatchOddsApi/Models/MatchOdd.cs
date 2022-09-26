using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsApi.Models {

    public enum Specifier {
        Draw = 0,
        HomeWin = 1,
        AwayWin = 2
    }

    public class MatchOdd {
        
        [Key]
        public int Id { get; set; }
        public int MatchId { get; set; }
        public Specifier Specifier { get; set; }
        public decimal Odd { get; set; }

        //Navigation property
        public Match Match { get; set; }

    }
}