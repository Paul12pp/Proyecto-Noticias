using Proyecto_Noticias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Noticias.Data
{
    public static class DbSeed
    {
        /// <summary>
        /// Metodo inicializador de la Db
        /// verifica si exite, si no, la crea.
        /// </summary>
        /// <param name="context"></param>
        public static void SeedData(AppDbContext context)
        {
            var check = context.Database.EnsureCreated();
            if (check)
            {
                InsertNoticias(context);
                InsertComentarios(context);
            }
        }

        public static void InsertNoticias(AppDbContext context)
        {
            context.Noticias.AddRange(new List<Noticia>
            {
                new Noticia
                {
                    Titulo="",
                    Resumen="",
                    Url="",
                    Like=1,
                    Dislike=2,
                    Fecha= new DateTime()

                },
                new Noticia
                {
                    Titulo="NY | Gobernador amenaza con revertir reapertura",
                    Resumen="El gobernador Andrew Cuomo amenazó con revertir la reapertura de la ciudad de Nueva York el lunes, " +
                    "el mismo día que ingresa a la Fase IV, si el cumplimiento y la aplicación de las medidas para contener la pandemia no mejoran. " +
                    "Citó el hacinamiento continuo entre los jóvenes sin máscara que dice que “tiene que parar”",
                    Url="http://almomento.net/cuomo-amenaza-con-revertir-la-reapertura-por-incumplimiento/",
                    Like=1,
                    Dislike=2,
                    Fecha= new DateTime()

                },
                new Noticia
                {
                    Titulo="Ayudemos a esta joven dominicana",
                    Resumen="República Dominicana.–Solanni de los Santos es una joven " +
                    "de escasos recursos a quien le fue diagnosticado un tumor pélvico " +
                    "de 15 centímetros que la puede dejar estéril si no se opera a tiempo.",
                    Url="https://www.diariolibre.com/actualidad/salud/joven-solicita-ayuda-economica-para-cubrir-gastos-de-operacion-ME20243087",
                    Like=1,
                    Dislike=2,
                    Fecha= new DateTime()

                },
                new Noticia
                {
                    Titulo="Desfile Dominicano del Bronx será virtual",
                    Resumen="Los organizadores de la Gran Parada Dominicana " +
                    "del Bronx, que ha sido el lugar de encuentro de la diáspora " +
                    "dominicana por más de 30 años, han tomado la decisión de cancelar " +
                    "dicho evento en vista del aumento de los casos de COVID-19 y " +
                    "por las medidas para proteger a la población impuestas por el gobernador" +
                    " de Nueva York, Andrew Cuomo, y el alcalde de la ciudad, Bill de Blasio," +
                    " de no permitir actividades con más de 50 personas.",
                    Url="https://www.google.com/url?rct=j&sa=t&url=https://www.diariolibre.com/usa/actualidad/parada-dominicana-" +
                    "del-bronx-sera-celebrada-de-forma-virtual-en-septiembre-LE20242988&ct=ga&cd=CAIyGmU0ZmFlZmI1MGZhZGFlZTc6Y29t" +
                    "OmVzOlVT&usg=AFQjCNG_vzuwAag1yVRWIXDwZxDMy4ZcCw",
                    Like=1,
                    Dislike=2,
                    Fecha= new DateTime()

                },
                new Noticia
                {
                    Titulo="Una mascarilla transparente que no se ve tan pariguaya",
                    Resumen="Nos guste o no, tenemos pandemia para rato. Así que más nos vale " +
                    "irnos haciendo con mascarillas de calidad que nos protejan a nosotros y a nuestros" +
                    " seres queridos durante mucho tiempo. Civility es una nueva mascarilla " +
                    "con una particularidad única. Es transparente.",
                    Url="https://es.gizmodo.com/civility-es-una-mascarilla-transparente-que-te-permitir-1844439603",
                    Like=1,
                    Dislike=2,
                    Fecha= new DateTime()

                },
            });
            context.SaveChanges();
        }

        public static void InsertComentarios(AppDbContext context)
        {
            context.Comentarios.AddRange(new List<Comentario>
            {
                new Comentario
                {
                    Nombre= "Juan",
                    Correo="juan@p.com",
                    Descripcion="Muy bueno eso",
                    Fecha= new DateTime(),
                    NoticiaId=1
                },
                new Comentario
                {
                    Nombre= "Pedro",
                    Correo="pedro@j.com",
                    Descripcion="Me gusto",
                    Fecha= new DateTime(),
                    NoticiaId=2
                },
                new Comentario
                {
                    Nombre= "Maria",
                    Correo="maria@l.com",
                    Descripcion="JJJ, que loco",
                    Fecha= new DateTime(),
                    NoticiaId=1
                },
                new Comentario
                {
                    Nombre= "Josefa",
                    Correo="josefaa@m.com",
                    Descripcion="Excelente",
                    Fecha= new DateTime(),
                    NoticiaId=2
                },
                new Comentario
                {
                    Nombre= "Luis",
                    Correo="Luis@j.com",
                    Descripcion="Basura",
                    Fecha= new DateTime(),
                    NoticiaId=3
                },
            });
            context.SaveChanges();
        }
    }
}
