using Proyecto_Noticias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Noticias.Interface
{
    public interface IComentario
    {
        /// <summary>
        /// agrega un comentario a una noticia
        /// </summary>
        /// <param name="model"></param>
        /// <returns>devuelve 200 o 500; error o success</returns>
        int AddComentario(Comentario model);
        /// <summary>
        /// lista de comentarios
        /// </summary>
        /// <param name="noticiaId"></param>
        /// <returns>los comentarios de una noticia</returns>
        IEnumerable<Comentario> GetComentariosByNoticia(int noticiaId);
        /// <summary>
        /// elimina un comentario
        /// </summary>
        /// <param name="comentarioId"></param>
        /// <returns>devuelve 200 o 500; error o success</returns>
        int DeleteComentario(int comentarioId);
    }
}
