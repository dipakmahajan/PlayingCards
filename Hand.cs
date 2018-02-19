using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayingCards
{
    /// <summary>
    /// Class representing hand of playing cards
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// Gets or sets the player number to whom hand belongs to
        /// </summary>
        public int PlayerNumber { get; private set; }

        /// <summary>
        /// Gets the cards in the hand
        /// </summary>
        public IList<Card> Cards { get; private set; }

        /// <summary>
        /// Initializes new instance of hand
        /// </summary>
        /// <param name="playerNumber">Player number</param>
        public Hand(int playerNumber)
        {
            this.PlayerNumber = playerNumber;
            this.Cards = new List<Card>();
        }

        /// <summary>
        /// Deals a card to the hand
        /// </summary>
        /// <param name="card">The card to deal</param>
        /// <exception cref="InvalidOperationException">Exception is thrown if hand already has 5 cards</exception>
        public void DealCard(Card card)
        {
            if(this.Cards.Count == 5)
            {
                throw new InvalidOperationException("Hand already has 5 cards. Cannot deal more cards");
            }


            this.Cards.Add(card);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            // No check for count of cards in hand, since ToString can be used to get string value of partial hand as well, if needed.
            var orderedHand = this.Cards.OrderBy(c => c.FaceValue).ToList();
            return $"Player #{PlayerNumber}: {string.Join("-", orderedHand)}";
        }
    }
}
