using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dice_for_playing
{
    class RobotPlayer : Player
    {
        public RobotPlayer(string pseudo) : base(pseudo)
        {
        }

        public override bool RollDice(int points, int opponentScore)
        {
            bool roll = true;

            // si le joueur adverse ne gagne pas sur un abandon
            // et que le nombre de points actuel est suzpérieur à 21 moins le jet de dés moyen
            if (opponentScore < 4 && points > 21-7)
            {
                roll = false;
            }

            return roll;
        }
    }
}