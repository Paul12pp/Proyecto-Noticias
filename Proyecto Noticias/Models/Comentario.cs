using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Noticias.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public int NoticiaId { get; set; }

    }
}
