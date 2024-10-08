namespace MCTG.Server
{
    internal static class MonsterSpecialties
    {
        public static bool IsSpecialCondition(MonsterType attacker, MonsterType defender)
        {
            if (attacker == MonsterType.Goblin && defender == MonsterType.Dragon)
                return true;

            if (attacker == MonsterType.Ork && defender == MonsterType.Wizzard)
                return true;

            if (attacker == MonsterType.Dragon && defender == MonsterType.FireElf)
                return true;

            return false;
        }

        public static bool IsImmuneToSpells(MonsterType monster)
        {
            return monster == MonsterType.Kraken;
        }

        public static bool IsArmoredAgainstWater(MonsterType monster)
        {
            return monster == MonsterType.Knight;
        }
    }
}
