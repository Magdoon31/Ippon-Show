using TMPro;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance;

    public int remainingDiscards;
    public int maxCombo;

    public TMP_Text discardsRemaning;
    public TMP_Text comboMaxAmmount;

    void Awake()
    {
        Instance = this;
    }

   
    public void StartRun()
    {
        FightStyleSelection styleSelector = FindFirstObjectByType<FightStyleSelection>();
        FightStyleData selectedStyle = styleSelector.styles[FightStyleSelection.currentStyle];
        player.Instance.deck.Clear();

        foreach (CardData card in selectedStyle.startingDeck)
        {
            player.Instance.deck.Add(card);
        }

        HandManager.Instance.handSize += selectedStyle.handSizeModifier;

        player.Instance.health.maxHP = selectedStyle.startingHP;

        RunManager.Instance.InitializeRun(selectedStyle);
    }
    public void InitializeRun(FightStyleData style)
    {
        remainingDiscards = style.discardCount;
        maxCombo = style.maxCombo;
        discardsRemaning.text = remainingDiscards.ToString();
        comboMaxAmmount.text = ComboManager.Instance.comboCards.Count + "/" + maxCombo.ToString();
    }
}