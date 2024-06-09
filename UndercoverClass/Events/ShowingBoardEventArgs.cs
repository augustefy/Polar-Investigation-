using UndercoverClass.Board;
namespace UndercoverClass.Events
{
    public class ShowingBoardEventArgs: EventArgs
    {
        public List<Case> Board {  get; set; }

        public ShowingBoardEventArgs(List<Case> board) 
        {
            Board = board; 

        }
    }
}