/**
 * Deck.cs - A deck (collection) of standard playing card.
 *   
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
using System.Linq;

namespace CardLibrary
{
    public class Deck : ICloneable
    {
        /// <summary>
        /// The collection of cards without the Deck functionality
        /// </summary>
        private Cards cards = new Cards();

        /// <summary>
        /// Number of cards left in the deck
        /// </summary>
        private int cardsLeftInDeck;

        /// <summary>
        /// Default Constructor. Creates a deck of 52 cards
        /// </summary>
        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                    cardsLeftInDeck++;
                }
            }
        }

        /// <summary>
        /// Constructs a deck based on a collection of cards
        /// </summary>
        /// <param name="newCards">Collection of cards</param>
        private Deck(Cards newCards)
        {
            cards = newCards;
        }

        /// <summary>
        /// Creates a new deck of 20, 36, or 52
        /// </summary>
        /// <param name="deckSize">The deck size</param>
        public Deck(int deckSize)
        {
            //Creates a deck of 20 with ranks 10 - Ace
            if (deckSize == 20)
            {
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    for (int rankVal = 9; rankVal < 14; rankVal++)
                    {
                        cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                        cardsLeftInDeck++;
                    }
                }
            }
            //Creates a deck of 36 with ranks 6 - Ace
            else if (deckSize == 36)
            {
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    for (int rankVal = 5; rankVal < 14; rankVal++)
                    {
                        cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                        cardsLeftInDeck++;
                    }
                }
            }
            //Creates a deck of 52 with ranks 2 - Ace
            else
            {
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    for (int rankVal = 1; rankVal < 14; rankVal++)
                    {
                        cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                        cardsLeftInDeck++;
                    }
                }
            }
        }


        /// <summary>
        /// Nondefault constructor. Allows aces to be set high.
        /// </summary>
        public Deck(bool isAceHigh)
           : this()
        {
            Card.isAceHigh = isAceHigh;
        }

        /// <summary>
        /// Nondefault constructor. Allows a trump suit to be used.
        /// </summary>
        public Deck(bool useTrumps, Suit trump)
           : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        /// <summary>
        /// Nondefault constructor. Allows aces to be set high and a trump suit
        /// to be used.
        /// </summary>
        public Deck(bool isAceHigh, bool useTrumps, Suit trump)
           : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        /// <summary>
        /// Find a specific card
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns>The card</returns>
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
                return cards[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
                          "Value must be between 0 and 51."));
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        /// <param name="deckSize">The size of the deck</param>
        public void Shuffle(int deckSize)
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[deckSize];
            Random sourceGen = new Random();
            for (int i = 0; i < deckSize; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(deckSize);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }

        /// <summary>
        /// Clones the deck
        /// </summary>
        /// <returns>A new deck with the same cards</returns>
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }

        /// <summary>
        /// Allows a card to used with foreach loops
        /// </summary>
        /// <returns>The card</returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            foreach (Card card in cards)
            {
                yield return card;
            }
        }

        /// <summary>
        /// Draws the first card in the deck
        /// </summary>
        /// <returns>The first card in the deck</returns>
        public Card Draw()
        {
            Card drawCard = cards.ElementAt(0);
            cards.Remove(drawCard);
            cardsLeftInDeck--;

            return drawCard;
        }

        /// <summary>
        /// Returns a card back into the deck
        /// </summary>
        /// <param name="cardToReturn">The card to be returned to the deck</param>
        public void ReturnToDeck(Card cardToReturn)
        {
            cardsLeftInDeck++;
            cards.Add(cardToReturn);
        }

        /// <summary>
        /// Gets the number of cards left in the deck
        /// </summary>
        /// <returns>Number of cards in the deck</returns>
        public int GetCardsLeft()
        {
            return this.cardsLeftInDeck;
        }

    }
}
