using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dice_for_playing
{
    class Jeu
    {
        private Dice dice1;

        private Dice dice2;

        private Player playerHuman;

        private Player playerRobot;

        private Queue<Player> order;

        private int points;
        public void startAGame()
        {
            // create players and dices
            playerHuman = null;
            playerRobot = null;

            dice1 = new Dice(6);
            dice2 = new Dice(6);

            Console.WriteLine("Bienvenu au jeu de dé !");
            Console.WriteLine("Une nouvelle partie commence !");

            // choose first player
            order = new Queue<Player>();
            int first = new Random().Next(2);
            if(first == 0)
            {
                order.Enqueue(playerHuman);
                order.Enqueue(playerRobot);
            }else
            {
                order.Enqueue(playerRobot);
                order.Enqueue(playerHuman);
            }


            do
            {


            } while (playerHuman.Score < 5 || playerRobot < 5);
        }

        public void Round(Player player1, Player player2)
        {

            points = 0;


        }
    }
}