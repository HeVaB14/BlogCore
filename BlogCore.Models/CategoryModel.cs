using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class CategoryModel
    {
        // No te olvides poner en el contexto la propiedad DbSet<CategoryModel> Category { get; set; } para que se cree la tabla de categorias
        [Key]
        public int IdCategory { get; set; }

        [Required(ErrorMessage = "El Nombre de la Categoria es requerido.")]
        [Display(Name = "Nombre de la categoria")]
        public string NameCategory { get; set; }

        [Display(Name = "Orden de Visualización")]
        public int? Order { get; set; }

    }
}
