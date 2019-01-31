using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_for_playing
{
    class Application
    {
        /// <summary>
        /// Programme jetant un dé jusqu'à obtenir 3 fois d'affilé la valeur 6
        /// Une fois cette condition satisfaite, affiche le nombre de jet nécessaire
        /// </summary>
        public static void  GetThreeSixInARow()
        {
            // créer un dé
            Dice myDice = new Dice(6, 1);


            //nombe de 6 sorti d'affilé
            int countSix = 0;
            //nombre de jet total
            int countTotal = 0;

            do
            {
                // Action de la boucle
                myDice.Roll();
                countTotal += 1;

                if (myDice.VisibleSide == 6)
                {
                    countSix += 1;
                }
                else
                {
                    countSix = 0;
                }
                // controle affichage de la valeur courrante du dé
                Console.WriteLine("valeur courrante du dé : " + myDice.VisibleSide);
            } while (countSix != 3);

            // Affichage du message final de l'application (nombre de tentative)
            Console.WriteLine("It took " + countTotal + " rolls to get the value 6 three times in row !!");
        }

        /// <summary>
        /// Programme lançant deux dés jusqu'à obtenir une paire
        /// Une fois une paire obtenu, affiche le nombre de lancé nécessaire
        /// </summary>
        public static void GetAPair()
        {
            // créer deux dés
            Dice myFirstDice = new Dice(6, 1);
            Dice mySecondDice = new Dice(6, 1);


            //nombre de jet total
            int countTotal = 0;


            do
            {
                // Action de la boucle
                myFirstDice.Roll();
                mySecondDice.Roll();

                countTotal++;

                // controle affichage de la valeur courrante des dés
                Console.WriteLine("valeur courrante du dé numéro 1  : " + myFirstDice.VisibleSide +
                    "   valeur courrante du dé numéro 2  : " + mySecondDice.VisibleSide);

            } while (!myFirstDice.IsEquivalent(mySecondDice));

            // Affichage du message final de l'application (nombre de tentative)
            Console.WriteLine("It took " + countTotal + " rolls to get a pair of " + myFirstDice.VisibleSide + " !!");
        }
    }
}
