using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public bool testing = true; // ! Delete this when done testing
    Vector2 randomPosition = new Vector2();
    public EnemySpawner enemySpawer;
    private int round = 1;
    public ColorManager colorManager;


    // Start is called before the first frame update
    void Start()
    {
        // ! This should be called after player presses Play so change it when added
        StartCoroutine(StartRoundCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Wait(float seconds)
    {
        // ! Get rid of this when done testing
        if (testing)
        {
            yield return new WaitForSeconds(1);
        } 
        else
        {
            yield return new WaitForSeconds(seconds);
        }
    }

    public Vector2 getRandomLocation()
    {
        float x = Random.Range(-9.5f, 9.5f);
        float y = Random.Range(-4f, 4f);
        return randomPosition = new Vector2(x, y);
    }

   private IEnumerator CheckEnemies()
    {
        while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            // ? Maybe add an enemies left counter after some time
            // ? Might need a total number of enemies for the round then
            // ? when there are 10 left start displaying it
            Debug.Log("Enemies left: " + GameObject.FindGameObjectsWithTag("Enemy").Length);
            yield return new WaitForSeconds(1f);
        }
        round++;
        Debug.Log("Round: " + round);
        colorManager.colorTable(round);
        // TODO: Add delay before next round
        // ? This could be done when I add the UI manager
        yield return new WaitForSeconds(3f); // ! Delete this when UI manager handles it
        StartCoroutine(StartRoundCoroutine());
    }
    
    private IEnumerator StartRoundCoroutine()
    {
        // TODO: Implement all rounds
        switch (round)
        {
            case 1:
                yield return Wait(4f);
                Instantiate(enemySpawer, getRandomLocation(), Quaternion.identity);
                StartCoroutine(enemySpawer.GetComponent<EnemySpawner>().SpawnEnemies("baseEnemy", 1, 2f, randomPosition)); // 8
                
                yield return Wait(10f);
                Instantiate(enemySpawer, getRandomLocation(), Quaternion.identity);
                StartCoroutine(enemySpawer.GetComponent<EnemySpawner>().SpawnEnemies("baseEnemy", 1, 2f, randomPosition)); // 4

                yield return Wait(2f);
                Instantiate(enemySpawer, getRandomLocation(), Quaternion.identity);
                StartCoroutine(enemySpawer.GetComponent<EnemySpawner>().SpawnEnemies("baseEnemy", 1, 2f, randomPosition)); // 4

                yield return Wait(2f);
                Instantiate(enemySpawer, getRandomLocation(), Quaternion.identity);
                StartCoroutine(enemySpawer.GetComponent<EnemySpawner>().SpawnEnemies("baseEnemy", 1, 2f, randomPosition)); // 4
                
                break;
            case 2:
                yield return Wait(4f);
                Instantiate(enemySpawer, getRandomLocation(), Quaternion.identity);
                StartCoroutine(enemySpawer.GetComponent<EnemySpawner>().SpawnEnemies("fastEnemy", 1, 2f, randomPosition));
                
                yield return Wait(10f);
                Instantiate(enemySpawer, getRandomLocation(), Quaternion.identity);
                StartCoroutine(enemySpawer.GetComponent<EnemySpawner>().SpawnEnemies("fastEnemy", 1, 2f, randomPosition));

                yield return Wait(2f);
                Instantiate(enemySpawer, getRandomLocation(), Quaternion.identity);
                StartCoroutine(enemySpawer.GetComponent<EnemySpawner>().SpawnEnemies("fastEnemy", 1, 2f, randomPosition));
                
                CheckEnemies();

                break;
            default:
                Debug.Log("Error: Invalid round number");
                break;
        }
        StartCoroutine(CheckEnemies());
    }
}
