using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public EnemyHealthBarUI enemyHealthBar;
    public Transform spawnPoint;
    public Image artworkImage;

    public Enemy SpawnEnemy(EnemyData data)
    {
        
        Enemy enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.transform.SetParent(spawnPoint);
        artworkImage = enemy.EnemyArt;
        artworkImage.sprite = data.artwork;
        enemy.Initialize(data);
        enemyHealthBar.target = enemy;

        enemy.transform.SetParent(spawnPoint);
        return enemy;
    }
}