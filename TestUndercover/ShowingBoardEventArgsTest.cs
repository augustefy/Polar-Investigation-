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
    public class ShowingBoardEventArgsTest

    {
        public event EventHandler<ShowingBoardEventArgs>? ShowingBoardEvent;

        protected virtual void OnShowingBoard(ShowingBoardEventArgs e)// j'invoque l'évenement afin de tester que les bonnnezs donné sont rentré
        {
            ShowingBoardEvent?.Invoke(this, e);
        }

        [Fact]
        public void ShowingBoardEventCheckRightDonnee()
        {
            var board = new List<Case>{ new Case(1,1), new Case(1,1) };

            ShowingBoardEventArgs? eventArgs = null;
            ShowingBoardEvent += (sender, args) => {
                eventArgs = args;
            };
            OnShowingBoard(new ShowingBoardEventArgs(board));
            Assert.NotNull(eventArgs);
            Assert.Equal(board, eventArgs.Board);
        }
    }
}
