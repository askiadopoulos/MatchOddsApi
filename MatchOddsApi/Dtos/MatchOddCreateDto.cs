using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsApi.Dtos {

    public class MatchOddCreateDto {

        [Required]
        public int MatchId { get; set; }

        [Required]
        [Range(0, 2, ErrorMessage = "Accepted integer values: Draw=0,HomeWin=1,AwayWin=2")]
        public int Specifier { get; set; }

        [Required]
        public decimal Odd { get; set; }

    }
}