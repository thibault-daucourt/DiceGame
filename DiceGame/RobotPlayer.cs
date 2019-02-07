using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dice_for_playing
{
    class RobotPlayer : Player
    {
        private int limite;

        public RobotPlayer(string pseudo,Dice dice1, Dice dice2) : base(pseudo)
        {
            limite = (int)((dice1.NumberSides + 1 + dice2.NumberSides + 1) / 2);
        }

        public override bool RollDice(int points, int opponentScore)
        {
            bool roll = true;

            // si le joueur adverse ne gagne pas sur un abandon
            // et que le nombre de points actuel est suzpérieur à 21 moins le jet de dés moyen
            if (opponentScore < 4 && points > 21-limite)
            {
                roll = false;
            }

            return roll;
        }

        
    }
}