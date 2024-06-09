using UndercoverClass.Game;
using UndercoverClass.Rules;

namespace TestUndercover
{
    public class WhiteTest
    {
        [Fact]
        public void TestTostringNameNull()
        {
            var j = new Joueur();
            var c = new White(j);
            c.Joueur.Name = "Joris";
            Assert.Null(c.ChangementRole);
            Assert.Equal(c.Joueur.Name + " = " + c.Role, c.ToString());
        }

        [Fact]
        public void TestTostringNameFull()
        {
            var j = new Joueur();
            var c = new White(j);
            c.Joueur.Name = "Joris";
            c.ChangementRole = "x";
            Assert.Equal("x", c.ChangementRole);
            Assert.Equal("Joris" + " = " + c.Role, c.ToString());
        }
    }
}