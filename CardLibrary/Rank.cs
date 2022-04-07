/**
 * Rank.cs - Enumeration of the Ranks of a standard deck of Cards.
 *   
 * @author      Connor Simmonds-Parke
 * @author
 * @author
 * @version     1.0
 * @since       Feb 20, 2021
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace CardLibrary
{
    /// <summary>
    /// Holds the rank name/value of a standard deck of Cards. Ace is set as lowest by default, King highest.
    /// </summary>
    public enum Rank
    { 
        Deuce = 1,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
