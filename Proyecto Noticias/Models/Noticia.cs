using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Noticias.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Url { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public DateTime Fecha { get; set; }
        public string Categoria { get; set; }

        public List<Comentario> Comentarios { get; set; }

    }
}
