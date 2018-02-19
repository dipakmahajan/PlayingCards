using System;
using System.Collections.Generic;
using System.Text;

namespace PlayingCards
{
    /// <summary>
    /// Main Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Program entry point
        /// </summary>
        /// <param name="args">program arguments</param>
        static void Main(string[] args)
        {
            var deck = Deck.GetDeck;

            var continuePlaying = "Y";
            while (continuePlaying.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                int numberOfPlayers = GetNumberOfPlayers();
                var hands = InitializeHands(numberOfPlayers);
                deck.Shuffle();
                DealCards(deck, hands);

                WriteHands(hands);
                Console.WriteLine("Do you want to deal again?");
                continuePlaying = Console.ReadLine();
            }

            Console.WriteLine("Thank you for playing. Press any key to exit.");
            Console.Read();
        }

        /// <summary>
        /// Gets number of players to deal
        /// </summary>
        /// <returns></returns>
        private static int GetNumberOfPlayers()
        {
            int numberOfPlayers = -1;
            while (numberOfPlayers < 2 || numberOfPlayers > 10)
            {
                Console.WriteLine("How many players to deal (please only enter a number from 2 to 10)?");
                try
                {
                    numberOfPlayers = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please provide number only.");
                }
            }

            return numberOfPlayers;
        }

        /// <summary>
        /// Writes the hands
        /// </summary>
        /// <param name="hands">The hands</param>
        private static void WriteHands(IList<Hand> hands)
        {
            var output = new StringBuilder();
            foreach (var hand in hands)
            {
                output.AppendLine(hand.ToString());
            }

            Console.Write(output);
            FileOperations.WriteTextFile(output.ToString());
        }

        /// <summary>
        /// Deals cards from the deck to hands
        /// </summary>
        /// <param name="deck">Deck</param>
        /// <param name="hands">Initialized hands</param>
        private static void DealCards(Deck deck, IList<Hand> hands)
        {
            var cardNumber = 0;
            // Deal 5 cards in total to each hand
            for (int numberOfCards = 0; numberOfCards < 5; numberOfCards++)
            {
                // Deal a card to each hand
                foreach (var hand in hands)
                {
                    hand.DealCard(deck.DrawCard(cardNumber));
                    cardNumber++;
                }
            }
        }

        /// <summary>
        /// Initilizes the hands for given number of players
        /// </summary>
        /// <param name="numberOfPlayers">Number of players</param>
        /// <returns>Initialized hands</returns>
        /// <exception cref="ArgumentException">If number of players is less than 2 or more than 10</exception>
        private static IList<Hand> InitializeHands(int numberOfPlayers)
        {
            if (numberOfPlayers < 2 || numberOfPlayers > 10)
            {
                throw new ArgumentException("Number of players should be more than 1, but cannot exceed 10.");
            }

            var hands = new List<Hand>();
            for (int iterator = 1; iterator <= numberOfPlayers; iterator++)
            {
                hands.Add(new Hand(iterator));
            }

            return hands;
        }
    }
}
