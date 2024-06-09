using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UndercoverClass.Board;
using UndercoverClass.Events;
using UndercoverClass.Game;

/**
 * @file Vote.cs
 * @brief Définition de la class Vote qui gère les votes des perssonages
 */
namespace UndercoverClass.Rules
{

    public static class Regles
    {
        /** Déclaration d'un événement qui permet de fair devinette */
        public static event EventHandler<GuessingWordEventArgs>? GuessingWord;

        /** Vérifie d'un événement qui permet de fair devinette */
        public static void OnGuessingWord(string word, IRole role)
            => GuessingWord?.Invoke(typeof(Regles),new GuessingWordEventArgs(word, role));

        /** Déclaration d'un événement qui permet de fair gagner */
        public static event EventHandler<RoleWonEventArgs>? RoleWon;

        /** Vérification d'un événement qui permet de fair gagner */
        public static void OnRolewon(string role, List<IRole> g)
            => RoleWon?.Invoke(typeof(Regles), new RoleWonEventArgs(role, g));

        
        /**
         * @brief attribut les mots a des cases
         * @param plateau plateau sur la quel jeu va se dérouler
         * @param nbCivil nombre des civilians
         * @param nbUnder nombre des undercovers
         * @param nbWhite nombre des Mr. whites
         * @param nbJ nombre des joueurs
         * @param mot mot qui va etre jouer
         */
        public static void AttribuerMotCase(this Plateau plateau, int nbCivil, int nbUnder, int nbWhite, int nbJ, Mot mot)
        {

            var rd = new Random();
            int rand = rd.Next(1, nbJ + 1);
            List<int> list = new List<int>();

            foreach (Case c in plateau.board)
            {
                if (c != null)
                {
                    while (list.Contains(rand))
                        rand = rd.Next(1, nbJ + 1);

                    list.Add(rand);

                    switch (rand)
                    {
                        case int n when n <= nbCivil:
                            c.Mot = mot.MotC;
                            break;

                        case int n when (n > nbCivil && n < (nbCivil + nbUnder + 1)):
                            c.Mot = mot.MotU;
                            break;

                        case int n when n > (nbCivil + nbUnder):
                            c.Mot = mot.MotW;
                            break;
                    }
                    rand = rd.Next(1, nbJ + 1);
                }
                else continue;
            }

        }

        /**
         * @brief change l'ordre des joueurs sur cases (Mr. white ne peut pas passer 1er)
         * @param round round la quelle va être commencer
         */
        public static void ChangerOrdreDeJeu(this Round round)
        {
            var rd = new Random();
            int rand = rd.Next(round.JoueursVivant.Count);
            List<int> list = new List<int>();
            List<IRole> rolePlaceHolder = new List<IRole>(round.JoueursVivant);

            foreach (IRole c in rolePlaceHolder)
            {

                while (list.Contains(rand))
                    rand = rd.Next(round.JoueursVivant.Count);

                list.Add(rand);

                if (c.Role == "White" && rand == 0)
                {
                    rand = rd.Next(round.JoueursVivant.Count);
                    while (list.Contains(rand))
                        rand = rd.Next(round.JoueursVivant.Count);
                    list.Add(rand);

                }

                
                round.JoueursVivant[rand] = c;

                rand = rd.Next(round.JoueursVivant.Count);

            }

        }

      
        public static void AllJoueurRoleGagne(List<IRole> j, string role) 
        {
            foreach (var item in j)
            {
                if (item.Role == role)
                    item.Gagner = true;
                
            }

        }

        /**
         * @brief Vérifie si un role a gagner
         * @param r round en cours de déroulement
         */
        public static bool VerifGagner(this Round r)
        {
            IRole dernier = r.JoueursMort.Last();
            ///< si Mr White gagne
            if (dernier.Role=="White")
            {
                
                OnGuessingWord(r.Mott.MotC, dernier);///< eventment qui se declanche quand mot a été deviner
                if(dernier.Gagner==true)
                {
                    AllJoueurRoleGagne(r.JoueursVivant, "White");
                    AllJoueurRoleGagne(r.JoueursMort, "White");

                    return true;
                }

                
            }

            ///< verif qu'est-ce qui se passe si where ne trouve rien
            List<IRole> listCivil = r.JoueursVivant.Where(item => item.Role=="Civil").ToList();
            List<IRole> listImp = r.JoueursVivant.Where(item => item.Role=="Under" || item.Role=="White").ToList();
            
            ///< si civilians gagne
            if(listImp==null || listImp.Count == 0)
            {
                
                AllJoueurRoleGagne(r.JoueursVivant, "Civil");
                AllJoueurRoleGagne(r.JoueursMort, "Civil");
                var AllCivil = r.JoueursMort.Where(item => item.Role == "Civil").Concat(listCivil).ToList();
                
                OnRolewon("Civils", AllCivil);
                return true;
                
            }

            ///< si Undercover gagne
            if (listCivil.Count == 1)
            { 
                foreach(var j in listImp)
                    j.Gagner = true;
           
                var AllImp = r.JoueursMort.Where(item => item.Role == "Under" || item.Role == "White").Concat(listImp).ToList();
                OnRolewon("Imposteur(s)", AllImp);
                return true;
                
            }

            ///< jeu continue
            return false;

        }

    }
    
}
