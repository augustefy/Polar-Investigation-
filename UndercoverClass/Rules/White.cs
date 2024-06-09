using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Game;

/**
 * @file White.cs
 * @brief Définition de la classe White qui gère le perssonage de Mr. white
 */
namespace UndercoverClass.Rules
{
    [DataContract]
    public class White : IRole

    {
        [DataMember]
        /** L'attribut Gagner, true si les/le Mr. white.s a/ont gagner, false sinon */
        public bool Gagner { get; set; }
        [DataMember]
        /** L'attribut Role, qui contien role de la Mr. white et donne des capacites spécifique */
        public string Role { get; set; }
        [DataMember]
        /** Déclaration d'objet Joueur */
        public Joueur Joueur { get ; set ; }
        [DataMember]
        /** L'attribut ChangementRole, change de role*/
        public string? ChangementRole { get; set; }
        [DataMember]
        /** L'attribut Mort, true si le Mr. white est mort, false sinon*/
        public bool Mort { get; set; }
        /**
         * @brief Création de White, et attribution a un joueur
         * @param j de l'instance Joueur
         */
        public White(Joueur j) 
        { 
            this.Gagner = false;
            this.Mort = false;
            this.Role = "White";
            this.Joueur = j;
        }


        /**
         * @brief permet l'affichage de rôle de joueur
         * @return chîne de caratéres
         */
        public override string ToString()
        {
            return this.Joueur.Name + " = " + this.Role;
        }

     

     
    }
}
