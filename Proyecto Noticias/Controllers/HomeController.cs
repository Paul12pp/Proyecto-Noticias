using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Noticias.Data;
using Proyecto_Noticias.Interface;
using Proyecto_Noticias.Models;
using Proyecto_Noticias.ViewModels;

namespace Proyecto_Noticias.Controllers
{
    public class HomeController : Controller
    {
        // interfaces de los modelos e injecion 
        // como parametro en el controlador
        private readonly IComentario _comentario;
        private readonly INoticia _noticia;
        public HomeController(INoticia noticia, IComentario comentario)
        {
            _comentario = comentario;
            _noticia = noticia;
        }
        public IActionResult Index()
        {
            var noticias = _noticia.GetAllNoticias();
            foreach (var noticia in noticias)
            {
                noticia.Comentarios = _comentario.GetComentariosByNoticia(noticia.Id).ToList();
            }
            var viewModel = new HomeViewModel()
            {
                Noticias = new List<Noticia>(noticias)
            };
            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Login()
        {
            ViewData["Login"] = "Your application login page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
