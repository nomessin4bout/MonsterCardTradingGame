namespace MCTG.Server
{
    internal class Package
    {
        public List<Card> Cards { get; private set; }

        public Package(List<Card> cards)
        {
            Cards = cards;
        }

        public static Package CreateRandomPackage()
        {
            var randomCards = new List<Card>
            {
                new MonsterCard("Goblin", 10, ElementType.Fire, MonsterType.Goblin),
                new MonsterCard("Dragon", 50, ElementType.Fire, MonsterType.Dragon),
                new MonsterCard("Kraken", 60, ElementType.Water, MonsterType.Kraken),

                new SpellCard("Fireball", 40, ElementType.Fire),
                new SpellCard("WaterSplash", 30, ElementType.Water)
            };
            return new Package(randomCards);
        }
    }
}
