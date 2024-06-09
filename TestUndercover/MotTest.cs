using System;
using UndercoverClass.Game;
using Xunit;

namespace TestUndercover
{
    public class MotTest
    {
        [Fact]
        public void TestMotConstructorInitializesProperties()
        {
            string motC = "Pain au chocolat";
            string motU = "Croissant";

            Mot mot = new Mot(motC, motU);

            Assert.Equal(motC, mot.MotC);
            Assert.Equal(motU, mot.MotU);
            Assert.Equal("Vous êtes Mr.White", mot.MotW);
        }

        [Fact]
        public void TestMotConstructorAssignsDefaultMotCWhenNull()
        {
            string motC = null;
            string motU = "Croissant";

            Mot mot = new Mot(motC, motU);

            Assert.Equal("Rouge", mot.MotC);
            Assert.Equal(motU, mot.MotU);
            Assert.Equal("Vous êtes Mr.White", mot.MotW);
        }

        [Fact]
        public void TestMotConstructorAssignsDefaultMotUWhenNull()
        {
            string motC = "Pain au chocolat";
            string motU = null;

            Mot mot = new Mot(motC, motU);

            Assert.Equal(motC, mot.MotC);
            Assert.Equal("Rose", mot.MotU);
            Assert.Equal("Vous êtes Mr.White", mot.MotW);
        }

        [Fact]
        public void TestMotConstructorAssignsDefaultMotsWhenBothNull()
        {
            string motC = null;
            string motU = null;

            Mot mot = new Mot(motC, motU);

            Assert.Equal("Rouge", mot.MotC);
            Assert.Equal("Rose", mot.MotU);
            Assert.Equal("Vous êtes Mr.White", mot.MotW);
        }

        [Fact]
        public void TestMotPropertiesCanBeSet()
        {
            string motC = "Pain au chocolat";
            string motU = "Croissant";
            Mot mot = new Mot(motC, motU);

            mot.MotC = "Baguette";
            mot.MotU = "Éclair";
            mot.MotW = "Vous êtes Mr.Black";

            Assert.Equal("Baguette", mot.MotC);
            Assert.Equal("Éclair", mot.MotU);
            Assert.Equal("Vous êtes Mr.Black", mot.MotW);
        }
    }
}
