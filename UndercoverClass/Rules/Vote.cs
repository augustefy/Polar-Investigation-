using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Game;

/**
 * @file Vote.cs
 * @brief Définition de la class Vote qui gère les votes des perssonages
 */
namespace UndercoverClass.Rules
{
    [DataContract]
    public class Vote: IEquatable<Vote>
    {
        [DataMember]
        /** L'attribut JoueurVote de l'instance Irole */
        public IRole? JoueurVote { get;   set; }

        /**
         * @brief Création d'objet vote
         */
        public Vote() { }
        /**
         * @brief Création d'objet vote
         * @param joueur de l'instance IRole
         */
        public Vote(IRole joueur) =>  this.JoueurVote = joueur;

        /**
         * @brief àjout joueur
         * @param joueur de l'instance IRole
         */
        public void AddJoueur(IRole joueur) => this.JoueurVote = joueur;

        /**
         * @brief comparaison des noms des JoueurVote
         * @param other objet de type vote
         * @return true si les noms sont égaux false sinon
         */
        public bool Equals([AllowNull] Vote other)
        {
            if(JoueurVote==null || other==null || other.JoueurVote == null) 
                return false;
            
            else if(JoueurVote.Joueur == null || other.JoueurVote.Joueur == null)
                return JoueurVote.Equals(other?.JoueurVote);

            else if (JoueurVote.Joueur.Name==null || other.JoueurVote.Joueur.Name==null)
                return JoueurVote.Joueur.Equals(other?.JoueurVote.Joueur);

            
            return JoueurVote.Joueur.Name.Equals(other?.JoueurVote.Joueur.Name); 
        }

        /**
         * @brief comparaison des noms des JoueurVote
         * @param obj objet de type vote
         * @return true si les noms sont égaux false sinon
         */
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Vote);
        }

        /**
         * @brief Génère un code de hachage basé sur le nom de JoueurVote
         * @return représentation de code de hachage du nom de JoueurVote
         */
        public override int GetHashCode()
        {
            if(JoueurVote==null)
                return 0;
            return JoueurVote.Joueur.GetHashCode();
        }

      

    }


}
