using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class RoundManager : MonoBehaviour
{
    private bool testing = false; // ! Delete this when done testing
    private bool skipRounds = true; // ! Delete this when done testing
    private int TEST_startingRound = 7; // ! Delete this when done testing
    Vector2 randomPosition = new Vector2();
    public EnemySpawner enemySpawner;
    private int round = 1;
    public ColorManager colorManager;
    public UIManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        if (skipRounds)
        {
            round = TEST_startingRound;
        }
        // ! This should be called after player presses Play so change it when added
        StartCoroutine(StartRoundCoroutine());
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

   private IEnumerator CheckEnemies()
    {
        while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            // ? Maybe add an enemies left counter after some time
            // ? Might need a total number of enemies for the round then
            // ? when there are 10 left start displaying it
            // Debug.Log("Enemies left: " + GameObject.FindGameObjectsWithTag("Enemy").Length);
            yield return new WaitForSeconds(1f);
        }
        round++;
        uiManager.TextTable(round);
        yield return StartCoroutine(uiManager.FadeInText(uiManager.waveCountText, uiManager.centerText));
        colorManager.colorTable(round);
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(uiManager.FadeOutText(uiManager.waveCountText, uiManager.centerText));
        StartCoroutine(StartRoundCoroutine());
    }

    private IEnumerator HandleSpawner(EnemySpawner spawner, string enemyType, int amount, float delay, Vector2 position)
    {
        StartCoroutine(spawner.GetComponent<EnemySpawner>().FadeInSpawner(spawner));
        yield return StartCoroutine(spawner.GetComponent<EnemySpawner>().SpawnEnemies(enemyType, amount, delay, position));
        StartCoroutine(spawner.GetComponent<EnemySpawner>().FadeOutSpawner(spawner));
    }
    
    private IEnumerator StartRoundCoroutine()
    {
        // ! Delete if statement when done testing
        if (!testing) 
        {
            // TODO: Implement all rounds
            switch (round)
            {
                case 1:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner1 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner1, "baseEnemy", 8, 2f, randomPosition)); // 8
                    
                    yield return new WaitForSeconds(10f);
                    EnemySpawner spawner2 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner2, "baseEnemy", 4, 2f, randomPosition)); // 4

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner3 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner3, "baseEnemy", 4, 2f, randomPosition)); // 4

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner4 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner4, "baseEnemy", 4, 2f, randomPosition)); // 4
                    
                    break;
                case 2:
                    yield return new WaitForSeconds(5f);
                    EnemySpawner spawner5 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner5, "fastEnemy", 7, 1f, randomPosition)); // 7
                    
                    yield return new WaitForSeconds(5f);
                    EnemySpawner spawner6 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner6, "fastEnemy", 7, 1f, randomPosition)); // 7

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner7 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner7, "fastEnemy", 6, 1f, randomPosition)); // 6

                    break;
                case 3:
                    yield return new WaitForSeconds(5f);
                    EnemySpawner spawner8 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner8, "baseEnemy", 4, 2f, randomPosition)); // 4
                    
                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner9 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner9, "fastEnemy", 7, 1f, randomPosition)); // 7

                    yield return new WaitForSeconds(8f);
                    EnemySpawner spawner10 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner10, "fastEnemy", 7, 1f, randomPosition)); // 7

                    StartCoroutine(uiManager.DisplayBlackOutEffect(0.1f));

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner11 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner11, "baseEnemy", 4, 2f, randomPosition)); // 4

                    // ? Music cuts out for a second

                    break;
                case 4:
                    yield return new WaitForSeconds(5f);
                    EnemySpawner spawner12 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner12, "fastEnemy", 7, 1f, randomPosition)); // 7

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner13 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner13, "baseEnemy", 4, 1f, randomPosition)); // 4

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner14 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner14, "fastEnemy", 7, 1f, randomPosition)); // 7

                    StartCoroutine(uiManager.DisplayStaticEffect(0.3f, 0.15f));

                    yield return new WaitForSeconds(6f);
                    EnemySpawner spawner15 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner15, "baseEnemy", 4, 1f, randomPosition)); // 4

                    StartCoroutine(uiManager.DisplayStaticEffect(0.5f, 0.20f));

                    break;
                case 5:
                    yield return new WaitForSeconds(1f);
                    yield return StartCoroutine(uiManager.Shop());
                    break;
                case 6:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner16 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner16, "baseEnemy", 8, 1f, randomPosition)); // 8

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner17 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner17, "fastEnemy", 7, 0.75f, randomPosition)); // 7

                    // ? High pitch sound effect

                    yield return new WaitForSeconds(7f);
                    EnemySpawner spawner18 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner18, "fastEnemy", 7, 0.75f, randomPosition)); // 7

                    yield return new WaitForSeconds(0.75f);
                    EnemySpawner spawner19 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner19, "baseEnemy", 4, 1f, randomPosition)); // 4

                    yield return new WaitForSeconds(5f);
                    EnemySpawner spawner20 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner20, "baseEnemy", 4, 1f, randomPosition)); // 4

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner21 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner21, "fastEnemy", 7, 0.75f, randomPosition)); // 7

                    break;
                case 7:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner22 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner22, "fastEnemy", 14, 1f, randomPosition)); // 14

                    yield return new WaitForSeconds(5f);
                    StartCoroutine(uiManager.DisplaySkullEffect(0.1f));

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner23 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner23, "fastEnemy", 7, 0.75f, randomPosition)); // 7

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner24 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner24, "fastEnemy", 7, 1f, randomPosition)); // 7

                    yield return new WaitForSeconds(5f);
                    EnemySpawner spawner25 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner25, "fastEnemy", 7, 0.75f, randomPosition)); // 7

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner26 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner26, "fastEnemy", 7, 1, randomPosition)); // 7

                    break;
                case 8:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner27 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner27, "tankEnemy", 6, 2f, randomPosition)); // 6

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner28 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner28, "baseEnemy", 4, 1f, randomPosition)); // 4

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner29 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner29, "tankEnemy", 5, 2f, randomPosition)); // 5

                    yield return new WaitForSeconds(6f);
                    EnemySpawner spawner30 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner30, "tankEnemy", 6, 2f, randomPosition)); // 6
                    
                    StartCoroutine(uiManager.DisplayTextEffect("MIND", 0.1f));

                    yield return new WaitForSeconds(1f);
                    StartCoroutine(uiManager.DisplayTextEffect("CONTROL", 0.1f));

                    break;
                case 9:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner31 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner31, "tankEnemy", 6, 2f, randomPosition)); // 6

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner32 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner32, "fastEnemy", 7, 0.75f, randomPosition)); // 7

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner33 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner33, "tankEnemy", 6, 2f, randomPosition)); // 6

                    yield return new WaitForSeconds(8f);
                    EnemySpawner spawner34 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner34, "fast Enemy", 7, 0.75f, randomPosition)); // 7

                    yield return new WaitForSeconds(7f);
                    EnemySpawner spawner35 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner35, "fastEnemy", 7, 1f, randomPosition)); // 7

                    break;
                case 10:
                    yield return new WaitForSeconds(1f);
                    yield return StartCoroutine(uiManager.Shop());
                    break;
                default:
                    Debug.Log("Error: Invalid round number");
                    break;
            }
        } else
        {
            switch (round)
            {
                case 5: 
                case 10:
                case 15:
                    yield return new WaitForSeconds(1f);
                    yield return StartCoroutine(uiManager.Shop());
                    break;
                default:
                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner1 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner1, "baseEnemy", 1, 2f, randomPosition));
                    break;
            }
        }
        StartCoroutine(CheckEnemies());
    }
}
