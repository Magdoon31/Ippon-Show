using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/AtackCard")]
public class AtackCardData : CardData
{
    public string AtackType;
    public int damage;
    public int eff;
    public int cost;
    public string[] gripType;
    
    
}