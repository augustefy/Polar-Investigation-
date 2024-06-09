using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Rules;
using UndercoverClass.Events;
using UndercoverClass.Game;
using Microsoft.VisualBasic;

namespace TestUndercover
{
    public class GuessingWordEventTest
    {
        public IRole? p { get; set; }

        public event EventHandler<GuessingWordEventArgs>? GuessingWordEvent;

        protected virtual void OnGuessingWord(GuessingWordEventArgs e)
        {
            GuessingWordEvent?.Invoke(this, e);
        }

        [Fact]
        public void GuessingWordEventCheckRightDonnee()
        {
            string w = "Word";

            GuessingWordEventArgs? eventArgs = null;

            GuessingWordEvent += (sender, args) => {
                eventArgs = args;
            };

            OnGuessingWord(new GuessingWordEventArgs(w, p));
            Assert.NotNull(eventArgs);
            Assert.Equal(p, eventArgs.Playeur);
            Assert.Equal(w, eventArgs.word);
            
        }
}
}