using DiceGame;
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

        public void startAGame()
        {
            // create players and dices
            playerHuman = new HumanPlayer("Sagarion");
            playerRobot = new RobotPlayer("Robi");

            dice1 = new Dice(6);
            dice2 = new Dice(6);

            int round = 0;

            Player player1;
            Player player2;

            Console.WriteLine("Bienvenu au jeu de dé !");
            Console.WriteLine("Une nouvelle partie commence !");
            Console.WriteLine("----\n");

            // Détermine qui joue en premier
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

            
            // boucle de Round du jeu
            do
            {
                // incrémente le compteur de round
                round++;

                // sélectionne les joueurs dans l'ordres
                player1 = order.Dequeue();
                player2 = order.Dequeue();

                Console.WriteLine("Round ({0}) : joueur {1} commence !",round,player1.Pseudo);

                // joue le rounds
                Round(player1, player2);

                // affichage des score après ce Round
                Console.WriteLine("Score actuel du joueur {0} : {1}", playerHuman.Pseudo, playerHuman.Score);
                Console.WriteLine("Score actuel du joueur {0} : {1}", playerRobot.Pseudo, playerRobot.Score);
                Console.WriteLine("---\n");

                // replace dans la queue en intervertissant l'ordre
                order.Enqueue(player2);
                order.Enqueue(player1);


            } while (playerHuman.Score < 5 && playerRobot.Score < 5);

            Console.WriteLine("\nLa partie s'est terminée et nous avons un vainqueur !");
            if(playerHuman.Score >= 5)
                Console.WriteLine("Le joueur humaine {0} à gagné sur un Score de {1} !!", playerHuman.Pseudo, playerHuman.Score);
            else
                Console.WriteLine("Le joueur robotique {0} à gagné sur un Score de {1} !!", playerRobot.Pseudo, playerRobot.Score);
        }

        private void Round(Player player1, Player player2)
        {
            int points = 0;

            int turn = 0;

            bool player1Surender = false;
            bool player2Surender = false;

            do
            {
                turn++;

                //joueur 1
                if (turn % 2 == 1)
                {
                    // joue la manche
                    if (player1.RollDice(points, player2.Score))
                    {
                        Console.WriteLine("Joueur {0} roule les dés ... ", player1.Pseudo);
                        dice1.Roll();
                        dice2.Roll();

                        points += dice1.VisibleSide + dice2.VisibleSide;
                        Console.WriteLine("Il fait {0} et {1} ! le nombre de point actuelle est de {2}", dice1.VisibleSide, dice2.VisibleSide, points);
                    }
                    // abandonne la manche
                    else
                    {
                        player1Surender = true;
                        Console.WriteLine("Joueur {0} abandonne ...", player1.Pseudo);
                    }
                }
                //joueur 2
                else
                {
                    // joue la manche
                    if (player2.RollDice(points, player1.Score))
                    {
                        Console.WriteLine("Joueur {0} roule les dés ... ", player2.Pseudo);
                        dice1.Roll();
                        dice2.Roll();

                        points += dice1.VisibleSide + dice2.VisibleSide;
                        Console.WriteLine("Il fait {0} et {1} ! le nombre de point actuelle est de {2}", dice1.VisibleSide, dice2.VisibleSide, points);
                    }
                    // abandonne la manche
                    else
                    {
                        player2Surender = true;
                        Console.WriteLine("Joueur {0} abandonne ...", player2.Pseudo);
                    }
                }

            } while (!player1Surender && !player2Surender && points < 21);

            Console.WriteLine("Round terminé");

            // calcule du résultat

            // si abandon 
            if (player1Surender)
            {
                player2.Score += 1;
                Console.WriteLine("Le joueur {0} gagne 1 point suite à l'abandon de {1}", player2.Pseudo, player1.Pseudo);
            }
            else if (player2Surender)
            {
                player1.Score += 1;
                Console.WriteLine("Le joueur {0} gagne 1 point suite à l'abandon de {1}", player1.Pseudo, player2.Pseudo);
            }
            // si total de points dépassé
            else
            {
                // selon le tour, rétribue le joueur qui n'a pas joué en dernier
                if (turn % 2 == 1)
                {
                    player2.Score += 2;
                    Console.WriteLine("Le joueur {0} à dépassé 21", player1.Pseudo);
                    Console.WriteLine("Le joueur {0} gagne 2 points", player2.Pseudo);
                }
                else
                { 
                    player1.Score += 2;
                    Console.WriteLine("Le joueur {0} à dépassé 21", player2.Pseudo);
                    Console.WriteLine("Le joueur {0} gagne 2 points", player1.Pseudo);
                }
            }

            Console.WriteLine("Ce round est terminé !\n");

        }
    }
}