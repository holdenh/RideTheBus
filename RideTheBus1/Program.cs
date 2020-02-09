using System;

namespace RideTheBus
{
    class Program
    {
        /*method to play the first round of the game.
         *      takes in a Deck as arguement.
         *      returns true of false */
        public static bool playRoundOne(Deck deck)
        {       // red or black
            Console.WriteLine("\nROUND ONE");
            bool roundWon = false;
            // take user input
            Console.Write("Red(r) or Black(b)? : ");
            string firstGuess = Console.ReadLine();
            // draw a card and evaluate the user input.
            Card currentCard = deck.discard();
            switch (firstGuess.ToUpper())
            {
                case "R":       // user guess is RED, if currentCard is RED then correct.
                    if (currentCard.cardColor.Equals(Card.Color.RED))
                    {
                        roundWon = true;
                        Console.WriteLine("\t\tCORRECT!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                    }
                    break;
                case "B":       // user guess is BLACK, if currentCard is BLACK then correct.
                    if (currentCard.cardColor.Equals(Card.Color.BLACK))
                    {
                        roundWon = true;
                        Console.WriteLine("\t\tCORRECT!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                    }
                    break;
            }
            return roundWon;
        }
        /*method to play the Second round of the game.
         *      takes in a Deck as arguement.
         *      returns true of false */
        public static bool playRoundTwo(Deck deck)
        {     // higher or lower.
            Console.WriteLine("\nROUND TWO");
            bool roundWon = false;
            // store the last card to be drawn (top of the discard pile), and user user input.
            Card lastCard = deck.cards[deck.currentCard - 1];
            Console.Write("Higher(h) or Lower(l) than {0}? : ", lastCard.cardValue);
            string firstGuess = Console.ReadLine();
            // draw another card from the top of the deck and evaluate the user input.
            Card currentCard = deck.discard();
            switch (firstGuess.ToUpper())
            {
                case "H":       // user guess HIGHER, if currentCard.Cardvalue > lastCard.CardValue then correct.
                    if (currentCard.cardValue.CompareTo(lastCard.cardValue) > 0)
                    {
                        roundWon = true;
                        Console.WriteLine("\t\tCORRECT!");
                    }
                    else
                    {
                        Console.WriteLine("\t\tIncorrect.");
                    }
                    break;
                case "L":       // user guess LOWER, if currentCard.Cardvalue < lastCard.CardValue then correct.
                    if (currentCard.cardValue.CompareTo(lastCard.cardValue) < 0)
                    {
                        roundWon = true;
                        Console.WriteLine("\t\tCORRECT!");
                    }
                    else
                    {
                        Console.WriteLine("\t\tIncorrect.");
                    }
                    break;
            }
            return roundWon;
        }
        /*method to play the third round of the game.
         *      takes in a Deck as arguement.
         *      returns true of false */
        public static bool playRoundThree(Deck deck)
        {     // inside or outside.
            Console.WriteLine("\nROUND THREE");
            bool roundWon = false;
            /* Stroe the first two cards and take user input*/
            Card lastCard = deck.cards[deck.currentCard - 1];
            Card secondToLastCard = deck.cards[deck.currentCard - 2];
            Console.Write("Inside(i) or Outside(o) of {0} and {1}? : ", lastCard.cardValue, secondToLastCard.cardValue);
            string firstGuess = Console.ReadLine();
            // draw the next card from the top of the deck, and evaluate the user input.
            Card currentCard = deck.discard();
            switch (firstGuess.ToUpper())
            {
                case "I":       // user guessed inside. Value will be only greater than one of the last two cards.
                    if ((currentCard.cardValue > lastCard.cardValue & currentCard.cardValue < secondToLastCard.cardValue) |
                        (currentCard.cardValue < lastCard.cardValue & currentCard.cardValue > secondToLastCard.cardValue))
                    {
                        roundWon = true;
                        Console.WriteLine("\t\tCORRECT!");
                    }
                    else
                    {
                        Console.WriteLine("\t\tIncorrect.");
                    }
                    break;
                case "O":       // user guessed outside. Value will be > or < both cards.
                    if ((currentCard.cardValue > lastCard.cardValue & currentCard.cardValue > secondToLastCard.cardValue) |
                        (currentCard.cardValue < lastCard.cardValue & currentCard.cardValue < secondToLastCard.cardValue))
                    {
                        roundWon = true;
                        Console.WriteLine("\t\tCORRECT!");
                    }
                    else
                    {
                        Console.WriteLine("\t\tIncorrect.");
                    }
                    break;
            }
            return roundWon;
        }
        /*method to play the fourth round of the game.
         *      takes in a Deck as arguement.
         *      returns true of false */
        public static bool playRoundFour(Deck deck)
        {       // final Round, Guess Suit.
            Console.WriteLine("\nROUND FOUR");
            bool roundWon = false;
            // take user input 
            Console.Write("Next Card Suit? \nDiamonds(d), Spades(s), Hearts(h), or Clubs(c) : ");
            string firstGuess = Console.ReadLine();
            // draw the top card from the deck and evaluate the user input.
            Card currentCard = deck.discard();
            switch (firstGuess.ToUpper())
            {
                case "D":       // user guess was DIAMONDS, if currentCard.cardSuit == DIAMONDS then correct.
                    if (currentCard.cardSuit.Equals(Card.Suit.DIAMONDS))
                    {
                        roundWon = true;
                        Console.WriteLine("\t\tCORRECT!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                    }
                    break;
                case "S":       // user guess was SPADES, if currentCard.cardSuit == SPADES then correct.
                    if (currentCard.cardSuit.Equals(Card.Suit.SPADES))
                    {
                        roundWon = true;
                        Console.WriteLine("\t\tCORRECT!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                    }
                    break;
                case "H":       // user guess was HEARTS, if currentCard.cardSuit == HEARTS then correct.
                    if (currentCard.cardSuit.Equals(Card.Suit.HEARTS))
                    {
                        roundWon = true;
                        Console.WriteLine("\t\tCORRECT!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                    }
                    break;
                case "C":       // user guess was CLUBS, if currentCard.cardSuit == CLUBS then correct.
                    if (currentCard.cardSuit.Equals(Card.Suit.CLUBS))
                    {
                        roundWon = true;
                        Console.WriteLine("\t\tCORRECT!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                    }
                    break;
            }
            return roundWon;
        }
        /* Method that holds the outer flow control for the game.
         *      takes a Deck as an arguement
         *      returns a true or false variable. (Could probably be removed since to win you must pass all four rounds.)
         */
        public static bool playGame(Deck deck)
        {

            // variables to hold the round states.
            bool winner = false;
            bool round1 = false;
            bool round2 = false;
            bool round3 = false;
            bool round4 = false;
            int cardsDrawn = 0;
            while (!winner)
            {       // restart at ROUND ONE if any round is lost.
                round1 = playRoundOne(deck);
                cardsDrawn++;
                if (round1 == true)
                {       // proceed to ROUND TWO
                    round2 = playRoundTwo(deck);
                    cardsDrawn++;
                    if (round2 == true)
                    {       // proceed to ROUND THREE
                        round3 = playRoundThree(deck);
                        cardsDrawn++;
                        if (round3 == true)
                        {       // proceed to ROUND FOUR
                            round4 = playRoundFour(deck);
                            cardsDrawn++;
                            if (round4 == true)
                            {       // PLAYER WON THE GAME!
                                winner = true;      // exit the while loop.
                            }
                        }
                    }
                }
            }
            // display how may cards were used during this game session.
            Console.WriteLine("It took you {0} cards in total to EXIT THE BUS!!", cardsDrawn);
            return winner;
        }
        static void Main(string[] args)
        {
            bool isWinner = false;
            // take user input.
            while (!isWinner)
            {
                Console.WriteLine("You are now RIDING THE BUS! \n");
                Console.WriteLine("Displaying Rules. . .\n");

                Console.Write("How many times would you like to shuffle? (1-10) : ");
                int numShuffles = Convert.ToInt32(Console.ReadLine());

                // initialize the deck with the number of shuffles.
                Deck myDeck = new Deck(numShuffles);
                // play the game, this will hold the exit state for the while loop.
                isWinner = playGame(myDeck);
            }
            Console.WriteLine("Game WON!!!");       // Display the Victory MSG, possibly resize.
            Console.ReadKey();
        }
    }
}
