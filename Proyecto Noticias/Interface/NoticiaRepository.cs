using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Noticias.Data;
using Proyecto_Noticias.Models;

namespace Proyecto_Noticias.Interface
{
    public class NoticiaRepository : INoticia
    {
        private readonly AppDbContext _appDbContext;
        public NoticiaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int AddNoticia(Noticia model)
        {
            try
            {
                _appDbContext.Noticias
                    .Add(model);
                _appDbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int DeleteNoticia(int noticiaId)
        {
            try
            {
                var noticia = _appDbContext.Noticias
                    .FirstOrDefault(n => n.Id == noticiaId);
                if (noticia != null)
                {
                    var comentarios = _appDbContext.Comentarios
                        .Where(c => c.NoticiaId == noticiaId)
                        .ToList();
                    if(comentarios!=null)
                        _appDbContext.Comentarios
                            .RemoveRange(comentarios);
                    _appDbContext.Remove(noticia);
                    _appDbContext.SaveChanges();
                }
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int EditNoticia(int id, Noticia model)
        {
            try
            {
                var noticia = _appDbContext.Noticias
                    .FirstOrDefault(r => r.Id == id);
                if (noticia != null)
                {
                    noticia.Titulo = model.Titulo;
                    noticia.Resumen = model.Resumen;
                    noticia.Url = model.Url;
                    noticia.Categoria = model.Categoria;
                    noticia.Fecha = model.Fecha;
                    _appDbContext.SaveChanges();
                    return 200;
                }
                return 500;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public IQueryable<Noticia> GetAllNoticias()
        {
            var filterData = from s in _appDbContext.Noticias
                             select s;
            foreach (var item in filterData)
            {
                item.Comentarios = _appDbContext.Comentarios
                .Where(x => x.NoticiaId == item.Id)
                .ToList();
            }
            return filterData.OrderByDescending(r=>r.Fecha);
        }

        public Noticia GetNoticiaById(int noticiaId)
        {
            return _appDbContext.Noticias
                .FirstOrDefault(n => n.Id == noticiaId);
        }

        public IQueryable<Noticia> SearchNoticia(string value)
        {
            //var filterData = _appDbContext.Noticias
                //.Where(x => x.Resumen.Contains(value) || x.Titulo.Contains(value))
                //.ToList();
            var filterData = from s in _appDbContext.Noticias
                      select s;
            foreach (var item in filterData)
            {
                item.Comentarios = _appDbContext.Comentarios
                .Where(x => x.NoticiaId == item.Id)
                .ToList();
            }
            
            return filterData
                .Where(x => x.Resumen.Contains(value) || x.Titulo.Contains(value))
                .OrderByDescending(r=>r.Fecha);
        }

        public int Votacion(int noticiaId,bool value)
        {
            try
            {
                var noticia = _appDbContext.Noticias
                    .FirstOrDefault(r => r.Id == noticiaId);
                if (noticia != null)
                {
                    noticia.Like = value ? noticia.Like += 1 : noticia.Like;
                    noticia.Dislike = !value ? noticia.Dislike += 1 : noticia.Dislike;
                    _appDbContext.SaveChanges();
                }
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
