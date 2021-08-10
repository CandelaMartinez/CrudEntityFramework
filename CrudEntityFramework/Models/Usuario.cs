using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//creo el cuerpo del modelo
//tabla usuario creada con modelo CODE FIRST: creo la bbdd desde codigo
//se ejecuta una migracion hacia la bbdd
namespace CrudEntityFramework.Models
{
    public class Usuario
    {
        //atributo Key: indico que es mi clave primaria
        [Key]
        public int Id { get; set; }

        //atributo required: campo nombre obligatorio
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; }

        //atributo display: me desplega el campo telefono con tilde
        [Required(ErrorMessage = "El telefono es obligatorio")]
        [Display(Name ="Teléfono")]
        public string Telefono { get; set; }

        //campo movil
        [Required(ErrorMessage = "El movil es obligatorio")]
        public string Movil { get; set; }

        //campo email
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }


    }
}
