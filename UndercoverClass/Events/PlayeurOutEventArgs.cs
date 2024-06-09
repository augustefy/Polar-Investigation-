using UndercoverClass.Rules;

namespace UndercoverClass.Events
{
    public class PlayeurOutEventArgs : EventArgs
    {
        public IRole Playeur {  get; set; }

        public PlayeurOutEventArgs(IRole playeur)
        {
            Playeur = playeur;
        }
    }
}