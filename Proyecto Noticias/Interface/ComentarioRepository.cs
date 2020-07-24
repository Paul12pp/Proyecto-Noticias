using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Noticias.Data;
using Proyecto_Noticias.Models;

namespace Proyecto_Noticias.Interface
{
    public class ComentarioRepository : IComentario
    {
        private readonly AppDbContext _appDbContext;
        public ComentarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int AddComentario(Comentario model)
        {
            try
            {
                _appDbContext.Comentarios
                    .Add(model);
                _appDbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public IEnumerable<Comentario> GetComentariosByNoticia(int noticiaId)
        {
            return _appDbContext.Comentarios
                .Where(x => x.NoticiaId == noticiaId)
                .ToList();
        }

        public int DeleteComentario(int comentarioId)
        {
            try
            {
                var comentario = _appDbContext.Comentarios
                    .FirstOrDefault(x => x.Id == comentarioId);
                _appDbContext.Comentarios
                    .Remove(comentario);
                _appDbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
