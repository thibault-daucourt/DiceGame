using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dice_for_playing
{
    class Jeu
    {
        private Dice leDé = new Dice();

        public void jouer()
        {
            leDé.Roll();

            Console.WriteLine("Le joueur avance de {0} cases.," +
                leDé.VisibleSide);
        }
    }
}