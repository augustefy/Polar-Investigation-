using UndercoverClass.Game;
using UndercoverClass.Rules;

namespace TestUndercover
{
    public class UnderTest
    {
        [Fact]
        public void TestTostringNameNull()
        {
            var j = new Joueur();
            var c = new Under(j);
            c.Joueur.Name = "Joris";
            Assert.Equal(c.Joueur.Name + " = " + c.Role, c.ToString());
            Assert.Null(c.ChangementRole);
        }

        [Fact]
        public void TestTostringNameFull()
        {
            var j = new Joueur();
            var c = new Under(j);
            c.Joueur.Name = "Joris";
            c.ChangementRole = "x";
            Assert.Equal("x", c.ChangementRole);
            Assert.Equal("Joris" + " = " + c.Role, c.ToString());
        }
    }
}