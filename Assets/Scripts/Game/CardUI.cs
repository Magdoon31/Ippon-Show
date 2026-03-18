using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour, IPointerClickHandler
{
    public CardData data;
    public static CardUI selectedCard;
    private RectTransform rect;
    public float selectedOffset = 40f;
    public Image artworkImage;
    public TMP_Text nameText;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public void Setup(CardData card)
    {
        data = card;
        artworkImage.sprite = card.artwork;
        nameText.text = card.cardName;
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (CardData card in ComboManager.Instance.comboCards) {
            Debug.Log(card+" "+ this.data);
            if (card == this.data)
            {
                return;
            }
        }

        if (selectedCard != this)
        {
            if (selectedCard != null)
                selectedCard.Deselect();

            selectedCard = this;
            Select();
        }
        else
        {
            Deselect();
            selectedCard = null;
        }
        SoundManager.Instance.PlaySound2D("card");
    }

    public void Select()
    {
        rect.anchoredPosition += new Vector2(0, selectedOffset);
    }

    public void Deselect()
    {
        rect.anchoredPosition -= new Vector2(0, selectedOffset);
    }
}