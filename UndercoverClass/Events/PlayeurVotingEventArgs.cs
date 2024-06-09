using UndercoverClass.Board;
using UndercoverClass.Rules;

namespace UndercoverClass.Events
{
    public class PlayeurVotingEventArgs : EventArgs
    {
        public IRole Playeur {  get; set; }

        public List<Vote> Votes { get; set; }

        public Plateau Plateau { get; set; }

        public Case Casec { get; set; }

        public PlayeurVotingEventArgs(IRole playeur, List<Vote> votes, Plateau plateau, Case c)
        {
            Playeur = playeur;
            Votes = votes;
            Plateau = plateau;
            Casec = c;
        }
    }
}