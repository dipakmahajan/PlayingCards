using PlayingCards.Enums;
using System;

namespace PlayingCards
{
    /// <summary>
    /// Class represeting playing card
    /// </summary>
    public class Card : IComparable<Card>
    {
        /// <summary>
        /// Gets the suit of card
        /// </summary>
        public Suits Suit { get; private set; }

        /// <summary>
        /// Gets the face value of card
        /// </summary>
        public FaceValues FaceValue { get; private set; }

        /// <summary>
        /// Initializes new instance of card
        /// </summary>
        /// <param name="suit">Suit of card</param>
        /// <param name="faceValue">face value of card</param>
        public Card(Suits suit, FaceValues faceValue)
        {
            this.Suit = suit;
            this.FaceValue = faceValue;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var faceValue = this.FaceValue > FaceValues.Ten ? this.FaceValue.ToString() : ((int)this.FaceValue).ToString();
            return $"{faceValue}{this.Suit}";
        }

        /// <inheritdoc/>
        public int CompareTo(Card other)
        {
            return this.FaceValue.CompareTo(other.FaceValue);
        }
    }
}
