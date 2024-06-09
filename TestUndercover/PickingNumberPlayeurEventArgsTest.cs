using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Board;
using UndercoverClass.Game;
using UndercoverClass.Events;


namespace TestUndercover
{
    public class PickingNumberPlayeurEventArgsTest

    {
        public event EventHandler<PickingNumberPlayeurEventArgs>? PickingNumberPlayeurEvent;

        protected virtual void OnPickingNumberPlayeur(PickingNumberPlayeurEventArgs e)// j'invoque l'évenement afin de tester que les bonnnezs donné sont rentré
        {
            PickingNumberPlayeurEvent?.Invoke(this, e);
        }

        [Fact]
        public void PickingNumberRoundCheckRightDonnee()
        {
            var p = new Parametres(6);

            string t = "type";

            PickingNumberPlayeurEventArgs eventArgs = null;
            PickingNumberPlayeurEvent += (sender, args) => {
                eventArgs = args;
            };
            OnPickingNumberPlayeur(new PickingNumberPlayeurEventArgs(p, t));
            Assert.NotNull(eventArgs);
            Assert.Equal(t, eventArgs.Type);
            Assert.Equal(p, eventArgs.Parametres); 
        }
    }
}
