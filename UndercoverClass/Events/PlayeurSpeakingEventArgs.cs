using UndercoverClass.Rules;

namespace UndercoverClass.Events
{
    public class PlayeurSpeakingEventArgs : EventArgs
    {
        public IRole Role;

        public PlayeurSpeakingEventArgs(IRole role)
        {
            Role = role;
        }
    }
}