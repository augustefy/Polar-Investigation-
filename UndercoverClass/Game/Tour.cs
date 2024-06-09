using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using UndercoverClass.Board;
using UndercoverClass.Events;
using UndercoverClass.Rules;

/**
 * @file Tour.cs
 * @brief Définition de la classe Tour qui gère le déroulement d'un tour
 */
namespace UndercoverClass.Game
{
    [DataContract]
    public class Tour
    {
        /** Déclaration d'un événement qui permet de virer un joueur */
        public event EventHandler<PlayeurOutEventArgs>? PlayeurOut;

        /** Vérifier un événement qui permet de virer un joueur */
        public virtual void OnPlayeurOut(IRole role) 
            => PlayeurOut?.Invoke(this, new PlayeurOutEventArgs(role));

        /** Déclaration d'un événement qui permet un joueur de voter */
        public event EventHandler<PlayeurVotingEventArgs>? PlayeurVoting;

        /** Vérifie un événement qui permet un joueur de voter */
        public virtual void OnPlayeurvoting(IRole j, List<Vote> votes, Plateau plateau, Case Casec)
        {
            PlayeurVoting?.Invoke(this, new PlayeurVotingEventArgs(j, votes, plateau, Casec));   
        }

        /** Déclaration d'un événement qui permet un joueur de parler */
        public event EventHandler<PlayeurSpeakingEventArgs>? PlayeurSpeaking;

        /** Vérifie un événement qui permet un joueur de parler */
        public virtual void OnPlayeurSpeaking(IRole j)
            => PlayeurSpeaking?.Invoke(this,new PlayeurSpeakingEventArgs(j));

        /** Déclaration d'un événement qui permet remetre a zéro les résoultats de vote */
        public event EventHandler<RestartVoteEventArgs>? RestartVote;

        /** Vérifie d'un événement qui permet remetre a zéro les résoultats de vote */
        public virtual void OnRestartVote()
            => RestartVote?.Invoke(this, new RestartVoteEventArgs());

        /** List contenant des Roles */
        [DataMember]
        public List<IRole> JoueursList { get; set; }

        [DataMember]
        /** List contenant des votes de l'instance Vote */
        public List<Vote> VoteList { get; set; } = new List<Vote>();

        [DataMember]
        /** Déclaration de l'objet Plateau */
        public Plateau Plateau { get;  set; }

        [DataMember]
        /** Dictionaire contenant des votes de l'instance Vote et des nombres des fois était voté */
        public Dictionary<Vote, int> VoteDict { get; private set; } = new Dictionary<Vote, int>();

        /**
         * @brief Creation de tour
         * @param List des joueurs de l'instance IRole, des utilisateurs qui participant
         * @param plateau objet de class Plateau, sur qoui jeu va se dérouler
         */
        public Tour(List<IRole> joueurs, Plateau plateau)  
        { 
            this.JoueursList = joueurs; 
            this.Plateau = plateau;
        }

        /**
         * @brief Laisse un joueur de temps pour parler
         */
        public void DireMotAll()
        {
            foreach(IRole j in JoueursList)
            {
                OnPlayeurSpeaking(j);///< événment qui laisse joueur de parler
            }
        }

        
        /**
         * @brief Un joueur vote pour un autre joueur et retourne une instance de vote(le joueur qui a été voté)
         * @param j de l'instance IRole, va permetre à joueur de utiliser ses capaciter
         */
        public void Voter(IRole j, Case Casec)
        {
            
            OnPlayeurvoting(j, VoteList, Plateau, Casec);///< événment qui permet de voter
        }

        /**Tous les joueurs votent et chaque joueurs votés sont insérer dans le dictionnaire avec comme valeur le nombre de fois qu'il a été voté*/


        public void TransformDic()
        {
            foreach (Vote v in VoteList)
            {
                if (v.GetHashCode() == 0)
                    continue;
                if (VoteDict.ContainsKey(v))
                {
                    VoteDict[v] += 1;
                }
                else
                {
                    VoteDict.Add(v, 1);
                }
            } 
            VoteList=new List<Vote>();
        }

        /**
         * @brief permet de voter à tout le monde 
         * @brief vérifier qu'on ne peut pas voter un joueur déjà mort
         */
        public void VoterAll()
        {
            foreach (IRole v in JoueursList)
            {
                Voter(v, new Case(0,0));
            }

            TransformDic();
        }

        /**
         * @brief Compte nombre des voix
         * @return joueur qui a eu plus de votes, donc il est eliminer
         */
        public Vote CompterVote()
        { 
            int max = VoteDict.Values.Max();
            var joueursOut = VoteDict.Where(item => item.Value == max).ToList();
            int rand = 0;

            if(joueursOut.Count > 1) 
            {
                Random r = new Random();
                rand = r.Next(0, joueursOut.Count());


            }
            OnPlayeurOut(joueursOut[rand].Key.JoueurVote);///< evenment qui permet devirer un joueur
            return joueursOut[rand].Key;
        }

        /**
         * @brief Verifie la fin de tour
         * @param v l'instance de Vote
         * @param List des joueur vivants Joueurvivant
         * @param List des joueur vivants JoueurMort
         */
        public void FinDeTour(Vote v, List<IRole> Joueurvivant, List<IRole> JoueurMort)
        {
            
            JoueurMort.Add(v.JoueurVote);
            var item = Joueurvivant.FirstOrDefault(item => item.Joueur == v.JoueurVote.Joueur);
            if (item != null)
            {
                Joueurvivant.Remove(item);
            }
            else
                Joueurvivant.Remove(v.JoueurVote);
            
            JoueurMort.Last().Mort=true;
            
        }

       
    }
}
