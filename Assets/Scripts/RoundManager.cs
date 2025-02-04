using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
     Vector2 randomPosition = new Vector2();
    public EnemySpawner enemySpawer;

    // Start is called before the first frame update
    void Start()
    {
        // ! This should be called after player presses Play so change it when added
        StartRound();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 getRandomLocation()
    {
        float x = Random.Range(-9.5f, 9.5f);
        float y = Random.Range(-4f, 4f);
        return randomPosition = new Vector2(x, y);
    }

    public void StartRound()
    {
        Instantiate(enemySpawer, getRandomLocation(), Quaternion.identity);
        StartCoroutine(enemySpawer.SpawnEnemies("baseEnemy", 5, 2f, randomPosition));
    }
}
