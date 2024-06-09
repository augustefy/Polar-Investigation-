using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Events;
using System.Runtime.Serialization;


/**
 * @file Parametres.cs
 * @brief Définition de La classe Paramètres qui gère les paramètres pour commencer la partie, tels que le nombre de joueurs, civils, undercover et Mr. White
 */
namespace UndercoverClass.Game
{
    [DataContract]
    public class Parametres : INotifyPropertyChanged
    {
        /** Déclaration de evenment ValueClickedBad, va permettre de capturer les différents boutons*/
        public event EventHandler<ValueClickedBadEventArgs> ValueClickedBad;

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /** @brief Vérifie que evenment ValueClickedBadEventArgs marche bien */
        protected virtual void OnValueClickedBad(string valeur)
            => ValueClickedBad?.Invoke(this, new ValueClickedBadEventArgs(valeur));

        /** L'attribut nbJoueurs nombre de joueurs participant au jeu */
        private int nbJoueurs;
        /**
         * @brief getteur et setteur de l'attribut nbJoueurs
         */

        

        [DataMember (Order = 0)]
        public int NbJoueurs
        {
            get
            {
                return nbJoueurs;
            }
            set
            {
                if (value + nbJoueurs > 20)
                {
                    OnPropertyChanged("NbJoueurs");
                   // OnValueClickedBad("augmenter");
                    return;
                }

                if(value + nbJoueurs < 3)
                {
                    OnPropertyChanged("NbJoueurs");
                    // OnValueClickedBad("réduire");
                    return;
                }

                nbJoueurs = nbJoueurs + value;
                nbCivil = (nbJoueurs / 2) + 1;
                float imposteur = nbJoueurs - nbCivil;
                nbWhite = (int)Math.Round(imposteur / 3);
                nbUnder = (int)imposteur - nbWhite;
                OnPropertyChanged("NbJoueurs");
                OnPropertyChanged("NbWhite");
                OnPropertyChanged("NbUnder");
                OnPropertyChanged("NbCivil");

            }

        }

        /** 
         * @brief Augmente ou diminue le nombre de personnages selon la valeur de la variable 'value'
         * @param value prend 1 ou -1
         * @param type prend "Joueurs" ou "Under" ou "White"
         */
        public bool Ajouter(int value, string type)
        {
            if (type == "Joueurs")
            {
                NbJoueurs = value;
                return true;
            }
            else if (type == "Under")
            {
                NbUnder = value;
                return true;
            }
            else if (type == "White")
            {
                NbWhite = value;
                return true;
            }
            else if (type == "Round")
            {
                NbRounds = value;
                return false;
            }

            else
                return false;
        }


        /** L'attribut nbCivil nombre de civilian participant au jeu */
        private int nbCivil;
        /**
         * @brief getteur de l'attribut nbCivil
         */
        [DataMember(Order = 1)]
        public int NbCivil
        {
            get
            {
                return nbCivil;
            }
            set { nbCivil = value;}
        }

        /** L'attribut nbUnder nombre de undercover participant au jeu */
        private int nbUnder;
        /**
         * @brief getteur et setteur de l'attribut nbUnder
         */
        [DataMember(Order = 2)]
        public int NbUnder
        {
            get
            { 
                
                return nbUnder;
               
            }
            set
            {
                int imposteur = nbUnder + nbWhite;
                if ((((imposteur == (nbJoueurs / 2)) && (value > 0)) || ((imposteur == 1)) && (value < 0)))
                {
                    
                    if ((nbUnder == 0) && (nbJoueurs == 3) && (nbWhite == 1) && (value > 0))
                    {
                        nbWhite = nbWhite - value;
                        nbUnder = nbUnder + value;
                        OnPropertyChanged("NbUnder");
                        OnPropertyChanged("NbWhite");

                    }

                    if ((nbUnder == 1) && (value < 0))
                    {
                        nbUnder = 0; 
                        nbWhite = nbWhite - value;
                        OnPropertyChanged("NbUnder");
                        OnPropertyChanged("NbWhite");

                    }

                    return;
                }
                else if (((nbUnder >= (((float)nbJoueurs / 2) - 1.0)) && (value > 0)) || ((nbUnder == 0) && (value < 0)))
                {
                   
                    return;
                }
                nbUnder = nbUnder + value;
                nbCivil = nbCivil - value;
                OnPropertyChanged("NbUnder");
                OnPropertyChanged("NbWhite");
                OnPropertyChanged("NbCivil");


            }
        }

        /** L'attribut nbWhite nombre de Mr. white participant au jeu */
        private int nbWhite;
        /**
         * @brief getteur et setteur de l'attribut nbWhite
         */
        [DataMember(Order = 3)]
        public int NbWhite
        {
            get
            {
                return nbWhite;
            }
            set
            {
                int imposteur = nbUnder + nbWhite;
                if ((((imposteur == (nbJoueurs / 2)) && (value > 0)) || ((imposteur == 1)) && (value < 0)))
                {

                    if ((nbWhite == 0) && (nbJoueurs == 3) && (nbUnder == 1) && (value > 0))
                    {
                        nbUnder = nbUnder - value;
                        nbWhite = nbWhite + value;
                        OnPropertyChanged("NbWhite");
                        OnPropertyChanged("NbUnder");
                    }
                    return;
                }
                else if (((nbWhite >= ((float)nbJoueurs / 2) - 1.0) && (value > 0)) || ((nbWhite == 0) && (value < 0)))
                {
                    return;
                }

                nbWhite = nbWhite + value;
                nbCivil = nbCivil - value;
                OnPropertyChanged("NbWhite");
                OnPropertyChanged("NbCivil");
                OnPropertyChanged("NbUnder");
            }
        }
        /** L'attribut nbRounds nombre des rounds */
        private int nbRounds;
        /**
         * @brief getteur et setteur de l'attribut nbRounds
         */
        [DataMember(Order = 4)]
        public int NbRounds
        {
            get
            {
                return nbRounds;
            }
            set
            {
                if ((nbRounds == 1) && (value < 0))
                {
                    return;
                }
                if ((nbRounds == 10) && (value > 0))
                {
                    return;
                }
                nbRounds = nbRounds + value;
                OnPropertyChanged("NbRounds");
            }
        }

        /**
         * @brief Construction de Parametres
         */
        public Parametres() 
        {
            NbJoueurs = 3;
            NbRounds = 1;
        }
        /**
         * @brief Construction de Parametres
         * @param nb nombre de joueurs
         */
        public Parametres(int nb) 
        { 
            NbJoueurs = nb; 
            NbRounds = 1;
        }

        
    }
}
