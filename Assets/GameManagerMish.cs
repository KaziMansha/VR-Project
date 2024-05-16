using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMish : MonoBehaviour
{
    public static GameManagerMish instance;
    public GameObject bossPrefab;
    public GameObject canvas;
    private int enemyCount = 13;
    private int bossCount = 1;
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
