using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Board;
using UndercoverClass.Game;
using UndercoverClass.Events;
using UndercoverClass.Rules;


namespace TestUndercover
{
    public class RoleWonEventArgsTest

    {
        public event EventHandler<RoleWonEventArgs>? RoleWonEvent;

        protected virtual void OnRoleWon(RoleWonEventArgs e)// j'invoque l'évenement afin de tester que les bonnnezs donné sont rentré
        {
            RoleWonEvent?.Invoke(this, e);
        }

        public IRole? r2 { get; set; }

        public IRole? r1 { get; set; }

        [Fact]
        public void ShowingBoardEventCheckRightDonnee()
        {
            string r = "role";
            var lr = new List<IRole> { r1, r2 };

            RoleWonEventArgs? eventArgs = null;
            RoleWonEvent += (sender, args) => {
                eventArgs = args;
            };
            OnRoleWon(new RoleWonEventArgs(r, lr));
            Assert.NotNull(eventArgs);
            Assert.Equal(r, eventArgs.Role);
        }
    }
}
