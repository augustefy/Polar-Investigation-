using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UndercoverClass.Board;
using UndercoverClass.Game;
using UndercoverClass.Rules;
using Xunit;

namespace TestUndercover
{
    public class CaseTest
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

        [Fact]
        public void TestCaseConstructorInitializesProperties()
        {
            var caseObj = new Case(1, 2);

            Assert.Equal(1, caseObj.X);
            Assert.Equal(2, caseObj.Y);
            Assert.False(caseObj.Face);
        }

        [Fact]
        public void TestChangeFaceSetsFaceToTrue()
        {
            var caseObj = new Case(1, 2);

            caseObj.ChangeFace();

            Assert.True(caseObj.Face);
        }

        [Fact]
        public void TestToStringFaceDownOrNoJoueur()
        {
            var caseObj = new Case(1, 2);

            Assert.Equal(" | ? | ", caseObj.ToString());
        }

        [Fact]
        public void TestToStringFaceUpJoueurAlive()
        {
            var caseObj = new Case(1, 2);
            var joueur = new TestRole("Alice") { Mort = false };
            caseObj.Joueur = joueur;
            caseObj.ChangeFace();

            Assert.Equal(" | Alice | ", caseObj.ToString());
        }

        [Fact]
        public void TestToStringFaceUpJoueurDead()
        {
            var caseObj = new Case(1, 2);
            var joueur = new TestRole("Alice") { Mort = true };
            caseObj.Joueur = joueur;
            caseObj.ChangeFace();

            Assert.Equal(" | Alice (Mort) | ", caseObj.ToString());
        }

        [Fact]
        public void TestEquals()
        {
            var caseObj1 = new Case(1, 2) { Face = true };
            var caseObj2 = new Case(1, 2) { Face = true };

            Assert.True(caseObj1.Equals(caseObj2));
        }

        [Fact]
        public void TestNotEquals()
        {
            var caseObj1 = new Case(1, 2) { Face = true };
            var caseObj2 = new Case(1, 2) { Face = false };

            Assert.False(caseObj1.Equals(caseObj2));
        }

        [Fact]
        public void TestEqualsWithDifferentObject()
        {
            var caseObj = new Case(1, 2) { Face = true };

            Assert.False(caseObj.Equals(new object()));
        }

        [Fact]
        public void TestGetHashCode()
        {
            var joueur = new TestRole("Alice");
            var caseObj = new Case(1, 2) { Joueur = joueur };

            Assert.Equal(joueur.GetHashCode(), caseObj.GetHashCode());
        }

        [Fact]
        public void TestImageSourcePropertyChange()
        {
            var caseObj = new Case(1, 2);
            bool eventRaised = false;

            caseObj.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(Case.ImageSource))
                {
                    eventRaised = true;
                }
            };

            caseObj.ImageSource = "newImage.png";

            Assert.True(eventRaised);
            Assert.Equal("newImage.png", caseObj.ImageSource);
        }

        [Fact]
        public void TestTextPropertyChange()
        {
            var caseObj = new Case(1, 2);
            bool eventRaised = false;

            caseObj.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(Case.Text))
                {
                    eventRaised = true;
                }
            };

            caseObj.Text = "New Text";

            Assert.True(eventRaised);
            Assert.Equal("New Text", caseObj.Text);
        }

        [Fact]
        public void TestVotesImgPropertyChange()
        {
            var caseObj = new Case(1, 2);
            bool eventRaised = false;
            var newVotesImg = new ObservableCollection<Joueur> { new Joueur { Name = "Alice" } };

            caseObj.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(Case.VotesImg))
                {
                    eventRaised = true;
                }
            };

            caseObj.VotesImg = newVotesImg;

            Assert.True(eventRaised);
            Assert.Equal(newVotesImg, caseObj.VotesImg);
        }
    }
}
