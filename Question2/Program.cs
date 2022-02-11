
namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            HighCard card = new HighCard();
            card.ResolveTie = true;
            card.AllowTie = false;            
            card.NumberOfCards = 20;
            card.WildCard = 11;

            Console.WriteLine("Please input number of decks:");
            var decks = Console.ReadLine();            

            int decksNumber = 0;
            int.TryParse(decks, out decksNumber);

            if (decksNumber <= 0)
            {
                Console.WriteLine("Please input a number greater than 0");
            }
            else
            {
                int gameNumber = 0;
                while (gameNumber < decksNumber)
                {
                    gameNumber++;
                    Console.WriteLine($"Game: {gameNumber}");
                    Console.WriteLine(card.Play());                    
                }
            }
        }
    }
}