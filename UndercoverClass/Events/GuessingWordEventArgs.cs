using UndercoverClass.Game;
using UndercoverClass.Rules;

namespace UndercoverClass.Events
{
    public class GuessingWordEventArgs : EventArgs
    {
        

        public string word { get; set; }

        public IRole Playeur { get; set; }

        public GuessingWordEventArgs(string word, IRole playeur)
        {
            this.word = word;
            Playeur = playeur;
        }
    }
}