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
    public class ValueClickedBadEventArgsTest

    {
        public event EventHandler<ValueClickedBadEventArgs>? ValueClickedBadEvent;

        protected virtual void OnValueClickedBad(ValueClickedBadEventArgs e)// j'invoque l'évenement afin de tester que les bonnnezs donné sont rentré
        {
            ValueClickedBadEvent?.Invoke(this, e);
        }

        [Fact]
        public void ValueClickedBadCheckRightDonnee()
        {
            string v = "valeur";

            ValueClickedBadEventArgs? eventArgs = null;
            ValueClickedBadEvent += (sender, args) => {
                eventArgs = args;
            };
            OnValueClickedBad(new ValueClickedBadEventArgs(v));
            Assert.NotNull(eventArgs);
            Assert.Equal(v, eventArgs.Valeur);
        }
    }
}
