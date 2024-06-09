using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Board;
using UndercoverClass.Events;
using UndercoverClass.Rules;
using UndercoverClass.Persistance;
using UndercoverClass.Game;
using Xunit;

namespace TestUndercover
{
    public class PartieTest
    {

        [Fact]
        public void TestPartieConstructorInitializesProperties()
        {
            var motsPasJouer = new List<Mot> { new Mot("Fraise", "Framboise"), new Mot("Chien", "Chat") };
            var partie = new Partie(motsPasJouer);

            Assert.Equal(motsPasJouer, partie.MotsPasJouer);
            Assert.Empty(partie.Rounds);
            Assert.Empty(partie.MotsJouer);
            Assert.Empty(partie.joueurs);
            Assert.NotNull(partie.Images);
        }

        [Fact]
        public void TestPartieDefaultConstructor()
        {
            var partie = new Partie();

            Assert.NotNull(partie.MotsPasJouer);
        }

        [Fact]
        public void TestValiderNbJoueurs()
        {
            var partie = new Partie();
            partie.ValiderNbJoueurs();

            Assert.Equal(3, partie.Joueurs.Count);
        }

        [Fact]
        public void TestChoisirNbJoueur()
        {
            var partie = new Partie();
            bool eventCalled = false;

            partie.PickingNumberPlayeur += (sender, args) => eventCalled = true;

            partie.ChoisirNbJoueur();

            Assert.True(eventCalled);
            Assert.Equal(partie.Parametres.NbJoueurs, partie.joueurs.Count);
        }

        [Fact]
        public void TestChoisirNbUnder()
        {
            var partie = new Partie();
            bool eventCalled = false;

            partie.PickingNumberPlayeur += (sender, args) =>
            {
                if (args.Type == "Under")
                    eventCalled = true;
            };

            partie.ChoisirNbUnder();

            Assert.True(eventCalled);
        }

        [Fact]
        public void TestChoisirNbWhite()
        {
            var partie = new Partie();
            bool eventCalled = false;

            partie.PickingNumberPlayeur += (sender, args) =>
            {
                if (args.Type == "White")
                    eventCalled = true;
            };

            partie.ChoisirNbWhite();

            Assert.True(eventCalled);
        }

        [Fact]
        public void TestChoisirNbRounds()
        {
            var partie = new Partie();
            bool eventCalled = false;

            partie.PickingNumberRound += (sender, args) => eventCalled = true;

            partie.ChoisirNbRounds();

            Assert.True(eventCalled);
        }

        [Fact]
        public void TestChoisirNom()
        {
            var partie = new Partie();
            var joueur = new Joueur("Joueur 1", "cat.png", new List<string> { "cat.png" });
            bool eventCalled = false;

            partie.PickingName += (sender, args) => eventCalled = true;

            partie.ChoisirNom(joueur);

            Assert.True(eventCalled);
        }

        [Fact]
        public void TestChoisirNomAll()
        {
            var partie = new Partie();
            partie.Parametres.NbJoueurs = 3;
            partie.ValiderNbJoueurs();
            bool eventCalled = false;

            partie.PickingName += (sender, args) => eventCalled = true;

            partie.ChoisirNomAll();

            Assert.True(eventCalled);
        }

        [Fact]
        public void TestCreerRound()
        {
            var partie = new Partie();
            partie.Parametres.NbJoueurs = 3;
            partie.ValiderNbJoueurs();
            var round = partie.CreerRound();

            Assert.NotNull(round);
            Assert.Single(partie.Rounds);
        }
    }
}
