using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Rules;

/**
 * @file Mot.cs
 * @brief Définition de la classe Mot qui contient les mots pour les personnages du jeu
 */
namespace UndercoverClass.Game
{
    [DataContract]
    public class Mot
    {
        [DataMember]
        /** L'attribut MotC mot de personnage civilian */
        public string MotC { get;  set; }
        [DataMember]
        /** L'attribut MotU mot de personnage undercover */
        public string MotU { get;  set; }
        [DataMember]
        /** L'attribut MotW mot de personnage Mr.white*/
        public string MotW { get; set; }

        /**
         * @brief construction de Mot
         * @param motC mot de personnage civilian
         * @param motU mot de personnage undercover
         */
        public Mot(string motC, string motU) 
        {
            if (motC == null)
                motC = "Rouge";
            if (motU == null)
                motU = "Rose";
            this.MotC = motC;
            this.MotU = motU;
            this.MotW = "Vous êtes Mr.White";
        }


    }
}
