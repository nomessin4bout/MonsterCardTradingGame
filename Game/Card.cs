namespace MCTG.Server
{
    internal abstract class Card
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public ElementType Element { get; set; }

        protected Card(string name, int damage, ElementType element)
        {
            Name = name;
            Damage = damage;
            Element = element;
        }
    }

    internal enum ElementType
    {
        Fire,
        Water,
        Normal
    }
}
