using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewStyle", menuName = "Fight/Style")]
public class FightStyleData : ScriptableObject
{
    public string styleName;
    public string description;

    public int discardCount;
    public int maxCombo;
    public int handSizeModifier;
    public int startingHP = 20;

    public List<CardData> startingDeck;
}