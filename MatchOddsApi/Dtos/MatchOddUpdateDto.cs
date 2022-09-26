using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsApi.Dtos {
    public class MatchOddUpdateDto {

        [Required]
        public int MatchId { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "Accepted integer values: Football=1,Basketball=2")]
        public int Specifier { get; set; }

        [Required]
        public decimal Odd { get; set; }

    }
}