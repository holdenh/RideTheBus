using System;
using System.Collections.Generic;
using System.Text;

namespace RideTheBus

{
    class Card
    {
        //properties, all will be ENUMS.
        public Suit cardSuit { get; set; }
        public Value cardValue { get; set; }
        public Color cardColor { get; set; }

        // Constructor class.
        public Card (Suit suit, Value value)
        {
            this.cardSuit = suit;
            this.cardValue = value;

            // set the card color based on the given Suit.
            if (this.cardSuit.Equals(Suit.DIAMONDS)  || this.cardSuit.Equals(Suit.HEARTS))
            {   // set red if diamond or heart.
                this.cardColor = Color.RED;
            } 
            else
            {   // set black if club or spade
                this.cardColor = Color.BLACK;
            }
        }
        // ENUMS
        public enum Suit
        {
            DIAMONDS, HEARTS, CLUBS, SPADES
        }
        public enum Value
        {   // deck will be played with an ACE high of value 14.
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, 
            EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }
        public enum Color
        {
            RED, BLACK
        }

        // Method that will print a string version of the card object.
        public void toString()
        {   // print out value suit and color.
            Console.WriteLine("{0} of {1}({2})",this.cardValue, this.cardSuit, this.cardColor);
            return; 
        }
    }
}
