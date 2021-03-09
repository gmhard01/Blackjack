# Blackjack

Basic game of Blackjack where one player plays against the dealer (the computer). While a Blackjack program is surely nothing particularly fancy, there are a few points about this project that, to me, are neat and interesting:

1. The deck (standard 52 card deck) is created automatically, using loops and arrays to assign each card a suit, rank (e.g. ace, three, etc.), and value. Ultimately we end up with a 52 card deck with 13 cards of each suit and 4 cards of each rank. This is a more interesting method than simply reading a list of all 52 unique cards.

2. As a junior programmer, I learned the hard way why it is important to write decoupled and testable code. On an early project, I wrote myself into a corner by having console input/output contained within other methods that implemented logic. When it came time to write unit tests, I realized I was screwed because I depended on console input to assign values to variables that would be involved in testing - not good. Learning from this, I have a ConsoleIO class that handles all console input and output. Maybe not interesting per se, but certainly a point of growth.

3. The dealer (computer opponent) plays using basic Blackjack strategies as well as standard casino rules that I researched that ultimately dictate how it's decisions are made. This works well and makes the dealer and fairly formidable opponent. Refer to the methods in the Dealer class and the DealerStrategy method in the Game class to see how this works.

4. I have written 30 (passing!) unit tests to ensure functionality works appropriately. 
