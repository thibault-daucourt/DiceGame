/*
 * ECOLE TECHNIQUE PORRENTRUY
 * Département informatique
 * 
 * Description  : Classe d'un objet Dé
 * Auteur       : Thibault Daucourt
 * Date         : 21.11.2018
 * Version      : 1.2
 * 
*/

using System;

namespace Dice_for_playing
{
    /// <summary>
    /// Classe qui représente un Dé à jouer
    /// A la création le nombre de face est ajustable
    /// </summary>
    class Dice
    {
        // Attributs
        private int numberSides = 1;
        private int visibleSide = 1;
        private static Random randomGenerator = new Random();

        // constructeurs
        /// <summary>
        /// Construit un dé selon les paramètre fournis ou non
        /// </summary>
        /// <param name="numberSides"> définit le nombre de face du dé à construire</param>
        /// <param name="visibleSide"> définit quel face doit être visible après la création du dé</param>
        public Dice(int numberSides = 6, int visibleSide = 1)
        {
            this.numberSides = numberSides;

            VisibleSide = visibleSide;
            VisibleSide = visibleSide;
        }

        // Mise en place de la propriété 'VisibleSide'
        public int VisibleSide
        {
            get
            {
                return visibleSide;
            }

            set
            {
                if (IsChosenSideValid(value))
                    visibleSide = value;
            }
        }

        // Mise en place de la propriété 'NumberSides'
        public int NumberSides
        {
            get
            {
                return numberSides;
            }
        }

        /// <summary>
        /// fait un jet de dé qui va attribué une valeur aléatoire entre 1 et le nombre de face compris
        /// </summary>
        public void Roll()
        {

            // Jete le dé et modifie la valeur de la face visible pour un nombre compris entre 1 et le nombre de face y compris
            visibleSide = randomGenerator.Next(1, numberSides + 1);
        }

        /// <summary>
        /// Véridie que la valeur voulue pour la face visible est bien correcte (compris entre 1 et le nombre de face)
        /// En cas de valeur int incorrect lève une exception qui explique quel est le problème
        /// </summary>
        /// <param name="chosenSide">La valeur de la face devant être vérifié</param>
        /// <returns></returns>
        private Boolean IsChosenSideValid(int chosenSide)
        {
            Boolean result = false;

            //  Vérification si la valeur fournie est invalide
            if (chosenSide > this.numberSides)
            {
                throw new System.ArgumentException("Parameter cannot be superior to the number of side", "visibleSide");
            }
            else if (chosenSide < 1)
            {
                throw new System.ArgumentException("Parameter cannot be inferior to 0", "visibleSide");
            }
            // Si la valeur fournis est valide, alors on valide la valeur pour la modification de l'attribut
            else
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// teste si la valeur voulu pour le nombre de face est valide
        /// lève une exception si elle est inférieur à 1
        /// 
        /// </summary>
        /// <param name="chosenNumberSides"></param>
        /// <returns>résultat du teste sous forme bouléen</returns>
        private Boolean IsChosenNumberSidesValid(int chosenNumberSides)
        {
            Boolean result = false;

            //  Vérification si la valeur fournie est invalide
            if (chosenNumberSides < 1)
            {
                throw new System.ArgumentException("Parameter cannot be inferior to 1", "NumberSides");
            }
            // Si la valeur fournis est valide, alors on valide la valeur pour la modification de l'attribut
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Compare cet objet Dé à un autre objet Dé fourni en paramètre
        /// </summary>
        /// <param name="otherDice"> L'autre dé qui doit être comparé à l'objet</param>
        /// <returns> Retourne vrais si l'objet est "identique" (le même nombre de faces et la même valeur visible) Sinon retourne faux</returns>
        public bool IsEquivalent(Dice otherDice)
        {
            //vérifie l'équivalence du nombre de face et de la valeur de la face visible entre les deux dés
            return (this.numberSides == otherDice.numberSides && this.visibleSide == otherDice.visibleSide);
        }
    }
}
