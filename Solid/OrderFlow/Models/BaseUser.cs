namespace OrderFlow.Models
{
    // Classe base de usuário
    public class BaseUser
    {
        public string Name { get; set; }

        public string Email { get; set; }

        // Método virtual pode ser sobrescrito
        public virtual string GetRole()
        {
            return "User";
        }
    }
}