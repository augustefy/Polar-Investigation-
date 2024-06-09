using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UndercoverClass.Board;
using UndercoverClass.Events;
using UndercoverClass.Game;
using UndercoverClass.Rules;
using Xunit;

namespace TestUndercover
{
    public class PlateauTest
    {
        [Fact]
        public void TestPlateauConstructorInitializesProperties()
        {
            int nbCivil = 5;
            int nbUnder = 3;
            int nbWhite = 2;
            int nbJ = 10;
            Mot mot = new Mot("Pain au chocolat", "Croissant");

            Plateau plateau = new Plateau(nbCivil, nbUnder, nbWhite, nbJ, mot);

            Assert.NotNull(plateau.Mot);
            Assert.Equal(mot, plateau.Mot);
            Assert.Equal(nbJ, plateau.Board.Count);
            Assert.Equal(nbJ, plateau.board.Count);
        }

        [Fact]
        public void TestPlateauConstructorAssignsDefaultMotWhenNull()
        {
            int nbCivil = 5;
            int nbUnder = 3;
            int nbWhite = 2;
            int nbJ = 10;
            Mot mot = null;

            Plateau plateau = new Plateau(nbCivil, nbUnder, nbWhite, nbJ, mot);

            Assert.NotNull(plateau.Mot);
            Assert.Equal("Pain au chocolat", plateau.Mot.MotC);
            Assert.Equal("Croissant", plateau.Mot.MotU);
        }

        [Fact]
        public void TestPlateauBoardHasCorrectNumberOfCases()
        {
            int nbCivil = 5;
            int nbUnder = 3;
            int nbWhite = 2;
            int nbJ = 10;
            Mot mot = new Mot("Pain au chocolat", "Croissant");

            Plateau plateau = new Plateau(nbCivil, nbUnder, nbWhite, nbJ, mot);

            Assert.Equal(nbJ, plateau.Board.Count);
        }

        [Fact]
        public void TestPlateauBoardCasesAreCorrectlyInitialized()
        {
            int nbCivil = 5;
            int nbUnder = 3;
            int nbWhite = 2;
            int nbJ = 10;
            Mot mot = new Mot("Pain au chocolat", "Croissant");

            Plateau plateau = new Plateau(nbCivil, nbUnder, nbWhite, nbJ, mot);

            foreach (var c in plateau.Board)
            {
                Assert.Equal("undercoverlogo.png", c.ImageSource);
                Assert.Equal("Click!", c.Text);
            }
        }

        [Fact]
        public void TestAttribuerMotCaseAssignsCorrectNumberOfWords()
        {
            int nbCivil = 5;
            int nbUnder = 3;
            int nbWhite = 2;
            int nbJ = 10;
            Mot mot = new Mot("Pain au chocolat", "Croissant");

            Plateau plateau = new Plateau(nbCivil, nbUnder, nbWhite, nbJ, mot);

            var civilCases = plateau.Board.Count(c => c.Mot == "Pain au chocolat");
            var undercoverCases = plateau.Board.Count(c => c.Mot == "Croissant");
            var whiteCases = plateau.Board.Count(c => c.Mot == "Vous êtes Mr.White");

            Assert.Equal(nbCivil, civilCases);
            Assert.Equal(nbUnder, undercoverCases);
            Assert.Equal(nbWhite, whiteCases);
        }
    }
}
