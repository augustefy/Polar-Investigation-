using UndercoverClass.Game;
namespace UndercoverGame.LesPages;

public partial class ChoiNom : ContentPage
{
	private Partie partie1;
	public ChoiNom(Partie partie)
	{
		InitializeComponent();
		this.partie1 = partie;
		BindingContext = partie;
	}

    private void Button_Clicked_Image_Left(object sender, EventArgs e)
    {
		//var j = sender.GetType().GetProperty("Joueur");
		var button = (Microsoft.Maui.Controls.Button)sender;
		var joueur = (Joueur)button.BindingContext;
		joueur.ChoisirImage(joueur.Image, false);
        //var jj=sender.GetType("Joueur").GetMember();

        //partie1.Joueurs[]
        //j.ChoisirImage(j.Image, true);
    }
    private void Button_Clicked_Image_Right(object sender, EventArgs e)
    {
        var button = (Microsoft.Maui.Controls.Button)sender;
        var joueur = (Joueur)button.BindingContext;
        joueur.ChoisirImage(joueur.Image, true);
    }

    private void Button_Clicked_Start(object sender, EventArgs e)
    {
  
        bool b=false;
        for(int i = 0; i < partie1.Joueurs.Count(); i++) 
        {
            
            List<Joueur> otherJ = new List<Joueur>(partie1.Joueurs);
            otherJ.Remove(partie1.Joueurs[i]);
            if(otherJ.Contains(partie1.Joueurs[i]))
                b= true;
        }

        if(b)
            DisplayAlert("Alert", "Il ne peut pas avoir plusieurs joueurs avec le même nom", "OK");
        else
        {
            partie1.CreerRound();
            partie1.Page = 2;
            partie1.Serializer.WritePartie(partie1);

            Navigation.PushAsync(new CardPick(partie1));
        }

    }

    public void RevnirPageDaccueil(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PageAccueil());
    }
}