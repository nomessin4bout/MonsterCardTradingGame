namespace MCTG.Server
{
    internal static class ElementEffectiveness
    {
        public static double CalculateEffectiveness(ElementType attackerElement, ElementType defenderElement)
        {
            if (attackerElement == ElementType.Water && defenderElement == ElementType.Fire)
                return 2.0;

            if (attackerElement == ElementType.Fire && defenderElement == ElementType.Normal)
                return 2.0;

            if (attackerElement == ElementType.Normal && defenderElement == ElementType.Water)
                return 2.0;

            if (attackerElement == defenderElement)
                return 1.0; 

            return 0.5; 
        }
    }
}
