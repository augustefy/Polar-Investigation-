using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UndercoverClass.Rules;
using UndercoverClass.Events;
using UndercoverClass.Game;

namespace TestUndercover
{
    public class RestartVoteEventArgsTest
    {

        public event EventHandler<RestartVoteEventArgs>? RestartVoteEvent;

        protected virtual void OnRestartVote(RestartVoteEventArgs e)
        {
            RestartVoteEvent?.Invoke(this, e);
        }

        [Fact]
        public void RestartVoteGoodDonnee()
        {
            RestartVoteEventArgs? eventArgs = null;

            RestartVoteEvent += (sender, args) => {
                eventArgs = args;
            };

            OnRestartVote(new RestartVoteEventArgs());
            Assert.NotNull(eventArgs);
        }
}
}