namespace OrderFlow.Models
{
    // Admin herda comportamento do usuário
    public class AdminUser : BaseUser
    {
        public override string GetRole()
        {
            return "Administrator";
        }
    }
}