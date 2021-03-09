using System.Collections.Generic;

namespace Blackjack.Classes
{
    public class Dealer : Player
    {
        public Dealer(string name) : base(name)
        {
            this.Hand = new List<Card>();
        }

        //dealer is dealt first card face down 
        //we do not see this card until the dealer begins their turn, so all we know about dealer's hand until then is what they are showing
        public int ShowingTotal
        {
            get
            {
                return HandTotal - Hand[0].Value;
            }
        }

        //checks if the dealer's hand is "soft"
        //a "soft" hand means the hand contains an ace because an ace can be played as an 11 or 1
        public bool HandIsSoft()
        {
            bool softHand = false;

            foreach (Card card in Hand)
            {
                if (card.Rank == "Ace")
                {
                    softHand = true;
                    break;
                }
            }

            return softHand;
        }

        //remaining methods incorporate basic blackjack strategy as well as standard casino rules
        //these are used to determine the dealer's strategy/behavior
        //see DealerStrategy method in Game class
        public bool HandIsHard17OrMore()
        {
            bool hardSeventeenOrMore = false;

            if (!HandIsSoft() && HandTotal >= 17)
            {
                hardSeventeenOrMore = true;
            }

            return hardSeventeenOrMore;
        }

        public bool HandIs11OrLess()
        {
            bool elevenOrLess = false;

            if (HandTotal <= 11)
            {
                elevenOrLess = true;
            }

            return elevenOrLess;
        }

        public bool HandIsSoft15OrLess()
        {
            bool softFifteen = false;

            if (HandIsSoft() && HandTotal <= 15)
            {
                softFifteen = true;
            }

            return softFifteen;
        }

        public bool HandIsSoft16OrMore()
        {
            bool softSixteenOrMore = false;

            if (HandIsSoft() && HandTotal >= 16)
            {
                softSixteenOrMore = true;
            }

            return softSixteenOrMore;
        }

        public bool HandIsHard12OrMore()
        {
            bool hardTwelveOrMOre = false;

            if (!HandIsSoft() && HandTotal >= 12)
            {
                hardTwelveOrMOre = true;
            }

            return hardTwelveOrMOre;
        }
    }
}
