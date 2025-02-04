using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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
        yield return new WaitForSeconds(2f);
        switch (enemyType)
        {
            case "baseEnemy":
                for (int i = 0; i < amount; i++)
                {   
                    GameObject enemy = Instantiate(baseEnemy, position, Quaternion.identity);
                    StartCoroutine(EnemySpawnAnimation(enemy));
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

    public IEnumerator FadeInSpawner(EnemySpawner enemySpawner)
    {
        SpriteRenderer sprite = enemySpawner.GetComponent<SpriteRenderer>();
        for (float t = 0.0f; t < 0.5f; t += Time.deltaTime)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, t * 2);
            yield return null;
        }
    }

    public IEnumerator FadeOutSpawner(EnemySpawner enemySpawner)
    {
        SpriteRenderer sprite = enemySpawner.GetComponent<SpriteRenderer>();
        for (float t = 0.0f; t < 0.5f; t += Time.deltaTime)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1.0f - t * 2);
            yield return null;
        }
        Destroy(enemySpawner);
    }

    private IEnumerator EnemySpawnAnimation(GameObject enemy)
    {
        Enemy enemyObject = enemy.GetComponent<Enemy>();
        float initialSpeed = enemyObject.enemySpeed;
        enemyObject.enemySpeed = 0f;

        Vector2 initialScale = enemy.transform.localScale;
        enemy.transform.localScale = Vector2.zero;
        for (float t = 0.0f; t < 0.5f; t += Time.deltaTime)
        {
            enemy.transform.localScale = Vector2.Lerp(Vector2.zero, initialScale, t * 2);
            yield return null;
        }
        enemy.transform.localScale = initialScale;

        enemyObject.enemySpeed = initialSpeed;
    }
}
