using System;
using System.Collections.Generic;
using System.Text;

namespace RideTheBus
{
    class Deck
    {
        /**
         * properies
         *      cards:              the 52 playable Card objects within the Deck        TYPE: List<Card>
         *      initialized:        holds the readiness state of the Deck.              TYPE: boolean
         *      shuffled:           holds the shuffled state of the Deck                TYPE: boolean
         *      currentCard:        index of the current top card of the Deck           TYPE: int
         *      rand:               property that will be used to shuffle the Deck      TYPE: Random
         */
        public List<Card> cards { get; set; }
        public bool initialized { get; private set; }
        public bool shuffled { get; private set; }
        public int numShuffles { get; private set; }
        public int currentCard { get; private set; }
        public int totalCardCount { get; private set; }

        // Constructor Class
        public Deck (int numShuffles)
        { // initialize the deck and then shuffle
            Console.WriteLine("Deck initialization: {0}\t Shuffled: {1}\n", this.initialized, this.shuffled);
            this.numShuffles = numShuffles;

            initialize();
            Console.WriteLine("Deck initialization: {0}\t Shuffled: {1}\n", this.initialized, this.shuffled);
            if (this.initialized == true)
            {
                shuffle(this.numShuffles);
            }
            Console.WriteLine("Deck initialization: {0}\t Shuffled: {1}\n", this.initialized, this.shuffled);
        }

        /** Method that will create fifty two cards with values 2-14 and all four cards suits.
         *      this method will not shuffle the deck, but it will set the decks local initialized variable to true 
         *      if the deck has created 52 cards.
         */
        public void initialize()
        { 
            this.totalCardCount = 0;                      // local variable to check card count.
            this.currentCard = 0;                   // initialize currentCard to top of the deck.
            this.cards = new List<Card>();          // initialize the current "deck" to be an empty List<Card>
            this.shuffled = false;                  // base decks will not be shuffled by default.  Relevant to handle the making of new decks.
            this.initialized = false;               // base decks will not be initialized by default. Relevant to handle the making of new decks.
            
            // Use a nested loop to go through each suit and value to creat a new card object.
            foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Value value in Enum.GetValues(typeof(Card.Value)))
                {   // create the new card, add the card to the deck, add 1 to the local this.totalCardCount.
                    Card newCard = new Card(suit, value);
                    addCard(newCard);
                    this.totalCardCount++;

                }
            }
            // check if the deck has the full 52 cards.
            if (this.totalCardCount == 52)
            {  
                this.initialized = true;
            }
            return;
        }
        /* method that takes the Deck's Random variable ojects as an arguement
         *      method will use this rand object to obtain a next random number to shuffle.
         *      will take one arguement, counter, to shuffle a specified number of times.
         */  
        public void shuffle(int count)
        {
            Random rand = new Random();
            int currCount = 0;
            while (currCount < count)
            {
                for (int i = 0; i < this.totalCardCount; i++)
                {   // get a random number that is i < 52, so to remain inbounds. 
                    int randCardIndex = rand.Next(52 - i);
                    Card tempCard = this.cards[randCardIndex];
                    this.cards[randCardIndex] = this.cards[i];
                    this.cards[i] = tempCard;
                }
                Console.WriteLine("Shuffle Count: {0}", currCount + 1);
                currCount++;
            }
            this.shuffled = true;
            Console.WriteLine();
        }
        // method that adds a Card to the Deck.
        public void addCard(Card theCard)
        {
            cards.Add(theCard);
            return;
        }
        // method that displays the top Card of the Deck in a displaying action.
        public Card discard()
        {   // get the current top card, call its toString method, and increment currentCard.
            if (currentCard == 52)
            {
                Console.WriteLine("\nDeck is out of cards and must be reshuffled. Default is five shuffles.");
                this.initialize();
                this.shuffle(5);
            }
            Card discard = this.cards[currentCard];
            discard.toString();
            Console.WriteLine("Discarded.");
            currentCard++;
            return discard;
        }
        // method that loops through the deck to display the cards. 
        public void printDeck()
        {
            Console.WriteLine();
            foreach (Card card in cards)
            {   // call the Card ojects overridden toString() method.
                card.toString();
            }
            Console.WriteLine();
            return;
        }
    }
}
