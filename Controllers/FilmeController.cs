using FilmesAPI.Data;
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

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        //Metodo Post para inserção de informação
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {

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
                return Ok(filme);
            }
            // NotFound representa um erro 404
            return NotFound();
        }

    }
}
