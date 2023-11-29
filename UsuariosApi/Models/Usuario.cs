using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Models
{
    public class Usuario : IdentityUser 
    {
        public DateTime BirthDate { get; set; }
        public Usuario() : base() { }
    }
}
