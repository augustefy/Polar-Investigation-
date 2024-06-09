using UndercoverClass.Game;

namespace UndercoverClass.Events
{
    public class PickingNameEventArgs : EventArgs
    {
        public Joueur Playeur { get; set; }

        public List<Joueur> Joueurs { get; set; }

        public PickingNameEventArgs(Joueur playeur, List<Joueur> joueurs)
        {
            Playeur = playeur;
            Joueurs = joueurs;
        }
    }
}