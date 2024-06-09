using UndercoverClass.Rules;

namespace UndercoverClass.Events
{
    public class RoleWonEventArgs
    {
        public string Role { get; set; }

        public List<IRole> Joueurs { get; set; }

        public RoleWonEventArgs(string role, List<IRole> roles) 
        { 
            Role = role;
            Joueurs = roles;
        }
    }
}