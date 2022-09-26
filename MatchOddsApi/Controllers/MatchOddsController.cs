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

    [Route("api/matchOdds")]
    [ApiController]
    public class MatchOddsController : ControllerBase {
                
        private readonly IMatchOddRepo _repository;
        private readonly IMapper _mapper;

        public MatchOddsController(IMatchOddRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }
                
        //GET api/matchOdds
        [HttpGet]
        public ActionResult<IEnumerable<MatchOddReadDto>> GetAllMatchOdds() {
            var matchOddsItems = _repository.GetAllMatchOdds();

            if (matchOddsItems != null && matchOddsItems.Count() > 0) {
                return Ok(_mapper.Map<IEnumerable<MatchOddReadDto>>(matchOddsItems));
            }

            return NotFound();
        }
                
        //GET api/matchOdds/{id}
        [HttpGet("{id}", Name = "GetMatchOddById")]
        public ActionResult<MatchOddReadDto> GetMatchOddById(int id) {
            var matchOddItem = _repository.GetMatchOddById(id);

            if (matchOddItem != null) {
                return Ok(_mapper.Map<MatchOddReadDto>(matchOddItem));
            }

            return NotFound();
        }

        //POST api/matchOdds
        [HttpPost]
        public ActionResult<MatchOddReadDto> CreateMatchOdd(MatchOddCreateDto matchOddCreateDto) {
            var matchOddModel = _mapper.Map<MatchOdd>(matchOddCreateDto);
            _repository.CreateMatchOdd(matchOddModel);
            _repository.SaveChanges();

            var matchOddReadDto = _mapper.Map<MatchOddReadDto>(matchOddModel);

            return CreatedAtRoute(nameof(GetMatchOddById), new { Id = matchOddReadDto.Id }, matchOddReadDto);
        }

        //PUT api/matchOdds/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMatchOdd(int id, MatchOddUpdateDto matchOddUpdateDto) {
            var matchOddModelFromRepo = _repository.GetMatchOddById(id);

            if (matchOddModelFromRepo == null) {
                return NotFound();
            }
                        
            _mapper.Map(matchOddUpdateDto, matchOddModelFromRepo);            
            _repository.UpdateMatchOdd(matchOddModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/matchOdds/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMatchOddUpdate(int id, JsonPatchDocument<MatchOddUpdateDto> patchDoc) {
            var matchOddModelFromRepo = _repository.GetMatchOddById(id);

            if (matchOddModelFromRepo == null) {
                return NotFound();
            }
                        
            var matchOddToPatch = _mapper.Map<MatchOddUpdateDto>(matchOddModelFromRepo);            
            patchDoc.ApplyTo(matchOddToPatch, ModelState);
            
            if (!TryValidateModel(matchOddToPatch)) {
                return ValidationProblem(ModelState);
            }
                        
            _mapper.Map(matchOddToPatch, matchOddModelFromRepo);
            _repository.UpdateMatchOdd(matchOddModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/matchOdds/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMatchOdd(int id) {
            var matchOddModelFromRepo = _repository.GetMatchOddById(id);

            if (matchOddModelFromRepo == null) {
                return NotFound();
            }
                        
            _repository.DeleteMatchOdd(matchOddModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}