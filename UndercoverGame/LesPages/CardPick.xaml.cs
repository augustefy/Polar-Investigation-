using System.Diagnostics;
using UndercoverClass.Board;
using UndercoverClass.Game;
using CommunityToolkit.Maui.Views;
using UndercoverClass.Rules;
using UndercoverClass;
using System.Data;
using UndercoverClass.Persistance;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)] pour compiller plus rapidment

namespace UndercoverGame.LesPages;

public partial class CardPick : ContentPage
{
    public static readonly BindableProperty QuiProperty =
        BindableProperty.Create("Qui", typeof(string), typeof(CardPick), "simoni", propertyChanged: (s, n, o) =>
        {

        });

    public string Qui
    {
        get => (string)GetValue(QuiProperty);
        set => SetValue(QuiProperty, value);
    }

    public static readonly BindableProperty TitretProperty =
    BindableProperty.Create("Titret", typeof(string), typeof(Speaking), "Prenez Votre Carte");

    public string Titret
    {
        get => (string)GetValue(TitretProperty);
        set => SetValue(TitretProperty, value);
    }

    //public Partie Partiep { get; private set; } = new Partie([new Mot("pomme", "watermellon")]);  // vant c'�tait plateau
    private Partie partie2;
    //private static Parametres p = new Parametres(7);
    //public Round r { get; private set; } = new Round(new Mot("pomme", "watermellon"), [new Joueur("simoni"), new Joueur("meg"), new Joueur("ogi"), new Joueur("crisis"), new Joueur("tibo"), new Joueur("wahuhel"), new Joueur("lupis")], p);
    public Round r { get; private set; }
    //public List<IRole> Roles = new List<IRole>();
    private int aQuiTour = 0;
    //public string jHead { get; private set; }

    public CardPick(Partie partie1)
	{
		InitializeComponent();
        this.partie2 = partie1;
        r = partie2.Rounds[partie2.IndiceR];
        BindingContext = this;
        Qui = r.JoueursVivant[aQuiTour].Joueur.Name;
        //var test = r.JoueursVivant[aQuiTour];
        //head = new headerPickCard(test);
    }

    async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var button =(Microsoft.Maui.Controls.ImageButton)sender;
        var Casec = (Case)button.BindingContext;

        
        //CartesC.Text = $"simoni";

        if (Casec.Face == false)
        {
            IRole j = r.JoueursVivant[aQuiTour];

            aQuiTour = aQuiTour + 1;
            r.PickingCase += FonctionFace;
            r.JoueursVivant[aQuiTour-1] = r.ChoisirCase(j, Casec);
            r.PickingCase -= FonctionFace;
        }
        
       
        //SemanticScreenReader.Announce(CartesC.Text);
    }

    async void FonctionFace(object? sender, UndercoverClass.Events.PickingCaseEventArgs e)
    {
        if (e.Casec.Mot == r.Mott.MotU)
        {
            e.Playeur.ChangementRole = "Under";
            e.Casec.Joueur = new Under(e.Playeur.Joueur);
        }

        else if (e.Casec.Mot == r.Mott.MotW)
        {
            e.Playeur.ChangementRole = "White";
            e.Casec.Joueur = new White(e.Playeur.Joueur);
        }

        else
        {
            e.Casec.Joueur = e.Playeur;
        }

        var popup = new PopUpWord(e.Casec);
        
        var result = await this.ShowPopupAsync(popup);

        e.Casec.ChangeFace();

        e.Casec.ImageSource = e.Casec.Joueur.Joueur.Image;
        e.Casec.Text = e.Casec.Joueur.Joueur.Name;
        if ((result==null)||(result.Equals("yes")))
        {
            if (aQuiTour < partie2.Parametres.NbJoueurs)
            {
                Qui = r.JoueursVivant[aQuiTour].Joueur.Name;

            }
            if (aQuiTour == partie2.Parametres.NbJoueurs)
            {
                Qui = "Click any card to start";
                r.ChangerOrdreDeJeu();
                r.CreerTour();
                partie2.Page = 3;
                partie2.Serializer.WritePartie(partie2);
                await Navigation.PushAsync(new Speaking(partie2));
            }
        }
    }

    public void AllerPageNbChoi(object sender, EventArgs e)
    {
        Partie partie = new Partie(new XmlSerializer());
        Navigation.PushAsync(new ChoiNbJoueur(partie));
    }
    public void RevnirPageDaccueil(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PageAccueil());
    }
}