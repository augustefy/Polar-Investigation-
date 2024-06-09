using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Game;

/**
 * @file IRole.cs
 * @brief Définition de la interface IRole qui gère les roles des perssonages
 */
namespace UndercoverClass.Rules
{
    
    public interface IRole
    {
        /** L'attribut Gagner, true si les/le perssonage.s a/ont gagner, false sinon */
        bool Gagner { get;  set; }
        /** L'attribut Mort, true si le perssonage est mort, false sinon*/
        bool Mort {  get; set; }
        /** L'attribut Role, qui contien role du perssonage et donne des capacites spécifique */
        string Role { get; set; }
        /** Déclaration d'objet Joueur */
        Joueur Joueur { get; set; }
        /** L'attribut ChangementRole, change de role*/
        public string? ChangementRole { get; set; }



    }
}
