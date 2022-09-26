using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchOddsApi.Models {

    public enum Sport {
        Football = 1,
        Basketball = 2
    }

    public class Match {
        
        [Key]
        public int Id { get; set; }
        public string Description => string.Concat(TeamA, " - ", TeamB);
        
        [Required]
        public DateTime MatchDate { get; set; }
                
        [Required]
        public DateTime MatchTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string TeamA { get; set; }

        [Required]
        [MaxLength(50)]
        public string TeamB { get; set; }

        [Required]
        public Sport Sport { get; set; }        
        
    }
}