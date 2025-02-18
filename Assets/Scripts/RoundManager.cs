using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class RoundManager : MonoBehaviour
{
    private bool testing = true; // ! Delete this when done testing
    private bool skipRounds = true; // ! Delete this when done testing
    private int TEST_startingRound = 13; // ! Delete this when done testing
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
                    yield return StartCoroutine(HandleSpawner(spawner21, "fastEnemy", 7, 0.75f, randomPosition)); // 7

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
                    yield return StartCoroutine(HandleSpawner(spawner26, "fastEnemy", 7, 1, randomPosition)); // 7

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
                    yield return StartCoroutine(uiManager.DisplayTextEffect("CONTROL", 0.1f));

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
                    yield return StartCoroutine(HandleSpawner(spawner35, "fastEnemy", 7, 1f, randomPosition)); // 7

                    break;
                case 10:
                    yield return new WaitForSeconds(1f);
                    yield return StartCoroutine(uiManager.Shop());
                    break;
                case 11:
                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner36 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner36, "tankEnemy", 5, 2f, randomPosition)); // 5

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner37 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner37, "baseEnemy", 4, 1f, randomPosition)); // 4

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner38 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner38, "tankEnemy", 6, 2f, randomPosition)); // 6

                    StartCoroutine(uiManager.DisplayTextEffect("", 0.1f));
                    StartCoroutine(uiManager.DisplaySkullEffect(0.1f));
                    yield return new WaitForSeconds(1f);
                    StartCoroutine(uiManager.DisplayTextEffect("", 0.1f));
                    StartCoroutine(uiManager.DisplaySkullEffect(0.1f));

                    yield return new WaitForSeconds(4f);
                    EnemySpawner spawner39 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner39, "baseEnemy", 4, 1f, randomPosition)); // 4

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner40 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner40, "tankEnemy", 6, 1f, randomPosition)); // 6

                    break;
                case 12:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner41 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner41, "tankEnemy", 5, 2f, randomPosition)); // 5

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner42 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner42, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner43 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner43, "baseEnemy", 5, 2f, randomPosition)); // 5
                    EnemySpawner spawner44 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner44, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner45 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner45, "tankEnemy", 6, 1f, randomPosition)); // 6

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner46 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner46, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(5f);
                    EnemySpawner spawner47 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner47, "tankEnemy", 6, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner48 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner48, "baseEnemy", 4, 1f, randomPosition)); // 1

                    break;
                case 13:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner49 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner49, "tankEnemy", 6, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner50 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner50, "fastEnemy", 7, 0.75f, randomPosition)); // 1

                    yield return new WaitForSeconds(5f);
                    EnemySpawner spawner51 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner51, "tankEnemy", 6, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(0.5f);
                    EnemySpawner spawner52 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner52, "baseEnemy", 4, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(0.5f);
                    EnemySpawner spawner53 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner53, "fastEnemy", 7, 0.75f, randomPosition)); // 6

                    yield return new WaitForSeconds(8f);
                    EnemySpawner spawner54 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner54, "fastEnemy", 7, 1f, randomPosition)); // 1

                    break;
                case 14:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner55 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner55, "baseEnemy", 4, 1f, randomPosition)); // 5


                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner56 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner56, "fastEnemy", 7, 0.75f, randomPosition)); // 1


                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner57 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner57, "baseEnemy", 4, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(4f);
                    EnemySpawner spawner58 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner58, "baseEnemy", 4, 1f, randomPosition)); // 6

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner59 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner59, "fastEnemy", 7, 0.75f, randomPosition)); // 1

                    yield return new WaitForSeconds(7f);
                    EnemySpawner spawner60 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner60, "fastEnemy", 7, 0.75f, randomPosition)); // 1

                    break;
                case 15:
                    yield return new WaitForSeconds(1f);
                    yield return StartCoroutine(uiManager.Shop());
                    break;
                case 16:
                case 21:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner61 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner61, "baseEnemy", 12, 1f, randomPosition)); // 5
                    EnemySpawner spawner62 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner62, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner63 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner63, "fastEnemy", 14, 0.75f, randomPosition)); // 5 
                    EnemySpawner spawner64 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner64, "sentryEnemy" , 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner65 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner65, "sentryEnemy", 1, 1f, randomPosition)); // 6

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner66 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner66, "baseEnemy ", 4, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(3f);
                    EnemySpawner spawner67 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner67, "fastEnemy", 7, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner68 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner68, "fastEnemy", 7, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner69 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner69, "baseEnemy", 4, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner70 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner70, "baseEnemy", 4, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner71 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner71, "fastEnemy", 7, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner72 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner72, "fastEnemy", 7, 1f, randomPosition)); // 1

                    break;
                case 17:
                case 22:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner73 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner73, "baseEnemy", 8, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner74 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner74, "tankEnemy", 6, 1f, randomPosition)); // 1
                    EnemySpawner spawner75 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner75, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner76 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner76, "fastEnemy", 7, 0.5f, randomPosition)); // 5

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner77 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner77, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner78 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner78, "tankEnemy", 5, 1f, randomPosition)); // 5
                    EnemySpawner spawner79 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner79, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner80 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner80, "baseEnemy", 4, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(2f);
                    // ? Loud thud sound effect

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner81 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner81, "fastEnemy", 7, 0.5f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner82 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner82, "tankEnemy", 6, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner83 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner83, "baseEnemy", 4, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(7f);
                    EnemySpawner spawner84 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner84, "fastEnemy", 7, 0.5f, randomPosition)); // 5

                    break;
                case 18:
                case 23:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner85 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner85, "baseEnemy", 8, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner86 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner86, "tankEnemy", 6, 1f, randomPosition)); // 1
                    EnemySpawner spawner87 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner87, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner88 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner88, "fastEnemy", 7, 0.5f, randomPosition)); // 5

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner89 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner89, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    StartCoroutine(uiManager.DisplaySkullEffect(0.1f));

                    EnemySpawner spawner90 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner90, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    uiManager.skullEffect.GetComponent<SpriteRenderer>().flipX = true;
                    StartCoroutine(uiManager.DisplaySkullEffect(0.1f));

                    EnemySpawner spawner91 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner91, "tankEnemy", 5, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(1f);
                    uiManager.skullEffect.GetComponent<SpriteRenderer>().flipX = false;
                    uiManager.skullEffect.GetComponent<SpriteRenderer>().transform.localPosition = new Vector2(-1270.68f, -586f);
                    uiManager.skullEffect.GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(0f, 0f, -12f);
                    uiManager.skullEffect.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(2f, 2f, 1f);
                    StartCoroutine(uiManager.DisplaySkullEffect(0.1f));

                    EnemySpawner spawner92 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner92, "baseEnemy", 4, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner93 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner93, "fastEnemy", 7, 0.5f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    StartCoroutine(colorManager.ChangeToWavyShader(colorManager.topBorder, colorManager.wavyShader, colorManager.topBorder.color, 0.3f, 10f, 10f));
                    StartCoroutine(colorManager.ChangeToWavyShader(colorManager.downBorder, colorManager.wavyShader, colorManager.downBorder.color, 0.3f, 10f, 10f));
                    StartCoroutine(colorManager.ChangeToWavyShader(colorManager.leftBorder, colorManager.wavyShader, colorManager.leftBorder.color, 0.3f, 10f, 10f));
                    StartCoroutine(colorManager.ChangeToWavyShader(colorManager.rightBorder, colorManager.wavyShader, colorManager.rightBorder.color, 0.3f, 10f, 10f));


                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner94 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner94, "tankEnemy", 6, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner95 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner95, "baseEnemy", 4, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(2f);
                    StartCoroutine(colorManager.TransitionMaterial(colorManager.topBorder, colorManager.defaultShader, 1f));
                    StartCoroutine(colorManager.TransitionMaterial(colorManager.downBorder, colorManager.defaultShader, 1f));
                    StartCoroutine(colorManager.TransitionMaterial(colorManager.leftBorder, colorManager.defaultShader, 1f));
                    StartCoroutine(colorManager.TransitionMaterial(colorManager.rightBorder, colorManager.defaultShader, 1f));

                    yield return new WaitForSeconds(5f);
                    EnemySpawner spawner96 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner96, "fastEnemy", 7, 0.5f, randomPosition)); // 5

                    break;
                case 19:
                case 24:
                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner97 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner97, "baseEnemy", 8, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner98 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner98, "tankEnemy", 6, 1f, randomPosition)); // 1
                    EnemySpawner spawner99 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner99, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner100 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner100, "fastEnemy", 7, 0.5f, randomPosition)); // 5

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner101 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner101, "sentryEnemy", 1, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner102 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner102, "sentryEnemy", 1, 1f, randomPosition)); // 1
                    EnemySpawner spawner103 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner103, "tankEnemy", 5, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(3f);
                    uiManager.DisplayTextEffect("DIE", 0.1f);

                    yield return new WaitForSeconds(0.5f);
                    uiManager.DisplayTextEffect("TO", 0.1f);
                    EnemySpawner spawner104 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner104, "baseEnemy", 4, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(0.5f);
                    uiManager.DisplayTextEffect("ESCAPE", 0.1f);

                    yield return new WaitForSeconds(0.2f);
                    uiManager.DisplaySkullEffect(1f);

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner105 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner105, "fastEnemy", 7, 0.5f, randomPosition)); // 1

                    yield return new WaitForSeconds(1f);
                    EnemySpawner spawner106 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner106, "tankEnemy", 6, 1f, randomPosition)); // 5

                    yield return new WaitForSeconds(2f);
                    EnemySpawner spawner107 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    StartCoroutine(HandleSpawner(spawner107, "baseEnemy", 4, 1f, randomPosition)); // 1

                    yield return new WaitForSeconds(7f);
                    EnemySpawner spawner108 = Instantiate(enemySpawner, getRandomLocation(), Quaternion.identity);
                    yield return StartCoroutine(HandleSpawner(spawner108, "fastEnemy", 7, 0.5f, randomPosition)); // 5

                    break;
                case 20:
                case 25:
                    yield return new WaitForSeconds(1f);
                    yield return StartCoroutine(uiManager.Shop());
                    break;
                case 26:
                    // TODO: Add game over screen
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
