﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Noticias.Data;
using Proyecto_Noticias.Interface;
using Proyecto_Noticias.Models;
using Proyecto_Noticias.ViewModels;

namespace Proyecto_Noticias.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly IComentario _comentario;
        private readonly INoticia _noticia;
        private readonly AppDbContext _context;

        public bool ModelIsValid { get; private set; }

        public NoticiasController(INoticia noticia, IComentario comentario, AppDbContext context)
        {
            _comentario = comentario;
            _noticia = noticia;
            _context = context;
        }

        //GET: Noticias
        public async Task<IActionResult> Index(int? pageNumber,
            string currentFilter,
            string searchString)
        {
            if (searchString != null)         
                pageNumber = 1;
            else            
                searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            var noticias = _noticia.GetAllNoticias();
            if (!String.IsNullOrEmpty(searchString))
            {
                noticias = _noticia.SearchNoticia(searchString);
            }
            int pageSize = 3;
            //var astr = noticias.AsNoTracking();
            return View(await PaginatedList<Noticia>.CreateAsync(noticias, pageNumber ?? 1, pageSize));
            //foreach (var noticia in noticias)
            //{
            //    noticia.Comentarios = _comentario.GetComentariosByNoticia(noticia.Id).ToList();
            //}
            //var viewModel = new HomeViewModel()
            //{
            //    Noticias = new List<Noticia>(noticias)
            //};
            //return View(viewModel);
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var noticia =  _noticia.GetNoticiaById(id.Value);
            if (noticia == null)
            {
                return NotFound();
            }
            noticia.Comentarios = _comentario.GetComentariosByNoticia(noticia.Id).ToList();
            return View(noticia);
        }

        // GET: Noticias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Titulo,Resumen,Url,Like,Dislike,Categoria,Fecha")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                _noticia.AddNoticia(noticia);
                return RedirectToAction("Index","Noticias");
            }
            return View(noticia);
        }

        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = _noticia.GetNoticiaById(id.Value);
            if (noticia == null)
            {
                return NotFound();
            }
            return View(noticia);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Resumen,Url,Like,Dislike,Categoria,Fecha")] Noticia noticia)
        {

            if (ModelState.IsValid)
            {
                var result = _noticia.EditNoticia(id, noticia);
                if(result==200)
                    return Redirect($"/Noticias/Details/{id}");
                return View(noticia);
            }
            return View(noticia);
        }

        // GET: Noticias/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = _noticia.GetNoticiaById(id.Value);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _noticia.DeleteNoticia(id);
            return RedirectToAction("Index", "Noticias");
        }

        private bool NoticiaExists(int id)
        {
            return _noticia.GetNoticiaById(id) != null;
        }

        public IActionResult Search(string value)
        {
            var result = _noticia.SearchNoticia(value);
            foreach (var noticia in result)
            {
                noticia.Comentarios = _comentario.GetComentariosByNoticia(noticia.Id).ToList();
            }
            var viewModel = new HomeViewModel()
            {
                Noticias = new List<Noticia>(result)
            };
            return View("Index", viewModel);
        }

        public IActionResult Votation(int id, bool value)
        {
            var result = _noticia.Votacion(id, value);
            if (result == 200)
            {
                return Redirect("/Noticias");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario model)
        {
            if (ModelState.IsValid)
            {
                var result = _comentario.AddComentario(model);

                if (result == 200)
                {
                    return Redirect($"/Noticias/Details/{model.NoticiaId}");
                }
                return Redirect($"/Noticias/Details/{model.NoticiaId}");
            }
            return Redirect($"/Noticias/Details/{model.NoticiaId}");
        }

        public IActionResult DeleteComentario(int id,int noticia)
        {
            var result = _comentario.DeleteComentario(id);
            if (result == 200)
            {
                return Redirect($"/Noticias/Details/{noticia}");
            }
            return NotFound();
        }
    }
}
