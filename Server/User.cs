namespace MCTG.Server
{
    internal class User
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public int Coins { get; set; } = 20; 
        public List<Card> Stack { get; set; } = new List<Card>();
        public List<Card> Deck { get; set; } = new List<Card>(); 

        public void AddToStack(Card card)
        {
            Stack.Add(card);
        }

        public void SetDeck(List<Card> deck)
        {
            if (deck.Count == 4)
            {
                Deck = deck;
            }
        }
    }
}
