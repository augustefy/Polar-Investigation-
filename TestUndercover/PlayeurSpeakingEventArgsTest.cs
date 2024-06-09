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
    public class PlayeurSpeakingEventArgsTest
    {
        public IRole r { get; set; }


        public event EventHandler<PlayeurSpeakingEventArgs>? PlayeurSpeakingEvent;

        protected virtual void OnPlayeurSpeaking(PlayeurSpeakingEventArgs e)
        {
            PlayeurSpeakingEvent?.Invoke(this, e);
        }

        [Fact]
        public void PlayeurSpeakingGoodDonnee()
        {
            PlayeurSpeakingEventArgs? eventArgs = null;

            PlayeurSpeakingEvent += (sender, args) => {
                eventArgs = args;
            };

            OnPlayeurSpeaking(new PlayeurSpeakingEventArgs(r));
            Assert.NotNull(eventArgs);
            Assert.Equal(r, eventArgs.Role);
        }
}
}