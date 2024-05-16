using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject bossPrefab; // Drag your Boss prefab here via the Inspector
    public GameObject canvas;
    public int enemyCount = 6;
    public int bossCount = 1;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void EnemyKilled()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            SpawnBoss();
        }
    }
    public void BossKilled()
    {
        SpawnCanvas();
    }

    private void SpawnBoss()
    {
        if (bossPrefab != null)
            bossPrefab.SetActive(true);
    }

    private void SpawnCanvas()
    {
        if (canvas != null)
        {
            canvas.SetActive(true);
        }
    }
}
