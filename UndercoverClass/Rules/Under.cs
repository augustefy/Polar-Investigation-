using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Game;

/**
 * @file Under.cs
 * @brief Définition de la classe Under qui gère le perssonage de Undercover
 */
namespace UndercoverClass.Rules
{
    [DataContract]
    public class Under : IRole
    {
        [DataMember]
        /** L'attribut Gagner, true si les/la Undercover.s a/ont gagner, false sinon */
        public bool Gagner { get ; set; }
        [DataMember]
        /** L'attribut Role, qui contien role du Undercover et donne des capacites spécifique */
        public string Role { get; set; }
        [DataMember]
        /** Déclaration d'objet Joueur */
        public Joueur Joueur{ get; set ; }
        [DataMember]
        /** L'attribut ChangementRole, change de role*/
        public string? ChangementRole { get; set; }
        [DataMember]
        /** L'attribut Mort, true si la Undercover est mort, false sinon*/
        public bool Mort { get; set; }

        /**
         * @brief Création de Under, et attribution a un joueur
         * @param j de l'instance Joueur
         */
        public Under(Joueur j)
        {
            this.Gagner = false;
            this.Mort= false;
            this.Role = "Under";
            this.Joueur = j;
        }

        /**
         * @brief permet l'affichage de rôle de joueur
         * @return chîne de caratéres
         */
        public override string ToString()
        {
            return this.Joueur.Name + " = " +this.Role;
        }

      

   
      
    }
}
