using UnityEngine;

public class CardListManager : MonoBehaviour
{
    public Transform content;
    public GameObject cardItemPrefab;
    private CardData[] allCards;

    void Start()
    {
        CardDatabase database = FindFirstObjectByType<CardDatabase>();
        allCards = database.allCards.ToArray();
        foreach (CardData card in allCards)
        {
            GameObject obj = Instantiate(cardItemPrefab, content);

            CardUI ui = obj.GetComponent<CardUI>();
            ui.Setup(card);
        }
    }
}