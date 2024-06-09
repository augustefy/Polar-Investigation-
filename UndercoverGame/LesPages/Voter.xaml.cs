using CommunityToolkit.Maui.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UndercoverClass.Board;
using UndercoverClass.Game;
using UndercoverClass.Rules;
using UndercoverGame.Popups;
using UndercoverClass.Persistance;

namespace UndercoverGame.LesPages;

public partial class Voter : ContentPage
{

    public static readonly BindableProperty QuiProperty =
    BindableProperty.Create("Qui", typeof(string), typeof(Voter), "simoni", propertyChanged: (s, n, o) =>
    {

    });

    public string Qui
    {
        get => (string)GetValue(QuiProperty);
        set => SetValue(QuiProperty, value);
    }

    public static readonly BindableProperty TitretProperty =
    BindableProperty.Create("Titret", typeof(string), typeof(Voter), "Voter Celle Que Vous Douter!");

    public string Titret
    {
        get => (string)GetValue(TitretProperty);
        set => SetValue(TitretProperty, value);
    }

    public static readonly BindableProperty ImgProperty =
    BindableProperty.Create("Img", typeof(string), typeof(Voter), "pupu", propertyChanged: (s, n, o) =>
    {

    });

    public string Img
    {
        get => (string)GetValue(ImgProperty);
        set => SetValue(ImgProperty, value);
    }

    //public static readonly BindableProperty NbvProperty =
    //BindableProperty.Create("Nbv", typeof(int), typeof(Voter), 0);

    //public int Nbv
    //{
    //    get => (int)GetValue(NbvProperty);
    //    set => SetValue(NbvProperty, value);
    //}

    public Round round2 { get; private set; }
    private int aQuiTour = 0;
    private Vote eliminer;
    private Joueur i;
    private Tour t { get; set; }
    private Case Casec;
    private Partie partie;

    // Votr n'a pas besoin de recevoir Round, ce mieux li donner Tour 
    public Voter(Partie p)
    {
		InitializeComponent();
        round2 = p.Rounds[p.IndiceR];
        partie = p;
        t = round2.Tours[round2.IndiceI];
        BindingContext = this;
        Qui = round2.JoueursVivant[aQuiTour].Joueur.Name;
        //round2.Tours[0].PlayeurVoting -= FonctionVote;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        var button = (Microsoft.Maui.Controls.ImageButton)sender;
        Casec = (Case)button.BindingContext;
        if(!Casec.Joueur.Mort)
        {
            round2.Tours[round2.IndiceI].PlayeurVoting += FonctionVote;
            round2.Tours[round2.IndiceI].Voter(round2.JoueursVivant[aQuiTour], Casec);
            round2.Tours[round2.IndiceI].PlayeurVoting -= FonctionVote;
        }
        
    }

    public async void FonctionVote(object? sender, UndercoverClass.Events.PlayeurVotingEventArgs e)
    {
        e.Votes.Add(new Vote(e.Casec.Joueur));
        i = e.Playeur.Joueur;
        (e.Casec.VotesImgv).Add(i);
        e.Casec.VotesImg = new ObservableCollection<Joueur>(e.Casec.VotesImgv);
        aQuiTour = aQuiTour + 1;
        if (aQuiTour < (round2.JoueursVivant).Count)
        {
            Qui = round2.JoueursVivant[aQuiTour].Joueur.Name;
        }
        else if (aQuiTour == (round2.JoueursVivant).Count)
        {
            Qui = "Cliquer pour valider vote!";
            round2.Tours[round2.IndiceI].TransformDic();
            Vote eliminer = t.CompterVote();
            t.FinDeTour(eliminer, round2.JoueursVivant, round2.JoueursMort);

            if (eliminer.JoueurVote.Role=="White") 
            {
                Regles.GuessingWord += devienMot;
                bool j = round2.VerifGagner();
                Regles.GuessingWord -= devienMot;
            }
            else if (eliminer.JoueurVote.Role == "Civil") 
            {
                ///< verifie si under a gagner
                Regles.RoleWon += civilMort;
                bool j = round2.VerifGagner();
                Regles.RoleWon -= civilMort;
                foreach (Case c in round2.Plateau.Board)
                {
                    c.VotesImgv = new List<Joueur>();
                    c.VotesImg = new ObservableCollection<Joueur>(c.VotesImgv);
                    if (c.Joueur.Joueur.Name == eliminer.JoueurVote.Joueur.Name)
                    {
                        c.Text += " mort!";
                    }
                }
                if (j==false)
                {
                    var popup = new PopUpCivilMort(eliminer.JoueurVote);

                    var result = await this.ShowPopupAsync(popup);
                    if ((result == null) || (result.Equals("yes")))
                    {
                        //round2.Tours[0].PlayeurVoting -= FonctionVote;
                        round2.CreerTour();
                        round2.IndiceI = round2.IndiceI + 1;
                        
                        partie.Page = 3;
                        partie.Serializer.WritePartie(partie);
                        await Navigation.PushAsync(new Speaking(partie));
                    }
                }
            }
            else if (eliminer.JoueurVote.Role == "Under") 
            {
                ///< verifie si civil a gagner
                Regles.RoleWon += civilMort;
                bool j = round2.VerifGagner();
                Regles.RoleWon -= civilMort;
                foreach (Case c in round2.Plateau.Board)
                {
                    c.VotesImgv = new List<Joueur>();
                    c.VotesImg = new ObservableCollection<Joueur>(c.VotesImgv);
                    if (c.Joueur.Joueur.Name == eliminer.JoueurVote.Joueur.Name)
                    {
                        c.Text += " mort!";
                    }
                }
                if (j == false)
                {
                    var popup = new PopUpCivilMort(eliminer.JoueurVote);

                    var result = await this.ShowPopupAsync(popup);
                    if ((result == null) || (result.Equals("yes")))
                    {
                        //round2.Tours[0].PlayeurVoting -= FonctionVote;
                        round2.CreerTour();
                        round2.IndiceI = round2.IndiceI + 1;
                        partie.Page = 3;
                        partie.Serializer.WritePartie(partie);
                        await Navigation.PushAsync(new Speaking(partie));
                    }
                }
            }
        }
    }

