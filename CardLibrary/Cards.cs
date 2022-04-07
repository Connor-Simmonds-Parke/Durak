/**
 * Cards.cs - A list/collection of standard playing card.
 *   
 * @author      Connor Simmonds-Parke
 * @author
 * @author
 * @version     1.0
 * @since       Feb 24, 2021
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace CardLibrary
{
    public class Cards : List<Card>, ICloneable
    {
        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        /// </summary>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }


    }
}