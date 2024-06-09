using UndercoverClass.Game;

namespace UndercoverClass.Events
{
    public class PickingNumberRoundEventArgs : EventArgs
    {
        public Parametres Parametres { get; set; }

        public PickingNumberRoundEventArgs(Parametres parametres)
        {
            Parametres = parametres;
        }
    }
}