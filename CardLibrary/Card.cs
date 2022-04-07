/**
 * Card.cs - A standard playing card.
 *   
 * @author      Connor Simmonds-Parke
 * @author
 * @author
 * @version     1.0
 * @since       Feb 22, 2021
 */

using System;
using System.Drawing;

namespace CardLibrary
{
    /// <summary>
    /// A single playing card. Takes the Rank and Suit from the respective classes.
    /// </summary>
    public class Card : ICloneable
    {
        public Rank rank; //Rank/value of the card.
        public Suit suit; //Suit of the card.
        public bool faceUp; //Face-up value of the card.

        /// <summary>
        /// Flag for trump usage. If true, trumps are valued higher
        /// than cards of other suits.
        /// </summary>
        public static bool useTrumps = false;

        /// <summary>
        /// Trump suit to use if useTrumps is true.
        /// </summary>
        public static Suit trump = Suit.Club;

        /// <summary>
        /// Flag that determines whether aces are higher than kings or lower
        /// than deuces.
        /// </summary>
        public static bool isAceHigh = true;


        //Default Constructor
        public Card()
        {
            this.suit = Suit.Club;
            this.rank = Rank.Deuce;
            this.faceUp = false;
        }

        /// <summary>
        /// Creates a new card with a specific Suit and Rank
        /// </summary>
        /// <param name="newSuit">Suit of a card</param>
        /// <param name="newRank">Rank of a card</param>
        public Card(Suit newSuit, Rank newRank)
        {
            this.suit = newSuit;
            this.rank = newRank;
            this.faceUp = true;
        }

        //Clone
        public object Clone()
        {
            return MemberwiseClone();
        }

        //Operators and Overrides
        public override string ToString()
        {
            string returnString;

            if (faceUp == true)
            {
                returnString = "The " + rank + " of " + suit + "s";
            }
            else
            {
                returnString = "Face Down";
            }

            return returnString;
        }

        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.suit == card2.suit) && (card1.rank == card2.rank);
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        public override int GetHashCode()
        {
            return 13 * (int)suit + (int)rank;
        }

        public static bool operator >(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank > card2.rank);
                    }
                }
                else
                {
                    return (card1.rank > card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

        public static bool operator >=(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank >= card2.rank);
                    }
                }
                else
                {
                    return (card1.rank >= card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }

        public Image GetCardImage()
        {
            string imageName;
            Image cardImage;
            Size size = new Size(75, 107);

            if (!faceUp)
            {
                imageName = "Back";
            }
            else
            {
                imageName = suit.ToString() + "_" + rank.ToString();
            }

            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;

            //Returns a new image of a card, and re-sizes it to whatever is needed.
            return (Image)(new Bitmap(cardImage, size));
        }
    }
}
