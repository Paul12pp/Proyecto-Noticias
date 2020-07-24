using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Noticias.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Resumen { get; set; }
        [Required]
        public string Url { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string Categoria { get; set; }

        public List<Comentario> Comentarios { get; set; }

    }
}
