using System.Collections.Generic;

namespace Blackjack.Classes
{
    public class Player
    {
        public string Name { get; protected set; }

        public List<Card> Hand { get; set; }

        //HandTotal adds up value for each card in player's hand
        //if using value 11 for ace causes player to go bust, use value 1 for Ace instead
        public int HandTotal
        {
            get
            {
                int handTotal = 0;
                int bustAboveValue = 21;
                int switchAceValue = 10;

                foreach (Card card in Hand)
                {
                    handTotal += card.Value;
                }

                if (handTotal > bustAboveValue)
                {
                    foreach (Card card in Hand)
                    {
                        if (card.Rank == "Ace")
                        {
                            handTotal -= switchAceValue;
                        }
                    }
                }
                return handTotal;
            }
        }
        public Player(string name)
        {
            this.Name = name;
            this.Hand = new List<Card>();
        }

        //when player hits, the top (i.e. last) card in the deck is added to their hand
        public Card Hit(Deck deck)
        {
            Card hitCard = deck.DealCard();
            Hand.Add(hitCard);

            return hitCard;
        }
    }
}
