using UnityEngine;
using System.Threading;
using System.Collections;
using Unity.Burst.Intrinsics;

public class EnemyAI : MonoBehaviour
{
    public Enemy enemy; 

    public void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    public void ExecuteTurn()
    {
        if (enemy.deck.Count == 0)
        {
            DeckManager.Instance.EnemyResetDeck();
        }

        float roll = Random.value;

        // 33% szans na atak, 33% szans na combo, 33% szans na grip
        if (roll >= 0.66f)
        {
            Debug.Log("Enemy chooses to attack only.");
            PlayAttackOnly();
        }
        else if (roll < 0.33f)
        {

            PlayCombo();
        }
        else
        {
            Debug.Log("Enemy chooses to play grip only");
            PlayGripOnly();
        }
        
    }

    private void PlayCombo()
    {
        // 50% szans na 2 ataki i 50% na 1 atak + 1 grip
        bool twoAttacks = Random.value < 0.5f;

        if (twoAttacks)
        {
            Debug.Log("Enemy chooses to play combo - 2 attacks.");
            CardData attack1 = GetValidAttack();
            if (attack1 != null) ComboManager.Instance.EnemyExecuteCombo(attack1);
            CardData attack2 = GetValidAttack();
            if (attack2 != null) ComboManager.Instance.EnemyExecuteCombo(attack2);
            if (attack1 == null && attack2 == null)
            {
                PlayGripOnly();
            }
        }
        else
        {
            Debug.Log("Enemy chooses to play combo - 1 grip + 1 attack.");
            CardData grip = GetValidGrip();
            if (grip != null) ComboManager.Instance.EnemyExecuteCombo(grip);
            CardData attack = GetValidAttack();
            if (attack != null) ComboManager.Instance.EnemyExecuteCombo(attack);
        }
    }

    private void PlayGripOnly()
    {
        CardData grip = GetValidGrip();
        if (grip != null) ComboManager.Instance.EnemyExecuteCombo(grip);
        if (grip == null)
        {
            DeckManager.Instance.EnemyResetDeck();
        }
    }

    private void PlayAttackOnly()
    {
        CardData attack = GetValidAttack();
        if (attack != null) ComboManager.Instance.EnemyExecuteCombo(attack);
        if (attack == null)
        {
            PlayGripOnly();
        }
    }

    private CardData GetValidGrip()
    {
        foreach (CardData card in enemy.deck)
        {
            if (card is GripCardData && !HasGrip(card))
            {
                enemy.deck.Remove(card);
                return card;
            }
        }
        return null;
    }
    private CardData GetValidAttack()
    {
        foreach (CardData card in enemy.deck)
        {
            if (card is AtackCardData attack && CanUseAttack(attack))
            {
                enemy.deck.Remove(card);
                return card;
            }
        }
        return null;
    }

    private bool HasGrip(CardData card)
    {
        if(card is GripCardData gripCard)
        {
            return gripCard.gripType == GripManager.Instance.gripStatus;
        }
        return false;
    }

    private bool CanUseAttack(AtackCardData attack)
    {
        int i = 0;
        foreach (string grip in attack.gripType)
        {
            if (grip == GripManager.Instance.gripStatus)
                i++;
        }
        Debug.Log("Enemy checking attack: " + attack.cardName + " - matching grips: " + i);
        if (i == 0) return false;
        return true;
    }
}