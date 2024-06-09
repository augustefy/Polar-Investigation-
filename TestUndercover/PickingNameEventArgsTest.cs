using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Rules;
using UndercoverClass.Events;
using UndercoverClass.Game;
using Microsoft.VisualBasic;
using UndercoverClass.Board;

namespace TestUndercover
{
    public class PickingNameEventTest
    {
        public event EventHandler<PickingNameEventArgs>? PickingNameEvent;

        protected virtual void OnPickingName(PickingNameEventArgs e)
        {
            PickingNameEvent?.Invoke(this, e);
        }

        [Fact]
        public void PickingNameEventCheckRightDonnee()
        {
            var j = new Joueur(1);

            var lj = new List<Joueur> { new Joueur(1), new Joueur(2) };

            PickingNameEventArgs? eventArgs = null;

            PickingNameEvent += (sender, args) =>
            {
                eventArgs = args;
            };

            OnPickingName(new PickingNameEventArgs(j, lj));
            Assert.NotNull(eventArgs);
            Assert.Equal(j, eventArgs.Playeur);
            Assert.Equal(lj, eventArgs.Joueurs);
        }
    }
}