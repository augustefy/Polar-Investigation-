using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Board;
using UndercoverClass.Events;
using UndercoverClass.Rules;
using UndercoverClass.Persistance;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

/**
 * @file Partie.cs
 * @brief Définition de la classe Partie qui gère le déroulement de la partie
 */
namespace UndercoverClass.Game
{
    [DataContract]
    [KnownType(typeof(XmlSerializer))]
    [KnownType(typeof(JsonSerializer))]
    public class Partie
    {
        /** Déclaration d'un événement qui permet de choisir le nom a joueur */
        public event EventHandler<PickingNameEventArgs> PickingName;

        /** vérification d'un événement qui permet de choisir le nom a joueur */
        public virtual void OnPickingName(Joueur j, List<Joueur> joueurs)
            => PickingName?.Invoke(this, new PickingNameEventArgs(j, joueurs));

        /** Déclaration d'un événement qui permet de choisir le nombre de joueurs */
        public event EventHandler<PickingNumberPlayeurEventArgs> PickingNumberPlayeur;

        /** vérification d'un événement qui permet de choisir le nombre de joueurs */
        public virtual void OnPickingNumberPlayeur(Parametres p, string type)
            => PickingNumberPlayeur?.Invoke(this, new PickingNumberPlayeurEventArgs(p, type));

        /** Déclaration d'un événement qui permet de choisir le nombre de rounds */
        public event EventHandler<PickingNumberRoundEventArgs> PickingNumberRound;

        /** vérification d'un événement qui permet de choisir le nombre de rounds. */
        public virtual void OnPickingNumberRound(Parametres p)
            => PickingNumberRound?.Invoke(this, new PickingNumberRoundEventArgs(p));

        /** Abonnement et désabonnement d'événements PickingCase*/
        public event EventHandler<PickingCaseEventArgs> PickingCase
        {
            add
            {
                PrivPickingCase += value;
            }

            remove
            {
                PrivPickingCase -= value;
            }
        }

        /** Déclaration d'un événement PrivPickingCase*/
        private event EventHandler<PickingCaseEventArgs> PrivPickingCase;

        /** Abonnement et désabonnement d'événements PlayeurOut*/
        public event EventHandler<PlayeurOutEventArgs> PlayeurOut
        {
            add
            {
                PrivPlayeurOut += value;
            }

            remove
            {
                PrivPlayeurOut -= value;
            }
        }

        /** Déclaration d'un événement PrivPlayeurOut*/
        private event EventHandler<PlayeurOutEventArgs> PrivPlayeurOut;

        /** Abonnement et désabonnement d'événements PlayeurVoting*/
        public event EventHandler<PlayeurVotingEventArgs> PlayeurVoting
        {
            add
            {
                PrivPlayeurVoting += value;

            }
            remove
            {
                PrivPlayeurVoting -= value;
            }
        }

        /** Déclaration d'un événement PrivPlayeurVoting*/
        private event EventHandler<PlayeurVotingEventArgs> PrivPlayeurVoting;

        /** Abonnement et désabonnement d'événements PlayeurSpeaking*/
        public event EventHandler<PlayeurSpeakingEventArgs> PlayeurSpeaking
        {
            add
            {
                PrivPlayeurSpeaking += value;

            }
            remove
            {
                PrivPlayeurSpeaking -= value;

            }
        }

        /** Déclaration d'un événement PrivPlayeurSpeaking*/
        private event EventHandler<PlayeurSpeakingEventArgs> PrivPlayeurSpeaking;

        /** Abonnement et désabonnement d'événements RestartVote*/
        public event EventHandler<RestartVoteEventArgs> RestartVote
        {
            add
            {
                PrivRestartVote += value;

            }
            remove
            {
                PrivRestartVote -= value;
            }
        }

        /** Déclaration d'un événement PrivRestartVote*/
        private event EventHandler<RestartVoteEventArgs> PrivRestartVote;

        /** Abonnement et désabonnement d'événements ShowingBoard*/
        public event EventHandler<ShowingBoardEventArgs> ShowingBoard
        {
            add
            {
                PrivShowingBoard += value;

            }
            remove { PrivShowingBoard -= value;}
        }

        /** Déclaration d'un événement PrivShowingBoard*/
        private event EventHandler<ShowingBoardEventArgs> PrivShowingBoard;


        [DataMember (Order =0)]
        /** Déclaration d'objet Parametres */
        public Parametres Parametres { get; set; } = new Parametres(3);

        [DataMember(Order = 2)]

        /** List contenant des objets Round */
        public List<Round> Rounds { get; set; }= new List<Round>();

        [DataMember(Order = 4)]

        /** List contenant des objets Mot non jouer */
        public List<Mot> MotsPasJouer { get; set; } = new List<Mot>();
        [DataMember(Order = 3)]

        /** List contenant des objets Mot jouer */
        public List<Mot> MotsJouer { get; set; } = new List<Mot>();

        [DataMember(Order = 1)]

        public ObservableCollection<Joueur> Joueurs { get; set; }
        /** List contenant des objets Joueur */

        [DataMember]
        public List<Joueur> joueurs { get; set;} =new List<Joueur>();

        [DataMember(Order = 7)]
        public int IndiceR { get; set; } = 0;

        [DataMember(Order = 6)]
        public List<string> Images { get; set; } =new List<string>() {"cat.png", "dog.png", "pig.png", "bunny.png", "fish.png", "horse.png" };

        /**
         * @brief Création de partie
         * @param List des objets Mot non jouer
         */
        [DataMember(Order = 8)]
        public ISerializer? Serializer { get; set; }

