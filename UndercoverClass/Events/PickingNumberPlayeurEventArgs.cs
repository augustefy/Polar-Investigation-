using UndercoverClass.Game;

namespace UndercoverClass.Events
{
    public class PickingNumberPlayeurEventArgs : EventArgs
    {
        public Parametres Parametres { get; set; }

        public string Type { get; set; }

        public PickingNumberPlayeurEventArgs(Parametres parametres, string type)
        {
            Parametres = parametres;
            Type = type;
        }
    }
}