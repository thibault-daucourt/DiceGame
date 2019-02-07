
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dice_for_playing
{
    abstract class Player
    {
        private string pseudo;
        private int score;

        private const int Min_Score = 0;
        

        public Player (string pseudo)
        {
            this.Pseudo = pseudo;
            this.Score = Min_Score;
        }

        public string Pseudo
        {
            get
            {
                return pseudo;
            }

            set
            {
                if (value != "")
                    pseudo = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }
        /// <summary>
        /// Le joueur décide s'il 
        /// </summary>
        /// <param name="Opponent"></param>
        /// <returns></returns>
        public abstract bool RollDice(int points,int opponentScore);

        public void Reset()
        {
            Score = Min_Score;
        }
    }
}