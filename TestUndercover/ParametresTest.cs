using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UndercoverClass.Game;
using UndercoverClass.Rules;

namespace TestUndercover
{
    public class ParamatresTest
    {

        [Fact]
        public void TestInitialNbJoueurs()
        {
            var parametres = new Parametres(5);
            int nbJoueurs = parametres.NbJoueurs;
            Assert.Equal(5, nbJoueurs);
        }

        [Fact]
        public void TestIncreaseNbJoueurs()
        {
            var parametres = new Parametres(5);
            bool eventRaised = false;
            parametres.ValueClickedBad += (sender, args) => { eventRaised = true; };
            parametres.Ajouter(1, "Joueurs");
            Assert.Equal(6, parametres.NbJoueurs);
            Assert.False(eventRaised);
        }

        [Fact]
        public void TestDecreaseNbJoueurs()
        {
            var parametres = new Parametres(5);
            bool eventRaised = false;
            parametres.ValueClickedBad += (sender, args) => { eventRaised = true; };
            parametres.Ajouter(-1, "Joueurs");
            Assert.Equal(4, parametres.NbJoueurs);
            Assert.False(eventRaised);
        }

        [Fact]
        public void TestIncreaseNbJoueursBeyondLimit()
        {
            var parametres = new Parametres(20);
            bool eventRaised = false;
            parametres.Ajouter(1, "Joueurs");
            Assert.Equal(20, parametres.NbJoueurs);
        }
        
        [Fact]
        public void TestDecreaseNbJoueursBelowLimit()
        {
            var parametres = new Parametres(3);
            bool eventRaised = false;
            parametres.Ajouter(-1, "Joueurs");
            Assert.Equal(3, parametres.NbJoueurs);
        }

        [Fact]
        public void TestNbCivilCalculation()
        {
            var parametres = new Parametres(5);
            int nbCivil = parametres.NbCivil;
            Assert.Equal(3, nbCivil);
        }

        [Fact]
        public void TestNbUnderCalculation()
        {
            var parametres = new Parametres(6);
            parametres.Ajouter(1, "Joueurs");
            Assert.Equal(1, parametres.NbWhite);
        }

        [Fact]
        public void TestNbUnderbisCalculation()
        {
            var parametres = new Parametres(6);
            parametres.Ajouter(1, "Under");
            Assert.Equal(2, parametres.NbUnder);
        }
        [Fact]
        public void TestNbWhitebisCalculation()
        {
            var parametres = new Parametres(6);
            parametres.Ajouter(1, "White");
            Assert.Equal(2, parametres.NbWhite);
        }

        [Fact]
        public void TestNbWhiteCalculation()
        {
            var parametres = new Parametres(6);
            parametres.Ajouter(1, "Joueurs");
            Assert.Equal(1, parametres.NbWhite);
        }

        [Fact]
        public void TestFalseCalculat()
        {
            var parametres = new Parametres(6);
            Assert.False(parametres.Ajouter(1, "x"));
        }


        [Fact]
        public void TestNbRoundsInitial()
        {
            var parametres = new Parametres(5);
            int nbRounds = parametres.NbRounds;
            Assert.Equal(1, nbRounds);
        }

        [Fact]
        public void TestIncreaseNbRounds()
        {
            var parametres = new Parametres(5);
            parametres.NbRounds = 1;
            Assert.Equal(2, parametres.NbRounds);
        }

        [Fact]
        public void TestDecreaseNbRounds()
        {
            var parametres = new Parametres(5);
            parametres.NbRounds = 5;
            parametres.NbRounds = -1;
            Assert.Equal(5, parametres.NbRounds);//redifinition du set donc rajoute a chaque "="
        }

        [Fact]
        public void TestIncreaseNbRoundsBeyondLimit()
        {
            var parametres = new Parametres(5);
            parametres.NbRounds = 9;
            parametres.NbRounds = 1;
            Assert.Equal(10, parametres.NbRounds); //redifinition du set donc rajoute a chaque "="
        }

        [Fact]
        public void TestDecreaseNbRoundsBelowLimit()
        {
            var parametres = new Parametres(5);
            parametres.NbRounds = -1;
            Assert.Equal(1, parametres.NbRounds);
        }

        [Fact]
        public void TestDecreaseNbRoundsBelowLimitButNull()
        {
            var parametres = new Parametres(5);
            parametres.NbRounds = 0;
            Assert.Equal(1, parametres.NbRounds);
        }
        [Fact]
        public void TestDecreaseNbRoundsOverLimitButNull()
        {
            var parametres = new Parametres(5);
            parametres.NbRounds = 9;
            parametres.NbRounds = 0;
            Assert.Equal(10, parametres.NbRounds);
        }
     
    }
}