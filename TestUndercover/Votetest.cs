using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Game;
using UndercoverClass.Rules;

namespace TestUndercover
{
    public class Votetest
    {
        [Fact]

        public void Test_vote_Constructeur_not_null_not_empty()
        {

            IRole j = new Civil(new Joueur("toto"));

            Vote v2 = new Vote(j);
            Assert.NotNull(v2);
            Assert.NotNull(v2.JoueurVote);

        }

        [Fact]

        public void Test_vote_Constructeur_null_not_empty()
        {

            Vote v4 = new Vote(null);
        }
        [Fact]

        public void Test_vote_Constructeur_not_null_empty()
        {
            Vote v1 = new Vote();
            Assert.NotNull(v1);
            Assert.Null(v1.JoueurVote);
        }
        [Fact]
        public void TestDicoVote()
        {
            IRole j3 = new Civil(new Joueur("bob"));
            Vote v1 = new Vote();

            IRole j = new Civil(new Joueur("toto"));
            Vote v2 = new Vote(j);

            IRole j2 = new Civil(new Joueur("titi"));
            Vote v3 = new Vote(j2);

            List<Vote> list = new List<Vote>();
            Dictionary<Vote, int> voteDico = new Dictionary<Vote, int>();
            Assert.NotNull(voteDico);

            list.Add(v1);
            list.Add(v2);
            list.Add(v3);
            
            Assert.NotNull(list);
           

            list.Add(v3);

            foreach (Vote v in list)
            {

                if (v.GetHashCode() == 0)
                    continue;
                    //Assert.Fail();

                if (voteDico.ContainsKey(v))
                {
                    voteDico[v] += 1;
                }
                else
                {
                    voteDico.Add(v, 1);
                }

            }
            Assert.DoesNotContain(v1, voteDico);
            Assert.Contains(v2, voteDico);
            Assert.Contains(v3, voteDico);

            Assert.Distinct(voteDico);
            Assert.NotEmpty(list);
            Assert.True(voteDico.ContainsKey(v2));
            Assert.True(voteDico.ContainsKey(v3));
            Assert.False(voteDico.ContainsKey(v1));
            int b;
            voteDico.TryGetValue(v2, out b);
            Assert.True(b==1);
        }

    }
}
