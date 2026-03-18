using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Health health;
    public EnemyData data;
    public Image EnemyArt;
    public List<CardData> deck = new List<CardData>();
    public int HPLevel { get; private set; }
    public void Initialize(EnemyData enemyData)
    {
        if (enemyData == null)
        {
            Debug.LogError("EnemyData is null. Cannot initialize enemy.");
            return;
        }
        data = enemyData;
        deck = new List<CardData>(data.deck);

        health.currentHP = health.maxHP;
    }

    public CardData DrawCard()
    {
        if (deck.Count == 0)
            return null;

        int index = Random.Range(0, deck.Count);

        CardData card = deck[index];
        deck.RemoveAt(index);

        return card;
    }
}