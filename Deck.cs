using PlayingCards.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayingCards
{
    /// <summary>
    /// Class representing deck of playing cards
    /// </summary>
    public class Deck
    {
        private static Deck instance;

        /// <summary>
        /// Gets or sets the cards
        /// </summary>
        public IList<Card> Cards { get; set; }

        /// <summary>
        /// Initializes new instance of deck
        /// </summary>
        private Deck()
        {
            // Generate the deck out of all values of suits and face values
            var suits = Enum.GetValues(typeof(Suits)).Cast<Suits>();
            var faceValues = Enum.GetValues(typeof(FaceValues)).Cast<FaceValues>();
            var result = from su in suits
                         from fv in faceValues
                         select new Card(su, fv);
            this.Cards = result.ToList();
        }

        /// <summary>
        /// Gets the singleton instance of Deck
        /// </summary>
        public static Deck GetDeck
        {
            get
            {
                if (instance == null)
                {
                    instance = new Deck();
                }

                return instance;
            }
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void Shuffle()
        {
            var randomGenerator = new Random();
            var cardCount = this.Cards.Count;
            for (int iterator = 0; iterator < this.Cards.Count; iterator++)
            {
                // Get a random swapIndex
                int swapIndex = randomGenerator.Next(iterator, cardCount);

                // Swap card at swapIndex with current card in the iteration
                var temp = this.Cards[swapIndex];
                this.Cards[swapIndex] = this.Cards[iterator];
                this.Cards[iterator] = temp;
            }
        }

        /// <summary>
        /// Draws the card from deck
        /// </summary>
        /// <param name="cardNumber">Index of drawn card</param>
        /// <returns>Drawn card</returns>
        public Card DrawCard(int cardNumber)
        {
            return this.Cards.ElementAt(cardNumber);
        }
    }
}
