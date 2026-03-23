using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance;
    private CardData card;
    public EnemySpawner spawner;
    public EnemyData enemyToSpawn;


    void Awake()
    {
        Instance = this;


    }
    private void Start()
    {
        //Game start:
        spawner.SpawnEnemy(enemyToSpawn);
        Debug.Log(FightStyleSelection.currentStyle);
        RunManager.Instance.StartRun();
        player.Instance.originalDeck = new List<CardData>(player.Instance.deck);

        while (HandManager.Instance.hand.Count < HandManager.Instance.handSize)
        {

            if (player.Instance.deck.Count == 0)
            {
                Debug.Log("Deck is empty, cannot draw more cards for hand initialization.");
                break;
            }
            CardData card = DrawCard();
            if (card != null)
                HandManager.Instance.AddCard(card);
        }
    }

    public CardData DrawCard()
    {
        if (player.Instance.deck.Count == 0)
            return null;

        int index = Random.Range(0, player.Instance.deck.Count);

        CardData card = player.Instance.deck[index];
        player.Instance.deck.RemoveAt(index);

        return card;
    }

    public void ResetDeck()
    {
        player.Instance.deck = new List<CardData>(player.Instance.originalDeck);
    }
    public void EnemyResetDeck()
    {
        Enemy enemy = FindFirstObjectByType<Enemy>();
        enemy.deck = new List<CardData>(enemy.originalDeck);
        ShuffleDeck();
    }
    private void ShuffleDeck()
    {
        Enemy enemy = FindFirstObjectByType<Enemy>();
        for (int i = 0; i < enemy.deck.Count; i++)
        {
            CardData temp = enemy.deck[i];
            int randomIndex = Random.Range(i, enemy.deck.Count);
            enemy.deck[i] = enemy.deck[randomIndex];
            enemy.deck[randomIndex] = temp;
        }
    }
}