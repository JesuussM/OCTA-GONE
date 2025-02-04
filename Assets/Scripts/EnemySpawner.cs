using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemySpawer;
    public GameObject baseEnemy;
    public GameObject fastEnemy;
    public GameObject tankEnemy;
    public GameObject sentryEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnEnemies(string enemyType, int amount, float delay, Vector2 position) 
    {
        yield return new WaitForSeconds(1f);
        switch (enemyType)
        {
            case "baseEnemy":
                for (int i = 0; i < amount; i++)
                {   
                    Instantiate(baseEnemy, position, Quaternion.identity);
                    yield return new WaitForSeconds(delay);
                }
                break;
            case "fastEnemy":
                for (int i = 0; i < amount; i++)
                {
                    Instantiate(fastEnemy, position, Quaternion.identity);
                    yield return new WaitForSeconds(delay);
                }
                break;
            case "tankEnemy":
                for (int i = 0; i < amount; i++)
                {
                    Instantiate(tankEnemy, position, Quaternion.identity);
                    yield return new WaitForSeconds(delay);
                }
                break;
            case "sentryEnemy":
                for (int i = 0; i < amount; i++)
                {
                    Instantiate(sentryEnemy, position, Quaternion.identity);
                    yield return new WaitForSeconds(delay);
                }
                break;
            default:
                Debug.Log("Error: Invalid enemy type");
                break;
        }
    }
}