        [DataMember(Order = 5)]
        public uint Page {  get; set; }


        public Partie(List<Mot> motsPasJouer)
        {
            MotsPasJouer = motsPasJouer;

        }

        public Partie(ISerializer serializer) 
        {
            MotsPasJouer = new List<Mot>() {
            new Mot("Fraise", "Framboise"),
            new Mot("Chien", "Chat"),
            new Mot("Voiture", "Moto"),
            new Mot("Vanille", "Chocolat"),
            new Mot("Fille", "Garçon"),
            new Mot("Maison", "Appartement"),
            
            };
            this.Serializer = serializer;
        }
        public Partie()
        {
            MotsPasJouer = new List<Mot>() {
            new Mot("Fraise", "Framboise"),
            new Mot("Chien", "Chat"),
            new Mot("Voiture", "Moto"),
            new Mot("Vanille", "Chocolat"),
            new Mot("Fille", "Garçon"),
            new Mot("Maison", "Appartement"),

            };
            
        }

        public void ValiderNbJoueurs()
        {
            for (int i = 0; i < Parametres.NbJoueurs; i++)
                joueurs.Add(new Joueur("Joueur " + (i + 1), Images[i], Images));
            Joueurs = new ObservableCollection<Joueur>(joueurs);
        }

        /**
         * @brief Remplit la liste des objets Joueur avec de nouveaux objets Joueur
         */
        public void ChoisirNbJoueur()
        {

            OnPickingNumberPlayeur(Parametres, "Joueurs"); ///< Événement qui permet de choisir le nombre de joueurs
            for (int i = 0; i < Parametres.NbJoueurs; i++)
                joueurs.Add(new Joueur("Joueur " + (i + 1), Images[i], Images));
        }

        /**
         * @brief Permet de choisir le nombre d'Undercover à l'aide d'un événement OnPickingNumberPlayeur
         */
        public void ChoisirNbUnder()
        {
            OnPickingNumberPlayeur(Parametres, "Under");
        }

        /**
         * @brief Permet de choisir le nombre de Mr. White à l'aide d'un événement OnPickingNumberPlayeur
         */
        public void ChoisirNbWhite()
        {
            OnPickingNumberPlayeur(Parametres, "White");
        }

        /**
         * @brief Permet de gérer les paramètres et de faire des choix pour le nombre de joueurs, d'Undercover, de Mr. White et de rounds
         */
        public void ChoisirParametres() 
        {
            ChoisirNbJoueur();
            ChoisirNbUnder();
            ChoisirNbWhite();
            ChoisirNbRounds();
        }

        /**
         * @brief Permet de choisir le nombre de rounds à l'aide d'un événement OnPickingNumberRound
         */
        public void ChoisirNbRounds()
        {
            OnPickingNumberRound(Parametres);

        }

        /**
         * @brief Choix de nom pour le joueur à l'aide d'un événement OnPickingName
         * @param L'objet 'j' est une instance de la classe Joueur, l'utilisateur qui voudra choisir un nom
         */
        public void ChoisirNom(Joueur j)
        {
            OnPickingName(j, joueurs);
            
        }

        /**
         * @brief Choix de nom pour tous les joueurs
         */
        public void ChoisirNomAll()
        {
            foreach(Joueur j in  joueurs)
            {
                ChoisirNom(j);
            }
            //Serializer.Write(this);
            
        }

        /**
         * @brief Créer un objet 'r' de la classe Round, ajouter des éléments dans les listes MotsJouer et MotsPasJouer, abonnement de 'r' aux événements PickingCase, PlayerOut, PlayerVoting, RestartVote, ShowingBoard, PlayerSpeaking
         * @return L'objet 'r' est une instance de la classe Round, il sera utilisé pour pouvoir jouer
         */
        public Round CreerRound()
        {
            var ra = new Random();
            var rand = ra.Next(0, MotsPasJouer.Count()-1);
            
            
            Round r = new(MotsPasJouer[rand], joueurs ,Parametres, Serializer);

            MotsJouer.Add(MotsPasJouer[rand]);
            MotsPasJouer.Remove(MotsPasJouer[rand]);

            r.PickingCase += PrivPickingCase;
            r.PlayeurOut += PrivPlayeurOut;
            r.PlayeurVoting += PrivPlayeurVoting;
            r.RestartVote += PrivRestartVote;
            r.ShowingBoard += PrivShowingBoard;
            r.PlayeurSpeaking += PrivPlayeurSpeaking;
            Rounds.Add(r);
            return r;

        }

        /**
         * @brief Permet de jouer un round
         * @param L'objet 'r' est une instance de la classe Round, le round qui va être joué
         */
        public void JouerRound(Round r)
        {
            r.ChoisirCaseAll();///< Attribution de personnage à un joueur
            r.ChangerOrdreDeJeu();///< Mélange l'ordre de passage pour les joueurs
            r.JouerAllTour();///< Joue tous les tours (parler, voter)
            //Serializer.Write("rounds", r);
        }

        public void ChargerPartie()
        {
            Console.WriteLine("Voulez vous charger la dernière partie ?");
            string s =Console.ReadLine();

            if(s=="y")
            {
                
            }


        }

        /**
         * @brief Permet de jouer partie
         */
        public void JouerPartie()
        {
            ChoisirParametres();///< Choix du nombre de personnages et de rounds
            ChoisirNomAll();///< Choix des noms des personnages.

            for(uint i = 0; i < Parametres.NbRounds; i++)
            {
                JouerRound(CreerRound());
            }

        }

    }
}
