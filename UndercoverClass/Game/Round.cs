using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Board;
using UndercoverClass.Rules;
using UndercoverClass.Events;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Serialization;
using UndercoverClass.Persistance;

/**
 * @file Round.cs
 * @brief Définition de la classe Round qui gère le déroulement d'un round
 */
namespace UndercoverClass.Game
{
    [DataContract]
    [KnownType(typeof(Civil))]
    [KnownType(typeof(Under))]
    [KnownType(typeof(White))]
    public class Round: IEquatable<Round>
    {
        /** Déclaration d'un événement qui permet de choisir la case */
        public event EventHandler<PickingCaseEventArgs> PickingCase;

        /** Vérification d'un événement qui permet de choisir la case */
        protected virtual void OnPickingCase(IRole j, List<Case> b, Mot m, Case c)
        {
            PickingCase?.Invoke(this, new PickingCaseEventArgs(j, b, m, c));
        }

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
        /** Déclaration d'un événement qui permet de afficher la plateau */
        public event EventHandler<ShowingBoardEventArgs> ShowingBoard;

        /** Vérifie d'un événement qui permet de afficher la plateau */
        protected virtual void OnShowingBoard(List<Case> board)
            => ShowingBoard?.Invoke(this, new ShowingBoardEventArgs(board));

        public ISerializer serializer;

        /** Déclaration d'un événement PrivRestartVote*/
        private event EventHandler<RestartVoteEventArgs> PrivRestartVote;

        [DataMember]
        /** increment i pour incrementer les list Tours*/
        public int IndiceI { get; set; } = 0;
        [DataMember]
        /** Déclaration d'objet Mot */
        public Mot Mott {  get; private set; }

        [DataMember]
        /** Déclaration d'objet Plateau */
        public Plateau Plateau {  get; private set; }

        [DataMember]
        /** List contenant des objets IRole, des joueurs morts, avec leur role */
        public List<IRole> JoueursVivant { get; private set; } = new List<IRole>();

        [DataMember]
        /** List contenant des objets IRole, des joueurs vivants, avec leur role */
        public List<IRole> JoueursMort {  get; private set; } = new List<IRole>();

        [DataMember]
        /** List contenant des objets Tour */
        public List<Tour> Tours { get; private set; } = new List<Tour> { };

        /**
         * @brief Création de Round, attributions des roles a des joueurs, creation de plateau
         * @param mot de l'instance Mot
         * @param List des joueurs de l'instance Joueur
         * @param p de l'instance Parametres
         */
        public Round(Mot mot, List<Joueur> Joueurs, Parametres p)
        {
            this.Mott = mot;

            foreach(Joueur j in Joueurs)
            {
               IRole r = new Civil(j);
               this.JoueursVivant.Add(r);
            }
            this.Plateau = new Plateau(p.NbCivil, p.NbUnder, p.NbWhite, p.NbJoueurs, Mott);
        }

        public Round(Mot mot, List<Joueur> Joueurs, Parametres p, ISerializer s)
        {
            this.Mott = mot;

            foreach (Joueur j in Joueurs)
            {
                IRole r = new Civil(j);
                this.JoueursVivant.Add(r);
            }
            this.Plateau = new Plateau(p.NbCivil, p.NbUnder, p.NbWhite, p.NbJoueurs, Mott);
            this.serializer = s;
        }

        /**
         * @brief Choix de case
         * @param j de l'instance IRole
         * @return joueur avec role specifique, ou un joueur simple
         */
        public IRole ChoisirCase(IRole j, Case Casec)
        {
            OnPickingCase(j, this.Plateau.board, this.Mott, Casec);///< choix de case par joueur
            
            if (j.ChangementRole == "Under")
            {
                return new Under(j.Joueur);
            }
            else if (j.ChangementRole == "White")
            {
                return new White(j.Joueur);
            }
            else
                return j;

            
        }

        /**
         * @brief Choix de tout les cases
         */
        public void ChoisirCaseAll()
        {

            for (int i = 0; i < JoueursVivant.Count; i++)
            {
                OnShowingBoard(this.Plateau.board);///< affiche sur le plateau

                JoueursVivant[i]=ChoisirCase(JoueursVivant[i], new Case(0,0));
 
            }
        }
        /**
         * @brief Un tour est crée avec tous les joueurs vivant et le tour est placé dans une liste
         * @brief Créer un objet 't' de la classe Tour
         * @brief abonnement de 't' aux événements PickingCase, PlayerOut, PlayerVoting, RestartVote, ShowingBoard, PlayerSpeaking
         * @return t de l'instance Tour
         */
        public Tour CreerTour()
        {
            Tour t = new Tour(JoueursVivant, this.Plateau);
            Tours.Add(t);
            t.PlayeurVoting += PrivPlayeurVoting;
            t.PlayeurSpeaking += PrivPlayeurSpeaking;
            t.RestartVote += PrivRestartVote;
            t.PlayeurOut += PrivPlayeurOut;

            return t;
        }

        /**
         * @breif permet de jouer un tourTour, parler et voter
         * @param tour objet de class Tour, ce la tour qu'il va être jouer
         * @return true si un group de personages ou un personage ont/a gagner, false sinon et jeu continue
         */
        public bool JouerTour(Tour tour)
        {

            tour.DireMotAll();
            OnShowingBoard(this.Plateau.board);
            tour.VoterAll();
            var v = tour.CompterVote();
            tour.FinDeTour(v, JoueursVivant,JoueursMort);
            return this.VerifGagner();
            
        }

        /**
         * @brief permet de jouer tout les tourTours
         */
        public void JouerAllTour()
        {
            bool b=false;
            while(b==false)
            {
                b=JouerTour(CreerTour());

            }

        }

        /**
         * @brief comparaison des mots
         * @param other objet de type Mot
         * @return true si les objets sont égaux false sinon
         */
        public bool Equals([AllowNull] Round other)
        {
            return Mott.Equals(other.Mott);
        }

        /**
         * @brief comparaison des mots
         * @param obj objet de type Mot
         * @return true si les objets sont égaux false sinon
         */
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Round);
        }

        /**
         * @brief Génère un code de hachage basé sur le mot
         * @return représentation de code de hachage du mot
         */
        public override int GetHashCode()
        {
            return Tours.GetHashCode();
        }
    }
}
