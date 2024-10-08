namespace MCTG.Server
{
    internal class Deck
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

        public void AddCard(Card card)
        {
            if (Cards.Count < 4)
            {
                Cards.Add(card);
            }
        }

        public void RemoveCard(Card card)
        {
            Cards.Remove(card);
        }
    }
}
