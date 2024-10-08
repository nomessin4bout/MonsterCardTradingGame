namespace MCTG.Server
{
    internal class MonsterCard : Card
    {
        public MonsterType Type { get; set; }

        public MonsterCard(string name, int damage, ElementType element, MonsterType type)
            : base(name, damage, element)
        {
            Type = type;
        }
    }

    internal enum MonsterType
    {
        Goblin,
        Dragon,
        Wizzard,
        Ork,
        Knight,
        Kraken,
        FireElf
    }
}
