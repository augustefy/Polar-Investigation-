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
    public class PickingNumberRoundEventArgsTest 

    {
        public event EventHandler<PickingNumberRoundEventArgs>? PickingNumberRoundEvent;

        protected virtual void OnPickingNumberRound(PickingNumberRoundEventArgs e)// j'invoque l'évenement afin de tester que les bonnnezs donné sont rentré
        {
            PickingNumberRoundEvent?.Invoke(this, e);
        }

        [Fact]
        public void PickingNumberRoundCheckRightDonnee()
        {
            var p = new Parametres(6);

            PickingNumberRoundEventArgs? eventArgs = null;
            PickingNumberRoundEvent += (sender, args) => {
                eventArgs = args;
            };
            OnPickingNumberRound(new PickingNumberRoundEventArgs(p));
            Assert.NotNull(eventArgs);
            Assert.Equal(p, eventArgs.Parametres); 
        }
    }
}
