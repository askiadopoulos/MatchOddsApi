using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MatchOddsApi.Dtos;
using MatchOddsApi.Models;

namespace MatchOddsApi.Profiles {
    public class MatchOddsApiProfile : Profile {

        public MatchOddsApiProfile() {

            //source type -> destination (target) type

            //Match mapping
            CreateMap<Match, MatchReadDto>()
                .ForMember(dest => dest.Description, mem => mem.MapFrom(src => src.Description))
                .ForMember(dest => dest.MatchDate, mem => mem.MapFrom(src => src.MatchDate.ToShortDateString()))
                .ForMember(dest => dest.MatchTime, mem => mem.MapFrom(src => src.MatchTime.ToShortTimeString()))
                .ForMember(dest => dest.Sport, mem => mem.MapFrom(src => Enum.GetName(typeof(Sport), src.Sport)));
                        
            CreateMap<MatchCreateDto, Match>();            
            CreateMap<MatchUpdateDto, Match>();            
            CreateMap<Match, MatchUpdateDto>();

            //MatchOdd mapping
            CreateMap<MatchOdd, MatchOddReadDto>()
                //.ForMember(dest => dest.Specifier, mem => mem.MapFrom(src => src.Specifier))
                .ForMember(dest => dest.Specifier, mem => mem.MapFrom(src => Enum.GetName(typeof(Specifier), src.Specifier)));

            CreateMap<MatchOddCreateDto, MatchOdd>();
            CreateMap<MatchOddUpdateDto, MatchOdd>();
            CreateMap<MatchOdd, MatchOddUpdateDto>();

        }
    }
}