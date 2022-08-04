using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTOS
{
    public class ReadFilmeDto
    {
        // DTO = Data Transfer Objects 
        // Define o que realmente deve ser enviado no corpo da requisição 

        // Key define a chave primaria 
        // Required define como obrigatorio 
        [Key]
        [Required]
        public int Id { get; set; }

        //Definindo esse campo como obrigatorio e informando uma mensagem de erro
        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        public string Titulo { get; set; }

        [Required]
        public string Diretor { get; set; }

        //Definindo o limite de caracteres para esse campo
        [MaxLength(30)]
        public string Genero { get; set; }

        //Definindo o intervalo que vai ser aceito nesse campo 
        [Range(1, 600)]
        public int Duracao { get; set; }   
        public DateTime HoraDaConstula { get; set; }
    }
}
