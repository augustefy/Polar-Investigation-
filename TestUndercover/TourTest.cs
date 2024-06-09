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
    public class TourTest
    {
        private class TestRole : IRole
        {
            public bool Gagner { get; set; }
            public bool Mort { get; set; }
            public string Role { get; set; }
            public Joueur Joueur { get; set; }
            public string? ChangementRole { get; set; }

            public TestRole(string joueurNom)
            {
                Joueur = new Joueur { Name = joueurNom };
                Gagner = false;
                Mort = false;
                Role = string.Empty;
                ChangementRole = null;
            }
        }

        [Fact]
        public void TestTourConstructorInitializesProperties()
        {
            var joueurs = new List<IRole> { new TestRole("Alice"), new TestRole("Bob") };
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));

            var tour = new Tour(joueurs, plateau);

            Assert.Equal(joueurs, tour.JoueursList);
            Assert.Equal(plateau, tour.Plateau);
            Assert.Empty(tour.VoteList);
            Assert.Empty(tour.VoteDict);
        }

        [Fact]
        public void TestDireMotAllInvokesPlayeurSpeakingForEachPlayer()
        {
            var joueurs = new List<IRole> { new TestRole("Alice"), new TestRole("Bob") };
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));
            var tour = new Tour(joueurs, plateau);

            int eventInvokeCount = 0;
            tour.PlayeurSpeaking += (sender, args) => eventInvokeCount++;

            tour.DireMotAll();

            Assert.Equal(joueurs.Count, eventInvokeCount);
        }

        [Fact]
        public void TestVoterInvokesPlayeurVoting()
        {
            var joueurs = new List<IRole> { new TestRole("Alice"), new TestRole("Bob") };
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));
            var tour = new Tour(joueurs, plateau);
            var casec = new Case(0, 0);

            bool eventInvoked = false;
            tour.PlayeurVoting += (sender, args) => eventInvoked = true;

            tour.Voter(joueurs[0], casec);

            Assert.True(eventInvoked);
        }

        [Fact]
        public void TestTransformDicUpdatesVoteDict()
        {
            var joueurs = new List<IRole> { new TestRole("Alice"), new TestRole("Bob") };
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));
            var tour = new Tour(joueurs, plateau);

            var voteAlice = new Vote((TestRole)joueurs[0]);
            var voteBob = new Vote((TestRole)joueurs[1]);

            tour.VoteList.Add(voteAlice);
            tour.VoteList.Add(voteAlice);
            tour.VoteList.Add(voteBob);

            tour.TransformDic();
            Assert.Equal(2, tour.VoteDict[voteAlice]);
            Assert.Equal(1, tour.VoteDict[voteBob]);
        }

        [Fact]
        public void TestCompterVoteReturnsPlayerWithMostVotes()
        {
            var joueurs = new List<IRole> { new TestRole("Alice"), new TestRole("Bob") };
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));
            var tour = new Tour(joueurs, plateau);
            var voteAlice = new Vote((TestRole)joueurs[0]);
            var voteBob = new Vote((TestRole)joueurs[1]);

            tour.VoteDict[voteAlice] = 2;
            tour.VoteDict[voteBob] = 1;

            var result = tour.CompterVote();

            Assert.Equal(voteAlice, result);
        }

        [Fact]
        public void TestCompterVoteReturnsPlayerWithMostVotesWhenTie()
        {
            var joueurs = new List<IRole> { new TestRole("Alice"), new TestRole("Bob"), new TestRole("Charlie") };
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));
            var tour = new Tour(joueurs, plateau);

            var voteAlice = new Vote((TestRole)joueurs[0]);
            var voteBob = new Vote((TestRole)joueurs[1]);
            var voteCharlie = new Vote((TestRole)joueurs[2]);

            tour.VoteDict[voteAlice] = 2;
            tour.VoteDict[voteBob] = 1;
            tour.VoteDict[voteCharlie] = 2;

            var result = tour.CompterVote();

            Assert.Contains(result, new[] { voteAlice, voteCharlie });
        }

        [Fact]
        public void TestFinDeTourUpdatesPlayerStatus()
        {
            var joueursVivants = new List<IRole> { new TestRole("Alice"), new TestRole("Bob") };
            var joueursMorts = new List<IRole>();
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));
            var tour = new Tour(joueursVivants, plateau);

            var voteAlice = new Vote((TestRole)joueursVivants[0]);

            tour.FinDeTour(voteAlice, joueursVivants, joueursMorts);

            Assert.DoesNotContain(joueursVivants, j => j.Joueur.Name == "Alice");
            Assert.Contains(joueursMorts, j => j.Joueur.Name == "Alice");
            Assert.True(joueursMorts[0].Mort);
        }

        [Fact]
        public void TestVoterAllVotesForEachPlayer()
        {
            var joueurs = new List<IRole> { new TestRole("Alice"), new TestRole("Bob") };
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));
            var tour = new Tour(joueurs, plateau);
            var casec = new Case(0, 0);
            int eventInvokedCount = 0;
            tour.PlayeurVoting += (sender, args) => eventInvokedCount++;

            tour.VoterAll();

            Assert.Equal(joueurs.Count, eventInvokedCount);
        }
        
        [Fact]
        public void TestVoterAllTransformsVotesIntoDictionary()
        {
            var joueurs = new List<IRole> { new TestRole("Alice"), new TestRole("Bob") };
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));
            var tour = new Tour(joueurs, plateau);

            tour.Voter(joueurs[0], new Case(0, 0));
            tour.Voter(joueurs[0], new Case(0, 1));
            tour.Voter(joueurs[1], new Case(0, 2));

            tour.VoterAll();

            Assert.Equal(0, tour.VoteDict.Count);
        }

        [Fact]
        public void TestRestartVoteInvokesRestartVoteEvent()
        {
            var joueurs = new List<IRole> { new TestRole("Alice"), new TestRole("Bob") };
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));
            var tour = new Tour(joueurs, plateau);

            bool eventInvoked = false;
            tour.RestartVote += (sender, args) => eventInvoked = true;

            tour.OnRestartVote();

            Assert.True(eventInvoked);
        }

        [Fact]
        public void TestRestartVoteResetsVoteList()
        {
            var joueurs = new List<IRole> { new TestRole("Alice"), new TestRole("Bob") };
            var plateau = new Plateau(5, 3, 2, 10, new Mot("Pain au chocolat", "Croissant"));
            var tour = new Tour(joueurs, plateau);

            tour.Voter(joueurs[0], new Case(0, 0));
            tour.Voter(joueurs[1], new Case(0, 1));

            tour.OnRestartVote();

            Assert.Empty(tour.VoteList);
        }
    }
}

