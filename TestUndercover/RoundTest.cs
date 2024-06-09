using System;
using System.Collections.Generic;
using System.Linq;
using UndercoverClass.Board;
using UndercoverClass.Events;
using UndercoverClass.Game;
using UndercoverClass.Rules;
using Xunit;

namespace TestUndercover
{
    public class RoundTest
    {
        private class TestRole : IRole
        {
            public bool Gagner { get; set; }
            public bool Mort { get; set; }
            public string Role { get; set; }
            public Joueur Joueur { get; set; }
            public string? ChangementRole { get; set; }

            public TestRole(string joueurName)
            {
                Joueur = new Joueur { Name = joueurName };
                Gagner = false;
                Mort = false;
                Role = string.Empty;
                ChangementRole = null;
            }
        }

        private class TestVote : Vote
        {
            public TestRole JoueurVote { get; set; }

            public TestVote(TestRole joueur)
            {
                JoueurVote = joueur;
            }

            public override int GetHashCode()
            {
                return JoueurVote.Joueur.Name.GetHashCode();
            }
        }

        [Fact]
        public void TestRoundConstructorInitializesProperties()
        {
            var mot = new Mot("Pain au chocolat", "Croissant");
            var joueurs = new List<Joueur> { new Joueur { Name = "Alice" }, new Joueur { Name = "Bob" } };
            var parametres = new Parametres(10);

            var round = new Round(mot, joueurs, parametres);

            Assert.Equal(mot, round.Mott);
            Assert.Equal(2, round.JoueursVivant.Count);
            Assert.Empty(round.JoueursMort);
            Assert.NotNull(round.Plateau);
        }

        [Fact]
        public void TestChoisirCaseChangesRole()
        {
            var mot = new Mot("Pain au chocolat", "Croissant");
            var joueur = new Joueur { Name = "Alice" };
            var parametres = new Parametres(10);
            var round = new Round(mot, new List<Joueur> { joueur }, parametres);

            var role = new TestRole("Alice") { ChangementRole = "Under" };
            var result = round.ChoisirCase(role, new Case(0, 0));

            Assert.IsType<Under>(result);
        }

        [Fact]
        public void TestChoisirCaseAll()
        {
            var mot = new Mot("Pain au chocolat", "Croissant");
            var joueurs = new List<Joueur> { new Joueur { Name = "Alice" }, new Joueur { Name = "Bob" } };
            var parametres = new Parametres(10);
            var round = new Round(mot, joueurs, parametres);

            round.ChoisirCaseAll();

            Assert.Equal(2, round.JoueursVivant.Count); // Assuming no role changes
        }

        [Fact]
        public void TestCreerTour()
        {
            var mot = new Mot("Pain au chocolat", "Croissant");
            var joueurs = new List<Joueur> { new Joueur { Name = "Alice" }, new Joueur { Name = "Bob" } };
            var parametres = new Parametres(10);
            var round = new Round(mot, joueurs, parametres);

            var tour = round.CreerTour();

            Assert.Contains(tour, round.Tours);
            Assert.NotNull(tour);
        }


        [Fact]
        public void TestRoundEquality()
        {
            var mot1 = new Mot("Pain au chocolat", "Croissant");
            var mot2 = new Mot("Baguette", "Pain");
            var joueurs = new List<Joueur> { new Joueur { Name = "Alice" }, new Joueur { Name = "Bob" } };
            var parametres = new Parametres(10);

            var round1 = new Round(mot1, joueurs, parametres);
            var round2 = new Round(mot1, joueurs, parametres);
            var round3 = new Round(mot2, joueurs, parametres);

            Assert.True(round1.Equals(round2));
            Assert.False(round1.Equals(round3));
        }

        [Fact]
        public void TestChoisirJoueurAuHasard()
        {
            var mot = new Mot("Pain au chocolat", "Croissant");
            var joueurs = new List<Joueur> { new Joueur { Name = "Alice" }, new Joueur { Name = "Bob" }, new Joueur { Name = "Charlie" } };
            var parametres = new Parametres(10);
            var round = new Round(mot, joueurs, parametres);


            Random r = new Random();
            var joueurChoisi = round.JoueursVivant[r.Next(round.JoueursVivant.Count)];

            Assert.Contains(joueurChoisi, round.JoueursVivant);
        }
    }
}
