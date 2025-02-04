using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public bool testing = true; // ! Delete this when done testing
    Vector2 randomPosition = new Vector2();
    public EnemySpawner enemySpawner;
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
                EnemySpawner spawner1 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                StartCoroutine(spawner1.GetComponent<EnemySpawner>().FadeInSpawner(spawner1));
                yield return StartCoroutine(spawner1.GetComponent<EnemySpawner>().SpawnEnemies("baseEnemy", 1, 2f, randomPosition)); // 8
                StartCoroutine(spawner1.GetComponent<EnemySpawner>().FadeOutSpawner(spawner1));
                
                yield return Wait(10f);
                EnemySpawner spawner2 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                StartCoroutine(spawner2.GetComponent<EnemySpawner>().FadeInSpawner(spawner2));
                yield return StartCoroutine(spawner2.GetComponent<EnemySpawner>().SpawnEnemies("baseEnemy", 1, 2f, randomPosition)); // 4
                StartCoroutine(spawner2.GetComponent<EnemySpawner>().FadeOutSpawner(spawner2));

                yield return Wait(2f);
                EnemySpawner spawner3 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                StartCoroutine(spawner3.GetComponent<EnemySpawner>().FadeInSpawner(spawner3));
                yield return StartCoroutine(spawner3.GetComponent<EnemySpawner>().SpawnEnemies("baseEnemy", 1, 2f, randomPosition)); // 4
                StartCoroutine(spawner3.GetComponent<EnemySpawner>().FadeOutSpawner(spawner3));

                yield return Wait(2f);
                EnemySpawner spawner4 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                StartCoroutine(spawner4.GetComponent<EnemySpawner>().FadeInSpawner(spawner4));
                yield return StartCoroutine(spawner4.GetComponent<EnemySpawner>().SpawnEnemies("baseEnemy", 1, 2f, randomPosition)); // 4
                StartCoroutine(spawner4.GetComponent<EnemySpawner>().FadeOutSpawner(spawner4));
                
                break;
            case 2:
                yield return Wait(4f);
                EnemySpawner spawner5 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                yield return StartCoroutine(spawner5.GetComponent<EnemySpawner>().SpawnEnemies("fastEnemy", 1, 2f, randomPosition));
                StartCoroutine(spawner5.GetComponent<EnemySpawner>().FadeOutSpawner(spawner5));
                
                yield return Wait(10f);
                EnemySpawner spawner6 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                yield return StartCoroutine(spawner6.GetComponent<EnemySpawner>().SpawnEnemies("fastEnemy", 1, 2f, randomPosition));
                StartCoroutine(spawner6.GetComponent<EnemySpawner>().FadeOutSpawner(spawner6));

                yield return Wait(2f);
                EnemySpawner spawner7 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                yield return StartCoroutine(spawner7.GetComponent<EnemySpawner>().SpawnEnemies("fastEnemy", 1, 2f, randomPosition));
                StartCoroutine(spawner7.GetComponent<EnemySpawner>().FadeOutSpawner(spawner7));
                
                CheckEnemies();

                break;
            default:
                Debug.Log("Error: Invalid round number");
                break;
        }
        StartCoroutine(CheckEnemies());
    }
}
