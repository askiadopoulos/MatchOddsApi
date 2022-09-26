using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsApi.Dtos {

    public class MatchUpdateDto {

        [Required]
        [DataType(DataType.Date)]
        public DateTime MatchDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime MatchTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string TeamA { get; set; }

        [Required]
        [MaxLength(50)]
        public string TeamB { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "Accepted integer values: Football=1,Basketball=2")]
        public int Sport { get; set; }

    }
}