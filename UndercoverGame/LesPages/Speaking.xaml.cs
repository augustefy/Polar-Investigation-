using UndercoverClass.Game;
using UndercoverClass.Persistance;

namespace UndercoverGame.LesPages;

public partial class Speaking : ContentPage
{
    public static readonly BindableProperty QuiProperty =
    BindableProperty.Create("Qui", typeof(string), typeof(Speaking), "simoni", propertyChanged: (s, n, o) =>
    {

    });

    public string Qui
    {
        get => (string)GetValue(QuiProperty);
        set => SetValue(QuiProperty, value);
    }

    public static readonly BindableProperty TitretProperty =
    BindableProperty.Create("Titret", typeof(string), typeof(Speaking), "A vous de parler !");

    public string Titret
    {
        get => (string)GetValue(TitretProperty);
        set => SetValue(TitretProperty, value);
    }

    public static readonly BindableProperty Img1Property =
    BindableProperty.Create("Img1", typeof(string), typeof(Speaking), "simoni", propertyChanged: (s, n, o) =>
    {

    });

    public string Img1
    {
        get => (string)GetValue(Img1Property);
        set => SetValue(Img1Property, value);
    }

    public static readonly BindableProperty Img2Property =
    BindableProperty.Create("Img2", typeof(string), typeof(Speaking), "simoni", propertyChanged: (s, n, o) =>
    {

    });

    public string Img2
    {
        get => (string)GetValue(Img2Property);
        set => SetValue(Img2Property, value);
    }

    public static readonly BindableProperty Img3Property =
    BindableProperty.Create("Img3", typeof(string), typeof(Speaking), "simoni", propertyChanged: (s, n, o) =>
    {

    });

    public string Img3
    {
        get => (string)GetValue(Img3Property);
        set => SetValue(Img3Property, value);
    }

    public static readonly BindableProperty Txt1Property =
    BindableProperty.Create("Txt1", typeof(string), typeof(Speaking), "simoni", propertyChanged: (s, n, o) =>
    {

    });

    public string Txt1
    {
        get => (string)GetValue(Txt1Property);
        set => SetValue(Txt1Property, value);
    }

    public static readonly BindableProperty Txt3Property =
    BindableProperty.Create("Txt3", typeof(string), typeof(Speaking), "simoni", propertyChanged: (s, n, o) =>
    {

    });

    public string Txt3
    {
        get => (string)GetValue(Txt3Property);
        set => SetValue(Txt3Property, value);
    }

    public Round round2 { get; private set; }
    public Tour t { get; private set; }
    private int aQuiTour = 0;

    private Partie partie;
    public Speaking(Partie p)
	{
		InitializeComponent();

        round2 = p.Rounds[p.IndiceR];
        partie = p;
        BindingContext = this;
        Qui = round2.JoueursVivant[aQuiTour].Joueur.Name;
        Images();
        Texts();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        aQuiTour = aQuiTour + 1;
        Texts();
        Images();
        
    }

    private void Images()
    {
        if (aQuiTour == 0)
        {
            Img1 = "";
            Img2 = round2.JoueursVivant[aQuiTour].Joueur.Image;
            Img3 = round2.JoueursVivant[aQuiTour+1].Joueur.Image;
        }
        else if (aQuiTour == (round2.JoueursVivant).Count-1)
        {
            Img1 = round2.JoueursVivant[aQuiTour-1].Joueur.Image;
            Img2 = round2.JoueursVivant[aQuiTour].Joueur.Image;
            Img3 = "";
        }
        else if (aQuiTour == (round2.JoueursVivant).Count)
        {
            partie.Page = 4;
            partie.Serializer.WritePartie(partie);
            Navigation.PushAsync(new Voter(partie));
            return;
        }
        else
        {
            Img1 = round2.JoueursVivant[aQuiTour - 1].Joueur.Image;
            Img2 = round2.JoueursVivant[aQuiTour].Joueur.Image;
            Img3 = round2.JoueursVivant[aQuiTour + 1].Joueur.Image;
        }
        Qui = round2.JoueursVivant[aQuiTour].Joueur.Name;
        return;
    }

    private void Texts()
    {
        if(aQuiTour==0)
        {
            Txt1 = "";
            Txt3 = "Preparer Vous Etes Suivant!";
        }
        else if (aQuiTour == (round2.JoueursVivant).Count-1)
        {
            Txt3 = "";
            Txt1 = "Vous Avez Deja Parler!";
        }
        else if (aQuiTour == (round2.JoueursVivant).Count)
        {
            Txt3 = "";
            Txt1 = "Vous Avez Deja Parler!";
        }
        else
        {
            Txt3 = "Preparer Vous Etes Suivant!";
            Txt1 = "Vous Avez Deja Parler!";
        }
    }

    public void AllerPageNbChoi(object sender, EventArgs e)
    {
        Partie partie2;
        if (partie.GetType() == typeof(JsonSerializer))
        {
            partie2 = new Partie(new JsonSerializer());
        }
        else
            partie2 = new Partie(new XmlSerializer());
        Navigation.PushAsync(new ChoiNbJoueur(partie2));
        return;
    }
    public void RevnirPageDaccueil(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PageAccueil());
        return;
    }
}