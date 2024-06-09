using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UndercoverClass.Board;
using UndercoverClass.Events;
using UndercoverClass.Game;
using UndercoverClass.Rules;

namespace UndercoverClass
{
    public class DisplayConsole
    {
        public void AfficherPlateau(object sender, ShowingBoardEventArgs args)
        {
            Console.WriteLine();


            for (int i = 0; i < args.Board.Count; i++) 
            {
                Console.Write(args.Board[i]);
                if(i ==7)
                    Console.WriteLine();
            }
            Console.WriteLine();
     
        }

      

        public bool IsCaseValide(List<Case> cases, int pos)
        {
            if (pos < 0 || pos >= (cases.Count) || cases[pos]== null || cases[pos].Joueur != null )
            {
                Console.WriteLine("\n Case est invalide, recommencez \n");
                return false;
                
            }
            return true;
        }

        public bool IsCaseValide2(List<Case> cases, int pos)
        {
            if (pos < 0 || pos >= (cases.Count) || cases[pos] == null|| cases[pos].Joueur.Mort == true)
            {
                Console.WriteLine("\n Case est invalide, recommencez \n");
                return false;

            }
            return true;
        }



        public int InputValue()
        {
            string? xS;
            xS = Console.ReadLine();

            while (!Regex.IsMatch(xS, "^\\d+$") || xS == null)
            {
                Console.WriteLine("il faut un chiffre \n");
                xS = Console.ReadLine();
            }

            return Convert.ToInt32(xS) - 1;
        }

        public void JoueurChoisirCarte(object sender, PickingCaseEventArgs args)
        {
            int pos = -1;
            bool g=false;

            Console.WriteLine($"\n{args.Playeur.Joueur.Name}, à vous de choisir votre carte !\n");

            while (!g)
            {
                Console.WriteLine("\nPour choisir votre carte, donnez le chiffre qui correspond à la position de la carte \n");
                Console.Write($"Donc de 1 à {args.Board.Count()} :  ");
                pos = InputValue();
                g = IsCaseValide(args.Board, pos);

            }

            if (args.Board[pos].Mot == args.Mot.MotU)
            {
                args.Playeur.ChangementRole = "Under";

                args.Board[pos].Joueur = new Under(args.Playeur.Joueur);

            }
            else if (args.Board[pos].Mot == args.Mot.MotW)
            {

                args.Board[pos].Joueur = new White(args.Playeur.Joueur);
                args.Playeur.ChangementRole = "White";
                    
            }
            else
                args.Board[pos].Joueur = args.Playeur;


            Console.WriteLine("\n---------------------------------------------------------------");
            Console.WriteLine("|                                                              |");
            Console.WriteLine($"              {args.Board[pos].Mot}");
            Console.WriteLine("|                                                              |");
            Console.WriteLine("----------------------------------------------------------------\n");
            args.Board[pos].ChangeFace();


            string? p = Console.ReadLine();

            if (p == null || p != null)
                Console.Clear();

            

        }
        public void JoueurParler(object sender, PlayeurSpeakingEventArgs args)
        {
            Console.WriteLine($"{args.Role.Joueur.Name}, à vous de parler ");
            string? s = Console.ReadLine();
        }

        public void JoueurVoter(object sender, PlayeurVotingEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine($"{args.Playeur.Joueur.Name}, choisissez le joueur que vous voulez éliminer !");
            Vote voter = new Vote();
            bool g = false;
            int pos = -1;

            
            while (voter.JoueurVote == null)
            {
                while (!g)
                {

                    Console.WriteLine("\nPour choisir votre carte, donnez le chiffre qui correspond à la position de la carte \n");
                    Console.Write($"Donc de 1 à {args.Plateau.Board.Count()} : ");
                    pos = InputValue();
                    
                    g = IsCaseValide2(args.Plateau.board, pos);

                }
                    if (args.Playeur.Joueur == args.Plateau.Board[pos].Joueur.Joueur)
                    {
                        bool res = false;
                        Console.WriteLine("Vous avez voté pour vous-même, êtes-vous sur ?");
                        while (res == false)
                        {

                            string? s = Console.ReadLine();


                            if (Regex.IsMatch(s, "Non|non|no|No|n|N"))
                            {
                                Console.WriteLine("Choisissez un autre joueur :");
                                g = false;
                                res = true;
                            }
                            else if (Regex.IsMatch(s, "Oui|oui|yes|Yes|o|O|y|Y"))
                            {
                                voter.AddJoueur(args.Plateau.Board[pos].Joueur);
                                res = true;
                            }

                            else
                            {
                                Console.WriteLine("C'est pas une réponse ça, donc recommencez\n");
                                 g = false;
                                res = true;
                            }
                        }
                    }

                    else
                    {
                        voter.AddJoueur(args.Plateau.Board[pos].Joueur);
                    }
            }

            Console.WriteLine("\n\n");
            
            args.Votes.Add(voter);
            
        }

