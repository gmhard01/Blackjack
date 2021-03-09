using System;

namespace Blackjack.Classes
{
    public class Game
    {
        //deal top two cards to player, then deal top two cards to dealer
        public static void DealStartingHands(Deck deck, Dealer dealer, Player player)
        {
            player.Hand.Add(deck.DealCard());
            player.Hand.Add(deck.DealCard());
            dealer.Hand.Add(deck.DealCard());
            dealer.Hand.Add(deck.DealCard());
        }

        //check if player or dealer went bust - i.e. their hand total is more than 21
        public static bool PlayerBust(Player player)
        {
            bool bust = false;
            int bustAboveValue = 21;

            if (player.HandTotal > bustAboveValue)
            {
                bust = true;
            }

            return bust;
        }

        //dealer AI, if you will
        //decides whether dealer will hit or stay during their turn
        public static bool DealerStrategy(Deck deck, Dealer dealer, Player player)
        {
            bool dealerGo = true;
            Random rnd = new Random();

            if (dealer.HandIsHard17OrMore())
            {
                dealerGo = false;
                ConsoleIO.DealerStays();
            }
            else if (dealer.HandIs11OrLess())
            {
                dealer.Hit(deck);
                ConsoleIO.DealerHits();
            }
            else if (dealer.HandIsSoft15OrLess())
            {
                dealer.Hit(deck);
                ConsoleIO.DealerHits();
            }
            else if (dealer.HandIsSoft16OrMore())
            {
                dealerGo = false;
                ConsoleIO.DealerStays();
            }
            else if (dealer.HandIsHard12OrMore())
            {
                if (!PlayerBust(player) && player.HandTotal > dealer.HandTotal)
                {
                    dealer.Hit(deck);
                    ConsoleIO.DealerHits();
                }
                else
                {
                    dealerGo = false;
                    ConsoleIO.DealerStays();
                }
            }
            else
            {
                int hitOrStayTossUp = rnd.Next(2);

                if (hitOrStayTossUp == 0)
                {
                    dealerGo = false;
                    ConsoleIO.DealerStays();
                }
                else
                {
                    dealer.Hit(deck);
                    ConsoleIO.DealerHits();
                }
            }

            return dealerGo;
        }

        //determine whether player or dealer wins the game
        //return string telling who wins
        public static string DetermineWinner(Player player, Dealer dealer)
        {
            string winnerString = "The game ends in a draw!";

            if (PlayerBust(player))
            {
                winnerString = dealer.Name + " wins!";
            }
            else if (PlayerBust(dealer))
            {
                winnerString = player.Name + " wins!";
            }
            else
            {
                if (player.HandTotal > dealer.HandTotal)
                {
                    winnerString = player.Name + " wins!";
                }
                else if (player.HandTotal < dealer.HandTotal)
                {
                    winnerString = dealer.Name + " wins!";
                }
            }

            return winnerString;
        }

        //runs player's turn in PlayGame method
        public static void PlayerTurn(Player player, Dealer dealer, Deck deck)
        {
            bool playerGo = true;

            while (playerGo)
            {
                ConsoleIO.TellPlayerShowDealer(player, dealer);

                if (ConsoleIO.AskToHit())
                {
                    player.Hit(deck);
                    ConsoleIO.ConsoleCleanup();
                }
                else
                {
                    playerGo = false;
                }

                if (PlayerBust(player))
                {
                    ConsoleIO.ConsoleCleanup();
                    ConsoleIO.TellPlayerShowDealer(player, dealer);
                    ConsoleIO.Busted(player);
                    ConsoleIO.Pause();
                    playerGo = false;
                }
            }
        }

        //runs dealer's turn in PlayGame method
        public static void DealerTurn(Player player, Dealer dealer, Deck deck)
        {
            do
            {
                ConsoleIO.ConsoleCleanup();
                ConsoleIO.TellPlayerHand(player);
                ConsoleIO.TellPlayerHand(dealer);

                if (PlayerBust(player))
                {
                    break;
                }

                ConsoleIO.DealerThinking();

                if (PlayerBust(dealer))
                {
                    ConsoleIO.Busted(dealer);
                    ConsoleIO.Pause();
                    break;
                }

                ConsoleIO.Pause();

            } while (DealerStrategy(deck, dealer, player));
        }

        //plays a game of Blackjack!
        public static void PlayGame()
        {
            bool playing = true;
            Player player = new Player("Player");
            Dealer dealer = new Dealer("Dealer");
            Deck deck = new Deck(Deck.InitializeDeck());
            deck.Cards = deck.Shuffle();

            while (playing)
            {
                ConsoleIO.ConsoleCleanup();

                player.Hand.Clear();
                dealer.Hand.Clear();

                try
                {
                    DealStartingHands(deck, dealer, player);

                    PlayerTurn(player, dealer, deck);
                    ConsoleIO.DealerFlipsFaceDownCard();
                    ConsoleIO.ConsoleCleanup();
                    DealerTurn(player, dealer, deck);

                    ConsoleIO.ConsoleCleanup();
                    ConsoleIO.TellPlayerHand(player);
                    ConsoleIO.TellPlayerHand(dealer);
                    ConsoleIO.TellWinner(player, dealer);

                    playing = ConsoleIO.AskToPlayAgain();

                    //statistically most blackjack hands are about 2.9 cards, so this goes slightly higher than that to hopefully avoid indexoutofrange (deck runs out of cards)
                    if (deck.Cards.Count < 8) 
                    {
                        deck.Cards = Deck.InitializeDeck();
                        deck.Cards = deck.Shuffle();
                        ConsoleIO.NewDeck();
                    }
                }
                //it is possible, though unlikely, to run out of cards in the deck and get an indexoutofrange exception
                catch (IndexOutOfRangeException)
                {
                    ConsoleIO.RanOutOfCards();
                    throw;
                }
            }
        }
    }
}
