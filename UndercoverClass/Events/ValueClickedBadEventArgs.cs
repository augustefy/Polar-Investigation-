namespace UndercoverClass.Events
{
    public class ValueClickedBadEventArgs : EventArgs
    {
        public string Valeur { get; set; }

        public ValueClickedBadEventArgs(string valeur)
        { 
            Valeur = valeur;
        }
    }
}