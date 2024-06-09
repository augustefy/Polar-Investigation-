using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Game;

/**
 * @file Civil.cs
 * @brief Définition de la classe Civil qui gère le perssonage le civilian
 */
namespace UndercoverClass.Rules
{
    [DataContract]
    public class Civil : IRole
    {
        [DataMember]
        /** L'attribut Gagner, true si les/le civilian.s a/ont gagner, false sinon */
        public bool Gagner { get; set; }
        [DataMember]
        /** L'attribut Role, qui contien role de civilians et donne des capacites spécifique */
        public string Role { get; set; }
        [DataMember]
        /** Déclaration d'objet Joueur */
        public Joueur Joueur{ get ; set ; }
        [DataMember]
        /** L'attribut Mort, true si le civilian est mort, false sinon*/
        public bool Mort { get; set; }
        [DataMember]
        /** L'attribut ChangementRole, change de role*/
        public string? ChangementRole { get; set; }

        /**
         * @brief Création de civil, et attribution a un joueur
         * @param j de l'instance Joueur
         */
        public Civil(Joueur j)
        {
            this.Gagner = false;
            this.Mort = false;
            this.Role = "Civil";
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
