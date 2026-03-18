using UnityEngine;

public static class ThrowSystem
{
    public static bool TryThrow(int eff, int hpTier)
    {
        float chance = eff * (10 + 2 * (3 - hpTier));
        if (chance > 100f)
            chance = 100f;
        float roll = Random.Range(0f, 100f);

        return roll <= chance;
    }
}