using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UndercoverClass.Board;
using UndercoverClass.Game;
using UndercoverClass.Events;
using UndercoverClass.Rules;


namespace TestUndercover
{
    public class PlayeurVotingEventArgTest
    {
        public event EventHandler<PlayeurVotingEventArgs>? PlayeurVotingEvent;

        public IRole? p { get; set; }

        protected virtual void OnPlayeurVoting(PlayeurVotingEventArgs e)// j'invoque l'évenement afin de tester que les bonnnezs donné sont rentré
        {
            PlayeurVotingEvent?.Invoke(this, e);
        }

        [Fact]
        public void PlayeurVotingCheckRightDonnee()
        {
            var c = new Case(1, 1);
            var lv = new List<Vote>{new Vote(p), new Vote(p) };
            var m = new Mot("x", "y");
            var pl = new Plateau(1, 1, 1, 3, m);

            PlayeurVotingEventArgs? eventArgs = null;
            PlayeurVotingEvent += (sender, args) => {
                eventArgs = args;
            };
            OnPlayeurVoting(new PlayeurVotingEventArgs(p, lv, pl, c));
            Assert.NotNull(eventArgs);
            Assert.Equal(p, eventArgs.Playeur);
            Assert.Equal(pl, eventArgs.Plateau);
            Assert.Equal(c, eventArgs.Casec);
        }
    }
}
