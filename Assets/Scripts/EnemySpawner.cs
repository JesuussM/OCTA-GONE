using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemySpawer;
    public GameObject baseEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TODO: Finish this method for the other enemy types
    public IEnumerator SpawnEnemies(string enemyType, int amount, float delay, Vector2 position) 
    {
        yield return new WaitForSeconds(1f);
        switch (enemyType)
        {
            case "baseEnemy":
                for (int i = 0; i < amount; i++)
                {
                    
                    Instantiate(baseEnemy, position, Quaternion.identity);
                    Debug.Log("base enemy spawner");
                    yield return new WaitForSeconds(delay);
                }
                break;
            case "fastEnemy":
                Debug.Log("fast enemy spawner");
                break;
            case "tankEnemy":
                Debug.Log("tank enemy spawner");
                break;
            case "sentryEnemy":
                Debug.Log("sentry enemy spawner");
                break;
            default:
                Debug.Log("Error: Invalid enemy type");
                break;
        }
    }
}
