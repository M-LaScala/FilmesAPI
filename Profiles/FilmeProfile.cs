using AutoMapper;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            // Criar um mapper de uma Classe para outra
            // Documentação automapper
            // https://docs.automapper.org/en/stable/Value-converters.html#value-converters

            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
