using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialBlazor.Models
{
    public class Articulos
    {
        [Key]
        [Required(ErrorMessage = "Introduzca un Id")]
        public int ArticuloId { get; set; }

        [Required(ErrorMessage = "Introduzca una Descripcion")]
        [MinLength(4,ErrorMessage ="El minimo de caracteres es 4")]
        [MaxLength(40,ErrorMessage ="El maximo de caracteres es 40")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        [Range(1,10000000, ErrorMessage = "Debe ser mayor o igual a 1")]
        public int Existencia { get; set; }

        [Required(ErrorMessage ="Introduzca un Costo")]
        public decimal Costo { get; set; }
        
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        public decimal ValorInventario { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Costo = 0;
            ValorInventario = 0;
        }
    }
}
