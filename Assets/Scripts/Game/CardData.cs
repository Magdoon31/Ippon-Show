using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards")]
public class CardData : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite artwork;
}