using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UndercoverClass.Events;
using UndercoverClass.Game;
using UndercoverClass.Rules;

/**
 * @file Plateau.cs
 * @brief Définition de la classe Plateau qui gère la surface où le jeu se déroulera
 */
namespace UndercoverClass.Board
{
    [DataContract]
    public class Plateau
    {
        [DataMember]
        /** Déclaration d'objet Mot */
        public Mot Mot { get; set; }


        [DataMember]
        public ObservableCollection<Case> Board { get; private set; }
        /** Liste contenant les cases avec leur position */
        public List<Case> board { get; set; } = new List<Case>();

        /**
         * @brief Création de plateau en plaçant les cartes dessus et en attribuant les mots
         * @param nbCivil nombre de personnage civiliens
         * @param nbUnder nombre de personnage undercover
         * @param nbWhite nombre de personnage Mr. white
         * @param nbJ nombre des joueurs
         * @param mot Objet 'mot' qui contient des mots qui seront attribués à des joueurs
         */
        public Plateau(int nbCivil, int nbUnder, int nbWhite, int nbJ, Mot mot)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < nbJ; i++)
            {

                if (y % 7 == 0 && y != 0)
                {
                    x += 1;
                    y = 0;
                }
                Case c = new Case(x, y);
                c.ImageSource = "undercoverlogo.png";
                c.Text = "Click!";
                board.Add(c);

                y += 1;
            }
            if (mot == null)
            { 
                mot = new Mot("Pain au chocolat", "Croissant");
                
            }
            Board = new ObservableCollection<Case>(board);
            this.Mot = mot;
            this.AttribuerMotCase(nbCivil, nbUnder, nbWhite, nbJ, mot);
            

        }
    }
}

    

