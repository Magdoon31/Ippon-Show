using UnityEngine;

public class PlayCardButton : MonoBehaviour
{
    private CardData card;
    public void Execute()
    {
        ComboManager.Instance.ExecuteCombo();
        while (HandManager.Instance.handSize > HandManager.Instance.hand.Count)
        {
            if (player.Instance.deck.Count == 0)
                break;

            CardData card = DeckManager.Instance.DrawCard();
            if (card != null)
                HandManager.Instance.AddCard(card);
        }
        SoundManager.Instance.PlaySound2D("click");
    }
    public void DiscardCard()
    {
        if (CardUI.selectedCard == null)
            return;
        if (RunManager.Instance.remainingDiscards <= 0)
        {
            SoundManager.Instance.PlaySound2D("deny");
            return;
        }
        SoundManager.Instance.PlaySound2D("click");
        HandManager.Instance.RemoveCard(CardUI.selectedCard);

            CardData newCard = DeckManager.Instance.DrawCard();

            if (newCard != null)
                HandManager.Instance.AddCard(newCard);

            CardUI.selectedCard = null ;
        RunManager.Instance.remainingDiscards--;
        RunManager.Instance.discardsRemaning.text = RunManager.Instance.remainingDiscards.ToString();
    }
    public void AddCardToCombo()
    {
        ComboManager.Instance.AddCardToCombo();
        
    }
}


    
