using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "NewEnemy", menuName = "Fight/Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public Sprite artwork;
    public int health;

    public List<CardData> deck;
}