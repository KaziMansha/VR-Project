using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAnk : MonoBehaviour
{
    public static GameManagerAnk instance;

    public GameObject canvas;
    private int enemyCount = 7;

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
            SpawnCanvas();
        }
    }
    private void SpawnCanvas()
    {
        if (canvas != null)
        {
            canvas.SetActive(true);
        }
    }
}
