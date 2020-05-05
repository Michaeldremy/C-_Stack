using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{

class Card
{

// Give the Card class a property "stringVal" which will hold the value of the card ex. 
// (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). This "val" should be a string.
// Give the Card a property "suit" which will hold the suit of the card (Clubs, Spades, Hearts, Diamonds).
// Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers.
    public string StringVal;
    public string Suit;
    public int Val;

    public Card(string nameOfCards, string cardType, int valueOfCard)
    {
        StringVal = nameOfCards;
        Suit = cardType;
        Val = valueOfCard;
    }
}

class Deck
{
    public List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
        string[] stringValArray = {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
        string[] cardTypeArray = {"Clubs","Spades","Hearts","Diamonds"};
        int[] valueOfCardArray = {1,2,3,4,5,6,7,8,9,10,11,12,13};

        for (int i = 0; i < stringValArray.Length; i++)
        {
            for (int j = 0; j < cardTypeArray.Length; j++)
            {
                Card oneCard = new Card(stringValArray[i],cardTypeArray[j],valueOfCardArray[i]);
                cards.Add(oneCard);
            }
        }
    }
    public Card Deal()
    {
        Card removeCard = cards[0];
        cards.RemoveAt(0);
        return removeCard;
    }
    public void Reset()
    {
        Deck newDeck = new Deck();
        cards = newDeck.cards;
    }
    public void Shuffle()
    {
        Random rand = new Random();
        for (int i = 0; i < cards.Count ;i++)
        {
            int r = i + rand.Next(52 - i);
            Card temp = cards[r];
            cards[r] = cards[i];
            cards[i] = temp;
        }
    }
    public void DisplayDeck()
    {
            foreach (Card i in cards)
        {
            System.Console.WriteLine($"{i.StringVal} - {i.Suit} of {i.Val}");
        }
    }
}

class Player
{
    public string Name;
    public List<Card> Hand;

    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
    }

    public Card Draw(Deck deck)
    {
        Card addCardToHand = deck.Deal();
        Hand.Add(addCardToHand);
        return addCardToHand;
    }

    // public Card Discard(Deck Card)
    // {
        
    // }
}

    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player ("Michael");
            System.Console.WriteLine($"Welcome to the game {p1.Name}!");
            Deck d1 = new Deck ();
            d1.DisplayDeck();
            d1.Deal();
            d1.DisplayDeck();
            d1.Reset();
            d1.DisplayDeck();
            Card p1Draw = p1.Draw(d1);
            System.Console.WriteLine($"{p1Draw.StringVal} of {p1Draw.Suit} #{p1Draw.Val}");

        }
    }
}