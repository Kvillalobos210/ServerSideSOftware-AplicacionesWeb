using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DhomeApp.Web.Models
{
    public class PostAccountModel
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Debe registrar un usuario")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El usuario debe tener entre 5 a 50 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe registrar una contraseña")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La contraseña debe tener entre 5 a 50 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe elegir un tipo de usuario")]
        public int UserType { get; set; }

        public string Verify { get; set; }
    }
}
