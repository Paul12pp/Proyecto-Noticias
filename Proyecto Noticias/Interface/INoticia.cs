using Proyecto_Noticias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Noticias.Interface
{
    public interface INoticia
    {
        /// <summary>
        /// agrega noticia
        /// </summary>
        /// <param name="model"></param>
        /// <returns>devuelve 200 o 500; error o success</returns>
        int AddNoticia(Noticia model);
        /// <summary>
        /// elimina una noticia y sus comentarios
        /// </summary>
        /// <param name="noticiaId"></param>
        /// <returns>devuelve 200 o 500; error o success</returns>
        int DeleteNoticia(int noticiaId);
        /// <summary>
        /// Todas las noticias
        /// </summary>
        /// <returns>listado de noticias y su cantidad de comentarios</returns>
        IEnumerable<Noticia> GetAllNoticias();
        /// <summary>
        /// Noticia por id
        /// </summary>
        /// <param name="noticiaId"></param>
        /// <returns>una notica y sus comentarios</returns>
        Noticia GetNoticiaById(int noticiaId);
        /// <summary>
        /// votacion positiva o negativa
        /// </summary>
        /// <param name="value"></param>
        /// <returns>devuelve 200 o 500; error o success</returns>
        int Votacion(int noticiaId,bool value);
        /// <summary>
        /// Metodo de buscar noticia
        /// </summary>
        /// <param name="value"></param>
        /// <returns>un listado de noticias que coinciden con el valor</returns>
        IEnumerable<Noticia> SearchNoticia(string value);
    }
}
