using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 1;
    public int health = 1;
    public int points = 0;
    private GameObject player;
    private bool isMovementBoostActive = false;
    private bool sentryCanShoot = false;
    public EnemyBullet enemyBullet;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (!isMovementBoostActive) 
        {
            StartCoroutine(MovementBoost());
        }

        if (!sentryCanShoot)
        {
            StartCoroutine(SentryShoot());
        }
    }

    private IEnumerator MovementBoost()
    {
        if (gameObject.name == "TankEnemy(Clone)")
        {
            isMovementBoostActive = true;
            enemySpeed = 1.25f;
            yield return new WaitForSeconds(0.25f);
            enemySpeed = 0.75f;
            yield return new WaitForSeconds(0.25f);
            isMovementBoostActive = false;
        }

    }

    private IEnumerator SentryShoot()
    {
        if (gameObject.name == "SentryEnemy(Clone)")
        {
            sentryCanShoot = true;
            EnemyBullet bullet = Instantiate(enemyBullet, gameObject.transform.position + gameObject.transform.up * 0.25f, Quaternion.Euler(0, 0, Random.Range(-360f, 360f)));
            bullet.rigidBody.AddForce(gameObject.transform.up * 1.5f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(2.5f);
            sentryCanShoot = false;
        }
    }
}
