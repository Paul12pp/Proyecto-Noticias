using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Noticias.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime Fecha { get; set; }
        public int IdNoticia { get; set; }

    }
}
