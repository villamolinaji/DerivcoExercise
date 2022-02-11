namespace Question2
{
    public class HighCard
    {
        const int DEFAULT_NUMBER_OF_CARDS = 52;

        GameResultEnum _previousResult;

        public bool ResolveTie { get; set; } = false;
        public bool AllowTie { get; set; } = true;
        public int? WildCard { get; set; }
        public int NumberOfCards { get; set; } = DEFAULT_NUMBER_OF_CARDS;        

        public HighCard()
        {
            _previousResult = GameResultEnum.Win;
        }

        public GameResultEnum Play()
        {
            Random rnd = new Random();
            GameResultEnum result;

            int i = rnd.Next() % NumberOfCards + 1;
            int j = rnd.Next() % NumberOfCards + 1;            

            if (j == WildCard)
            {
                result = GameResultEnum.Win;
            }
            else if (i < j)
            {
                result = GameResultEnum.Win;
            }
            else if (i == j)
            {
                result = Tie();
            }
            else
            {
                result = GameResultEnum.Lose;
            }

            if (result != GameResultEnum.Tie)
            {
                _previousResult = result;
            }

            return result;
        }

        private GameResultEnum Tie()
        {
            if (!AllowTie)
            {
                return this.Play();
            }
            else if (ResolveTie)
            {
                return _previousResult;
            }
            else
            {
                return GameResultEnum.Tie;
            }
        }
    }
}
