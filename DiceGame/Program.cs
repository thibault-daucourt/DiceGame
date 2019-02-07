/*
 * ECOLE TECHNIQUE PORRENTRUY
 * Département informatique
 * 
 * Description  : Manipulation d'un Dé et affiche le résultat dans la console
 * Auteur       : Thibault Daucourt
 * Date         : 21.11.2018
 * Version      : 1.0
 * 
*/

using System;

/// <summary>
/// Programme jetant un dé jusqu'à obtenir 3 fois d'affilé la valeur 6
/// Une fois cette condition satisfaite, affiche le nombre de jet nécessaire
/// </summary>
namespace Dice_for_playing
{
    class Program
    {
        static void Main(string[] args)
        {

            Jeu monJeu = new Jeu();
            monJeu.startAGame();

        }
    }
}
