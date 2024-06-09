using UndercoverClass.Board;
using UndercoverClass.Game;

namespace UndercoverGame;

public partial class Ztest : ContentPage
{
	public Case Casec { get; set; } = new Case(0, 0);
	public Joueur Joueurs { get; set; } = new Joueur("simoni");
    public Joueur Joueurm { get; set; } = new Joueur("meg");
    public Ztest()
	{
		InitializeComponent();
		Joueurs.Image = "cat.png";
        Joueurm.Image = "dog.png";
        Casec.VotesImg.Add(Joueurs);
        Casec.VotesImg.Add(Joueurm);
        BindingContext = Casec;
    }
}