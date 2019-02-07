
using Dice_for_playing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DiceGame
{
    class HumanPlayer : Player
    {
        public HumanPlayer(string pseudo) : base(pseudo)
        {
        }

        public override bool RollDice(int points, int opponentScore)
        {
            Console.WriteLine("le nombre de point actuel est de {0} et votre adversaire à un score de {1}", points, opponentScore);
            Console.WriteLine("Voulez-vous relancer les dés ?(y/n) : ");

            string read = Console.ReadLine();

            if(read == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}