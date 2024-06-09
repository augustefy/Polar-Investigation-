using UndercoverClass.Game;
using UndercoverClass.Persistance;
namespace UndercoverGame.LesPages;
using CommunityToolkit.Maui.Views;
using UndercoverGame.Popups;

public partial class PageAccueil : ContentPage
{
	public PageAccueil()
	{
		InitializeComponent();
	}
    Partie partie = new Partie(new JsonSerializer());
    public void AllerProchainePage(object sender, EventArgs e)
    {
        
        Navigation.PushAsync(new ChoiNbJoueur(partie));
    }

    private void RechargerPartie(object sender, EventArgs e)
    {
        
        
        partie = partie.Serializer.ReadPartie();
        

        switch (partie.Page)
        {
            case 1:
                Navigation.PushAsync(new ChoiNom(partie));
                break;
            case 2:
                Navigation.PushAsync(new CardPick(partie));
                break;
            case 3:
                Navigation.PushAsync(new Speaking(partie));
                break;
            case 4:
                Navigation.PushAsync(new Voter(partie));
                break;
            default:
                DisplayAlert("Chargement", "Il n'y a pas de partie à charger", "OK");
                break;
        }
    }
}