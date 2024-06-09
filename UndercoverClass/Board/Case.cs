using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UndercoverClass.Game;
using UndercoverClass.Rules;

/**
 * @file Case.cs
 * @brief Définition de la classe Case qui gère les cases sur le plateau
 */
namespace UndercoverClass.Board
{
    [DataContract]
    public class Case : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [DataMember]
        /** L'attribut Face face de la carte */
        public bool Face {  get; set; }
        /** L'attribut X position de case sur ligne des abscisse */
        [DataMember]
        public int X { get;  set; }
        /** L'attribut Y position de case sur ligne des ordonnée */
        [DataMember]
        public int Y { get;  set; }

        [DataMember]
        /** L'attribut Mot qui sera attribuer a joueur */
        public string? Mot { get; set; }
        [DataMember]
        /** Déclaration d'objet Joueur*/
        public IRole? Joueur { get; set; }

        
        private string imageSource;
        [DataMember]
        public string ImageSource
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        private string text;
        [DataMember]
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

       
        // Des gens qui ont voter contre cet personne
        private ObservableCollection<Joueur> votesImg; 
        [DataMember]
        public ObservableCollection<Joueur> VotesImg 
        { 
            get
            {
                return votesImg;
            }
            set
            {
                votesImg = value;
                OnPropertyChanged(nameof(VotesImg));
            }
        }
        [DataMember]
        public List<Joueur> VotesImgv { get; set; } = new List<Joueur>();



        /**
         * @brief Construction de la case
         * @param x position sur les abscisse
         * @param y position sur les ordonnée
         */
        public Case(int x, int y)
        {  
            X = x; 
            Y = y; 
            Face = false;
        }

        /**
         * @brief Retourne la face de la carte
         */
        public void ChangeFace()
        { this.Face = true; }

        /** 
         * @brief Vérifie si la carte est retournée et si le joueur est vivant
         * @return Ccrte en forme de chaîne de caractères pour affichage
         */
        public override string ToString()
        {
            if (Face == false || Joueur == null)
                return " | ? | ";
            else
            {
                if(Joueur.Mort==false)
                    return $" | {Joueur.Joueur} | ";
                else
                    return $" | {Joueur.Joueur} (Mort) | ";
            }
        }


        public bool Equals(Case? other)
            => Face.Equals(other.Face);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Case);
        }

        /**
         * @brief Génère un code de hachage basé sur le mot
         * @return représentation de code de hachage du mot
         */
        public override int GetHashCode()
        {
            return Joueur.GetHashCode();
        }
    }
}
