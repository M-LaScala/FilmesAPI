using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    //Criando o controller e especificando a rota
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Metodo Post para inserção de informação
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            // Construção de um objeto com o construtor implicito ( Apagado )
            // Conversão ultilizando o Mapper de um objeto do tipo CreateFilmeDto para um objeto do tipo Filme
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            // CreatedAtAction Serve para indicar onde esse recurso foi criado e como fazemos para retornar ele
            return CreatedAtAction(nameof(RecuperarFilmesPorId), new { Id = filme.Id }, filme);
        }
    
        //Metodo Get para retornar as informações
        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorId(int id)
        {
            // Esses 2 tipos de retorno ( Ok , NotFound ) são do tipo IActionResult
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            
            if(filme != null)
            {
                // Ok seria um code 200 sucesso
                // Conversão ultilizando Mapper 
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                return Ok(filmeDto);
            }
            // NotFound representa um erro 404
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            // Busca um filme pelo ID e sobrescreve ele com o filme recebido no corpo da requisição   
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            
            if(filme == null)
            {
                return NotFound();
            }

            // Sobrescrevendo filme com os dados do filme Dto ( AutoMapper )
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            // Sucesso porem sem conteudo de retorno ( 204 No Content )
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