    async void devienMot(object? sender, UndercoverClass.Events.GuessingWordEventArgs e)
    {
        var popup = new PopUpWhite(e.Playeur);
        var result = await this.ShowPopupAsync(popup);
        //int i = 5;
        if (result.Equals(e.word))
        {
            //a modifier popup
            var popup2 = new PopUpWhiteWin(e.Playeur);

            var result2 = await this.ShowPopupAsync(popup2);
            if ((result2 == null) || (result2.Equals("yes")))
            {
                partie.IndiceR += 1;
                if (partie.IndiceR < partie.Parametres.NbRounds)
                {
                    
                    partie.CreerRound();
                    partie.Page = 2;
                    partie.Serializer.WritePartie(partie);
                    await Navigation.PushAsync(new CardPick(partie));
                }
                else
                    await Navigation.PushAsync(new PageAccueil());
            }
        }
        else
        {
            Regles.RoleWon += civilMort;
            bool j = round2.VerifGagner();
            Regles.RoleWon -= civilMort;
            foreach (Case c in round2.Plateau.Board)
            {
                c.VotesImgv = new List<Joueur>();
                c.VotesImg = new ObservableCollection<Joueur>(c.VotesImgv);
                if (c.Joueur.Joueur.Name == e.Playeur.Joueur.Name)
                {
                    c.Text += " mort!";
                }
            }
            if (j == false)
            {
                var popup5 = new PopUpCivilMort(e.Playeur);

                var result5 = await this.ShowPopupAsync(popup5);
                if ((result5 == null) || (result5.Equals("yes")))
                {
                    //round2.Tours[0].PlayeurVoting -= FonctionVote;
                    round2.CreerTour();
                    round2.IndiceI = round2.IndiceI + 1;
                    partie.Page = 3;
                    partie.Serializer.WritePartie(partie);
                    await Navigation.PushAsync(new Speaking(partie));
                }
            }
        }

        return;
    }

    async void civilMort(object? sender, UndercoverClass.Events.RoleWonEventArgs e)
    {
        var popup = new PopUpUnderWin(e.Role, e.Joueurs);

        var result = await this.ShowPopupAsync(popup);
        if ((result == null) || (result.Equals("yes")))
        {
            //Regles.RoleWon -= civilMort;
            partie.IndiceR += 1;
            if (partie.IndiceR < partie.Parametres.NbRounds)
            {
                
                partie.Page = 2;
                partie.CreerRound();
                partie.Serializer.WritePartie(partie);
                await Navigation.PushAsync(new CardPick(partie));
            }
            else
                await Navigation.PushAsync(new PageAccueil());
        }

    }

    public void AllerPageNbChoi(object sender, EventArgs e)
    {
        Partie partie2;
        if (partie.GetType()== typeof(JsonSerializer))
        { 
            partie2 = new Partie(new JsonSerializer()); 
        }
        else
            partie2= new Partie(new XmlSerializer());

        Navigation.PushAsync(new ChoiNbJoueur(partie2));
        return;
    }
    public void RevnirPageDaccueil(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PageAccueil());
        return;
    }
}