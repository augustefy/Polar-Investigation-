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
    public class PickingCaseEventTest
    {
        public IRole p { get; set; }

        public event EventHandler<PickingCaseEventArgs>? PickingCaseEvent;

        protected virtual void OnPickingCase(PickingCaseEventArgs e)
        {
            PickingCaseEvent?.Invoke(this, e);
        }

        [Fact]
        public void PickingCaseEventCheckRightDonnee()
        {
            var m = new Mot("x", "y");

            var c = new Case(1, 1);

            var b = new List<Case> { new Case(1, 1), new Case(1, 2) };

            PickingCaseEventArgs? eventArgs = null;

            PickingCaseEvent += (sender, args) =>
            {
                eventArgs = args;
            };

            OnPickingCase(new PickingCaseEventArgs(p, b, m, c));
            Assert.NotNull(eventArgs);
            Assert.Equal(p, eventArgs.Playeur);
            Assert.Equal(b, eventArgs.Board);
            Assert.Equal(m, eventArgs.Mot);
            Assert.Equal(c, eventArgs.Casec);
        }
    }

}