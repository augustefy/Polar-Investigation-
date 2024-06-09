using UndercoverClass.Board;
using UndercoverClass.Game;
using UndercoverClass.Rules;

namespace UndercoverClass.Events
{
    public class PickingCaseEventArgs: EventArgs
    {
        public IRole Playeur { get; set; }
        public List<Case> Board {  get; set; }

        public Mot Mot { get; set; }

        public Case Casec { get; set; }


        public  PickingCaseEventArgs(IRole joueur, List<Case> board, Mot mot, Case casec)
        {
            Playeur = joueur;
            Board = board;
            Mot = mot;
            Casec = casec;
 
        }
    }
}