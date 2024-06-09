using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Game;

namespace UndercoverClass.Persistance
{
    public interface ISerializer
    {
        void WritePartie(Partie p);
       
        Partie ReadPartie();
       
    }
}
