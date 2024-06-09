using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Rules;
using UndercoverClass.Events;
using UndercoverClass.Game;

namespace TestUndercover
{
    public class PlayeurOutEventTest
    {
        public IRole p { get; set; }


        public event EventHandler<PlayeurOutEventArgs>? PlayeurOutEvent;

        protected virtual void OnPlayeurOut(PlayeurOutEventArgs e)
        {
            PlayeurOutEvent?.Invoke(this, e);
        }

        [Fact]
        public void PlayeurOutEvent_Should_Be_Triggered_With_Correct_Data()
        {
            PlayeurOutEventArgs? eventArgs = null;

            PlayeurOutEvent += (sender, args) => {
                eventArgs = args;
            };

            OnPlayeurOut(new PlayeurOutEventArgs(p));
            Assert.NotNull(eventArgs);
            Assert.Equal(p, eventArgs.Playeur);
        }
}
}