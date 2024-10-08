namespace MCTG.Server
{
    internal static class Battle
    {
        public static Card Fight(Card card1, Card card2)
        {
            if (card1 is MonsterCard monster1 && card2 is MonsterCard monster2)
            {
                if (MonsterSpecialties.IsSpecialCondition(monster1.Type, monster2.Type))
                    return card2;
                if (MonsterSpecialties.IsSpecialCondition(monster2.Type, monster1.Type))
                    return card1;

                if (MonsterSpecialties.IsImmuneToSpells(monster1.Type) && card2 is SpellCard)
                    return card1;
                if (MonsterSpecialties.IsImmuneToSpells(monster2.Type) && card1 is SpellCard)
                    return card2;

                if (MonsterSpecialties.IsArmoredAgainstWater(monster1.Type) && card2.Element == ElementType.Water)
                    return card2;
                if (MonsterSpecialties.IsArmoredAgainstWater(monster2.Type) && card1.Element == ElementType.Water)
                    return card1;
            }

            double card1Effectiveness = ElementEffectiveness.CalculateEffectiveness(card1.Element, card2.Element);
            double card2Effectiveness = ElementEffectiveness.CalculateEffectiveness(card2.Element, card1.Element);

            double card1FinalDamage = card1.Damage * card1Effectiveness;
            double card2FinalDamage = card2.Damage * card2Effectiveness;

            if (card1FinalDamage > card2FinalDamage)
                return card1;
            else if (card2FinalDamage > card1FinalDamage)
                return card2;

            return null;
        }
    }
}
