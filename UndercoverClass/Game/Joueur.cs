using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Rules;
using System.Runtime.Serialization;

/**
 * @file Joueur.cs
 * @brief Définition de la classe Joueur qui gère les données des personnages des utilisateurs
 */
namespace UndercoverClass.Game
{
    [DataContract]
    public class Joueur:IEquatable<Joueur>, INotifyPropertyChanged
    {
        /** L'attribut Name nom de joueur */
        
        private string name;

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        [DataMember (Order = 0)]
        public string? Name
        {
            get
            {
                return name;
            }
            set
           {
                name = value;
                OnPropertyChanged(nameof(Name));

            }
                }
        private string image;
        [DataMember(Order = 1)]
        public string Image 
        {
            get
            {
                return image;
            }

            set
            {
                image= value; 
                OnPropertyChanged(nameof(Image));
            }
        }

        private List<string> images = new List<string>();

        [DataMember(Order = 2)]
        public List<string> Images { get; set; }
        

        public void ChoisirImage(string image, bool b)
        {
            

            int index = Images.IndexOf(image);
            if (index != -1)
            {
                int t = Images.Count();
                if(b)
                {
                    if(index==t-1)
                    {
                        this.Image = Images[0];
                    }
                    else
                        this.Image = Images[index + 1];
                }
                else
                {
                    if(index==0)
                    {
                        
                        this.Image = Images[t - 1];
                    }
                    else
                        this.Image = Images[index - 1];
                }
                
            }
            else
            {
                return;
            }
        }
        /**
         * @brief Construction de joueur
         */
        public Joueur(){ }

        /**
         * @brief Construction de joueur sans nom
         * @param numero numero de joueur
         */
        public Joueur(int numero)
        {
            this.Name = "Joueur "+ (numero+1);
        }

        /**
         * @brief Construction de joueur avec nom
         * @param name nom de joueur
         */
        public Joueur(string name)
        {
            this.Name = name;
        }
        public Joueur(string name, string image)
        {
            this.Name = name;
            this.Image = image;
        }
        public Joueur(string name, string image, List<string> images)
        {
            this.Name = name;
            this.Image = image;
            this.Images = images;
        }
        /**
         * @brief comparaison des noms des joueurs
         * @param other objet de type Joueur
         * @return true si les noms sont égaux false sinon
         */
        public bool Equals(Joueur ?other)
        {
            if (other == null) return false;
            if (Name == null) return false;
            if (Name.Equals(other.Name))
                return true;
            return false;
        }

        /**
         * @brief comparaison des joueurs
         * @param obj objet de type Joueur
         * @return true si les objets sont égaux false sinon
         */
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Joueur);

        }

        /**
         * @brief Génère un code de hachage basé sur le nom du joueur
         * @return représentation de code de hachage du nom du joueur
         */
        public override int GetHashCode()
        {
            if(Name == null) return 0;
            return Name.GetHashCode();
        }

        /**
         * @brief récupérer le nom de joueur
         * @return nom du joueur sous forme de chaîne de caractères
         */
        public override string ToString()
        { 
            return $"{this.Name}";
        }
    }
}
