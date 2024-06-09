using System;
using System.Collections.Generic;
using UndercoverClass.Game;
using Xunit;

namespace TestUndercover
{
    public class JoueurTest
    {
        [Fact]
        public void TestJoueurDefaultConstructor()
        {
            var joueur = new Joueur();
            Assert.Null(joueur.Name);
            Assert.Null(joueur.Image);
            Assert.Null(joueur.Images);
        }

        [Fact]
        public void TestJoueurConstructorWithName()
        {
            var joueur = new Joueur("Alice");
            Assert.Equal("Alice", joueur.Name);
        }

        [Fact]
        public void TestJoueurConstructorWithNameAndImage()
        {
            var joueur = new Joueur("Alice", "cat.png");
            Assert.Equal("Alice", joueur.Name);
            Assert.Equal("cat.png", joueur.Image);
        }

        [Fact]
        public void TestJoueurConstructorWithNameImageAndImages()
        {
            var images = new List<string> { "cat.png", "dog.png" };
            var joueur = new Joueur("Alice", "cat.png", images);
            Assert.Equal("Alice", joueur.Name);
            Assert.Equal("cat.png", joueur.Image);
            Assert.Equal(images, joueur.Images);
        }

        [Fact]
        public void TestJoueurNamePropertyChanged()
        {
            var joueur = new Joueur();
            bool eventCalled = false;
            joueur.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Joueur.Name))
                {
                    eventCalled = true;
                }
            };
            joueur.Name = "Alice";
            Assert.True(eventCalled);
        }

        [Fact]
        public void TestJoueurImagePropertyChanged()
        {
            var joueur = new Joueur();
            bool eventCalled = false;
            joueur.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Joueur.Image))
                {
                    eventCalled = true;
                }
            };
            joueur.Image = "cat.png";
            Assert.True(eventCalled);
        }

        [Fact]
        public void TestChoisirImageNext()
        {
            var images = new List<string> { "cat.png", "dog.png", "pig.png" };
            var joueur = new Joueur("Alice", "cat.png", images);
            joueur.ChoisirImage("cat.png", true);
            Assert.Equal("dog.png", joueur.Image);
        }

        [Fact]
        public void TestChoisirImagePrevious()
        {
            var images = new List<string> { "cat.png", "dog.png", "pig.png" };
            var joueur = new Joueur("Alice", "dog.png", images);
            joueur.ChoisirImage("dog.png", false);
            Assert.Equal("cat.png", joueur.Image);
        }

        [Fact]
        public void TestChoisirImageWrapAroundNext()
        {
            var images = new List<string> { "cat.png", "dog.png", "pig.png" };
            var joueur = new Joueur("Alice", "pig.png", images);
            joueur.ChoisirImage("pig.png", true);
            Assert.Equal("cat.png", joueur.Image);
        }

        [Fact]
        public void TestChoisirImageWrapAroundPrevious()
        {
            var images = new List<string> { "cat.png", "dog.png", "pig.png" };
            var joueur = new Joueur("Alice", "cat.png", images);
            joueur.ChoisirImage("cat.png", false);
            Assert.Equal("pig.png", joueur.Image);
        }

        [Fact]
        public void TestEqualsJoueur()
        {
            var joueur1 = new Joueur("Alice");
            var joueur2 = new Joueur("Alice");
            Assert.True(joueur1.Equals(joueur2));
        }

        [Fact]
        public void TestNotEqualsJoueur()
        {
            var joueur1 = new Joueur("Alice");
            var joueur2 = new Joueur("Bob");
            Assert.False(joueur1.Equals(joueur2));
        }

        [Fact]
        public void TestGetHashCode()
        {
            var joueur = new Joueur("Alice");
            Assert.Equal(joueur.Name.GetHashCode(), joueur.GetHashCode());
        }

        [Fact]
        public void TestToString()
        {
            var joueur = new Joueur("Alice");
            Assert.Equal("Alice", joueur.ToString());
        }
    }
}
