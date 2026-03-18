using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP = 20;
    public int currentHP;
    public float precentHP => (float)currentHP / maxHP * 100;
    public int HPLevel { get; private set; }

    void Start()
    {
        currentHP = maxHP;
        UpdateHPLevel();
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP < 0)
            currentHP = 0;

        UpdateHPLevel();
    }

    public void UpdateHPLevel()
    {
        float percent = (float)currentHP / maxHP;

        if (currentHP == 0)
            HPLevel = 1;
        else if (percent <= 0.5f)
            HPLevel = 2;
        else
            HPLevel = 3;
    }
}