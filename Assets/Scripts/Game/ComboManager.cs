using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public static ComboManager Instance;
    public GameObject gameOver;
    public Transform comboArea;
    public CardData card;
    public List<CardData> comboCards = new List<CardData>();
    public Enemy enemy;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
       enemy = Object.FindAnyObjectByType<Enemy>(); ;
    }
    public void AddCardToCombo()
    {
        if (comboCards.Count >= RunManager.Instance.maxCombo)
        {
            SoundManager.Instance.PlaySound2D("deny");
            return;
        }

        SoundManager.Instance.PlaySound2D("click");
        if (CardUI.selectedCard == null) return;
        CardUI cardUI = CardUI.selectedCard;
        CardData card = cardUI.data;

        comboCards.Add(card);

        cardUI.transform.SetParent(comboArea);

        cardUI.Deselect();
        CardUI.selectedCard = null;
        RunManager.Instance.comboMaxAmmount.text = comboCards.Count + "/" + RunManager.Instance.maxCombo.ToString();
    }

    public void ExecuteCombo()
    {
        foreach (CardData card in comboCards)
        {
            SoundManager.Instance.PlaySound2D("card");
            if (card is GripCardData gripCard)
            {
                GripManager.Instance.UpdateGrip(gripCard.gripType);
            }
            if (card is AtackCardData atackCard)
            {
                PlayAttack(atackCard,true);
            }
            
        }
        foreach (Transform child in comboArea)
        {
            CardUI card = child.GetComponent<CardUI>();
            HandManager.Instance.RemoveCard(card);
        }
        comboCards.Clear();
        RunManager.Instance.comboMaxAmmount.text = comboCards.Count + "/" + RunManager.Instance.maxCombo.ToString();
        EnemyAI enemyAI = FindFirstObjectByType<EnemyAI>();
        enemyAI.ExecuteTurn();
    }
    public void EnemyExecuteCombo(CardData card)
    {
            SoundManager.Instance.PlaySound2D("card");
            if (card is GripCardData gripCard)
            {
                Debug.Log("Enemy played grip card: " + gripCard.cardName);
                GripManager.Instance.UpdateGrip(gripCard.gripType);
            }
            if (card is AtackCardData atackCard)
            {
                Debug.Log("Enemy played attack card: " + atackCard.cardName);
                PlayAttack(atackCard,false);
            }
    }
    public void PlayAttack(AtackCardData card, bool executer)
    {
        // executer ->    true - player    false - enemy

        int i = 0;
        int hpTier = 3;
        foreach (string grip in card.gripType)
        {
            if (grip == GripManager.Instance.gripStatus)
                i++;
        }
        if (i == 0)
        {
            SoundManager.Instance.PlaySound2D("deny");
            return;
        }
        if (executer)   hpTier = enemy.health.HPLevel;
        if (!executer) hpTier = player.Instance.health.HPLevel;

        bool thrown = ThrowSystem.TryThrow(card.eff, hpTier);

        if (thrown)
        {
            if (executer)
            {
                Debug.Log("Enemy thrown!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                enemy.health.currentHP = enemy.health.maxHP;
                Destroy(enemy.gameObject);
            }
            else
            {
                Debug.Log("Player thrown!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                gameOver.SetActive(true);
            }
            

        }
        else
        {
            if (executer) enemy.health.TakeDamage(card.damage);
            if (!executer) player.Instance.health.TakeDamage(card.damage);
        }
    }
}