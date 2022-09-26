using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MatchOddsApi.Data;
using MatchOddsApi.Dtos;
using MatchOddsApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MatchOddsApi.Controllers {
    
    [Route("api/matches")]
    [ApiController]
    public class MatchesController : ControllerBase {

        private readonly IMatchRepo _repository;
        private readonly IMapper _mapper;

        public MatchesController(IMatchRepo repository, IMapper mapper) {
            _repository = repository;            
            _mapper = mapper;
        }
                
        //GET api/mathes
        [HttpGet]
        public ActionResult<IEnumerable<MatchReadDto>> GetAllMatches() {
            var matchItems = _repository.GetAllMatches();

            if (matchItems != null && matchItems.Count() > 0) {
                return Ok(_mapper.Map<IEnumerable<MatchReadDto>>(matchItems));
            }

            return NotFound();
        }
                
        //GET api/matches/{id}
        [HttpGet("{id}", Name = "GetMatchById")]
        public ActionResult<MatchReadDto> GetMatchById(int id) {
            var matchItem = _repository.GetMatchById(id);

            if (matchItem != null) {
                return Ok(_mapper.Map<MatchReadDto>(matchItem));
            }
            return NotFound();
        }

        //POST api/matches
        [HttpPost]
        public ActionResult<MatchReadDto> CreateMatch(MatchCreateDto matchCreateDto) {
            var matchModel = _mapper.Map<Match>(matchCreateDto);
            _repository.CreateMatch(matchModel);
            _repository.SaveChanges();
                        
            var matchReadDto = _mapper.Map<MatchReadDto>(matchModel);
            
            return CreatedAtRoute(nameof(GetMatchById), new { Id = matchReadDto.Id }, matchReadDto);
        }


        //PUT api/matches/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMatch(int id, MatchUpdateDto matchUpdateDto) {
            var matchModelFromRepo = _repository.GetMatchById(id);

            if (matchModelFromRepo == null) {
                return NotFound();
            }

            _mapper.Map(matchUpdateDto, matchModelFromRepo);            
            _repository.UpdateMatch(matchModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/matches/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMatchUpdate(int id, JsonPatchDocument<MatchUpdateDto> patchDoc) {
            var matchModelFromRepo = _repository.GetMatchById(id);

            if (matchModelFromRepo == null) {
                return NotFound();
            }
                        
            var matchToPatch = _mapper.Map<MatchUpdateDto>(matchModelFromRepo);            
            patchDoc.ApplyTo(matchToPatch, ModelState);
                        
            if (!TryValidateModel(matchToPatch)) {
                return ValidationProblem(ModelState);
            }
                        
            _mapper.Map(matchToPatch, matchModelFromRepo);
            _repository.UpdateMatch(matchModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/matches/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMatch(int id) {
            var matchModelFromRepo = _repository.GetMatchById(id);

            if (matchModelFromRepo == null) {
                return NotFound();
            }
                        
            _repository.DeleteMatch(matchModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}