        public void DevinerMot(object sender, GuessingWordEventArgs args)
        {
            Console.WriteLine(args.Playeur.Joueur.Name + " Vous êtes (un) Mr.White !\n Vous avez encore une chance de vous en sortir !"); ;
            Console.WriteLine("Essayez de deviner le mot des Civils pour gagner la partie ! :");
            string res = Console.ReadLine();
            if (Regex.IsMatch(res, args.word) || Regex.IsMatch(res, args.word.ToLower()))
            {
                Console.WriteLine("\nBravo ! Vous avez gagné !");
                args.Playeur.Gagner=true;
            }
            else 
            {
                Console.WriteLine("\nAh dommage, ce n'est pas le bon mot !");
                args.Playeur.Gagner = false;
            }
        }

        public void RoleGagne(object sender, RoleWonEventArgs args)
        {
            Console.Clear();
            Console.WriteLine($"Les {args.Role} ont gagnés ! \n");
            foreach(var j in args.Joueurs)
                Console.Write(j + "\t");
            Console.WriteLine();
        }

        public void ChoisirNomJoueur(object sender, PickingNameEventArgs args) 
        {
            Console.Clear();
            Console.WriteLine("Écrivez votre nom : ");
            string nom = Console.ReadLine();
            Joueur t = new Joueur(nom);
            while(args.Joueurs.Contains(t))
            {
                Console.WriteLine("Un autre joueur à le même nom, changez le : ");
                nom = Console.ReadLine();
                t = new Joueur(nom);
            }
            if (nom=="" || nom=="\n" || nom == "\t" || nom == "\\s")
                return;
            args.Playeur.Name = nom;
            
            
        }

        public void ChoisirNombreJoueurs(object sender, PickingNumberPlayeurEventArgs args)
        {
            Console.WriteLine($"Choisissez le nombre de {args.Type} à l'aide des flèches haut et bas: ");
            Console.WriteLine("Validez ensuite avec entrée\n");
            Console.WriteLine("Nombre de Joueurs = " + args.Parametres.NbJoueurs + "\n Nombre de Civil = " + args.Parametres.NbCivil + "\n Nombre d'Under = " + args.Parametres.NbUnder + "\n Nombre de White = " + args.Parametres.NbWhite + "\n");
            var p = Console.ReadKey().Key;

            while (p != ConsoleKey.Enter) 
            {
            
                if (p == ConsoleKey.UpArrow)
                {
                    args.Parametres.Ajouter(1, args.Type);
                    Console.Clear();
                    Console.WriteLine($"Choisissez le nombre de {args.Type} à l'aide des flèches haut et bas: ");
                    Console.WriteLine("Validez ensuite avec entrée\n");
                    Console.WriteLine("Nombre de Joueurs = " + args.Parametres.NbJoueurs + "\n Nombre de Civil = " + args.Parametres.NbCivil + "\n Nombre d'Under = " + args.Parametres.NbUnder + "\n Nombre de White = " + args.Parametres.NbWhite + "\n");

                }

                else if(p == ConsoleKey.DownArrow)
                {
                    args.Parametres.Ajouter(-1, args.Type);
                    Console.Clear();
                    Console.WriteLine($"Choisissez le nombre de {args.Type} à l'aide des flèches haut et bas: ");
                    Console.WriteLine("Validez ensuite avec entrée\n");
                    Console.WriteLine("Nombre de Joueurs = " + args.Parametres.NbJoueurs + "\n Nombre de Civil = " + args.Parametres.NbCivil + "\n Nombre d'Under = " + args.Parametres.NbUnder + "\n Nombre de White = " + args.Parametres.NbWhite + "\n");

                }
                p = Console.ReadKey().Key;


            }
            Console.Clear();

        }


        public void ChoisirNombreRound(object sender, PickingNumberRoundEventArgs args)
        {
            Console.WriteLine($"Choisissez le nombre de Rounds à l'aide des flèches haut et bas: ");
            Console.WriteLine("Validez ensuite avec entrée \n");
            Console.WriteLine("Nombre de Rounds = " + args.Parametres.NbRounds + "\n");
            var p = Console.ReadKey().Key;

            while (p != ConsoleKey.Enter)
            {
                if (p == ConsoleKey.UpArrow)
                {

                    Console.Clear();
                    args.Parametres.NbRounds = 1;
                    Console.WriteLine("Nombre de Rounds = " + args.Parametres.NbRounds + "\n");

                }

                else if (p == ConsoleKey.DownArrow)
                {

                    Console.Clear();
                    args.Parametres.NbRounds = -1;
                    Console.WriteLine("Nombre de Rounds = " + args.Parametres.NbRounds + "\n");

                }
                p = Console.ReadKey().Key;
            }
            Console.Clear();

        }



        public void JoueurEliminer(object sender, PlayeurOutEventArgs args)
        {
            Console.Clear();
            Console.WriteLine($"\n{args.Playeur.Joueur.Name}, vous avez été éliminé ! \n");
        }
        public void MauvaiseValeurNombres(object sender, ValueClickedBadEventArgs args)
        {
            Console.WriteLine($"Vous ne pouvez plus {args.Valeur} le nombre ");
        } 
    }
}
