using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance;

    public Transform handArea;
    public GameObject cardPrefab;
    public int handSize = 3;

    public List<CardUI> hand = new List<CardUI>();

    void Awake()
    {
        Instance = this;
    }

    public void AddCard(CardData card)
    {
        GameObject obj = Instantiate(cardPrefab, handArea);

        CardUI ui = obj.GetComponent<CardUI>();
        ui.Setup(card);

        hand.Add(ui);
    }

    public void RemoveCard(CardUI card)
    {
        hand.Remove(card);
        Destroy(card.gameObject);
    }
}