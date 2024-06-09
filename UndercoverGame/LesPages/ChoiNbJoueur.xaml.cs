using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using UndercoverClass.Board;
using UndercoverClass.Game;

namespace UndercoverGame.LesPages;

public partial class ChoiNbJoueur : ContentPage
{
   
    private Partie PartieP;
    
    public ChoiNbJoueur(Partie partie) 
    {
        InitializeComponent();
        BindingContext = partie;
        PartieP= partie;
       
        
    }
	 

    public void PlusJoueurs(object sender, EventArgs e)
    { 
        //PartieP.PickingNumberPlayeur +=(sender, e) => e.Parametres.Ajouter(1, "Joueurs");
        //PartieP.ChoisirNbJoueur();
        //PartieP.PickingNumberPlayeur -= (sender, e) => e.Parametres.Ajouter(1, "Joueurs");
        PartieP.Parametres.Ajouter(1, "Joueurs");
    }

    public void MoinsJoueurs(object sender, EventArgs e)
    {
        //PartieP.PickingNumberPlayeur +=(sender, e) => e.Parametres.Ajouter(1, "Joueurs");
        //PartieP.ChoisirNbJoueur();
        //PartieP.PickingNumberPlayeur -= (sender, e) => e.Parametres.Ajouter(1, "Joueurs");
        PartieP.Parametres.Ajouter(-1, "Joueurs");
        
    }

    public void PlusUnder(object sender, EventArgs e)
    {
        //PartieP.PickingNumberPlayeur += (sender, e) => e.Parametres.Ajouter(1, "Under");
        //PartieP.ChoisirNbUnder();
        //PartieP.PickingNumberPlayeur -= (sender, e) => e.Parametres.Ajouter(1, "Under");
        PartieP.Parametres.Ajouter(1, "Under");
    }

    public void MoinsUnder(object sender, EventArgs e)
    {
        //PartieP.PickingNumberPlayeur += (sender, e) => e.Parametres.Ajouter(1, "Under");
        //PartieP.ChoisirNbUnder();
        //PartieP.PickingNumberPlayeur -= (sender, e) => e.Parametres.Ajouter(1, "Under");
        PartieP.Parametres.Ajouter(-1, "Under");
    }

    public void PlusWhite(object sender, EventArgs e)
    {
        //PartieP.PickingNumberPlayeur += (sender, e) => e.Parametres.Ajouter(1, "Under");
        //PartieP.ChoisirNbUnder();
        //PartieP.PickingNumberPlayeur -= (sender, e) => e.Parametres.Ajouter(1, "Under");
        PartieP.Parametres.Ajouter(1, "White");
    }

    public void MoinsWhite(object sender, EventArgs e)
    {
        //PartieP.PickingNumberPlayeur += (sender, e) => e.Parametres.Ajouter(1, "Under");
        //PartieP.ChoisirNbUnder();
        //PartieP.PickingNumberPlayeur -= (sender, e) => e.Parametres.Ajouter(1, "Under");
        PartieP.Parametres.Ajouter(-1, "White");
    }

    public void PlusRound(object sender, EventArgs e)
    {
        //PartieP.PickingNumberPlayeur += (sender, e) => e.Parametres.Ajouter(1, "Under");
        //PartieP.ChoisirNbUnder();
        //PartieP.PickingNumberPlayeur -= (sender, e) => e.Parametres.Ajouter(1, "Under");
        PartieP.Parametres.Ajouter(1, "Round");
    }

    public void MoinsRound(object sender, EventArgs e)
    {
        //PartieP.PickingNumberPlayeur += (sender, e) => e.Parametres.Ajouter(1, "Under");
        //PartieP.ChoisirNbUnder();
        //PartieP.PickingNumberPlayeur -= (sender, e) => e.Parametres.Ajouter(1, "Under");
        PartieP.Parametres.Ajouter(-1, "Round");
    }
    public void AllerProchainePage(object sender, EventArgs e)
    {
        PartieP.ValiderNbJoueurs();
        PartieP.Page = 1;
        PartieP.Serializer.WritePartie(PartieP);
        Navigation.PushAsync(new ChoiNom(PartieP));
    }
    public void RevnirPageDaccueil(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PageAccueil());
    }

}