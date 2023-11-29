using Microsoft.AspNetCore.Authorization;

namespace UsuariosApi.Authorization
{
    public class IdadeMinima : IAuthorizationRequirement
    {
        public IdadeMinima(int age)
        {
            Age = age;
        }
        public int Age { get; set; }
    }
}
