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
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        //Metodo Post para inserção de informação
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++; 
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            // CreatedAtAction Serve para indicar onde esse recurso foi criado e como fazemos para retornar ele
            return CreatedAtAction(nameof(RecuperarFilmesPorId), new { Id = filme.Id }, filme);
        }
    
        //Metodo Get para retornar as informações
        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("filme={id}")]
        public IActionResult RecuperarFilmesPorId(int id)
        {
            // Esses 2 tipos de retorno ( Ok , NotFound ) são do tipo IActionResult

            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);
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
