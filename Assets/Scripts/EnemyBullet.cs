using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject enemyBullet;
    public Rigidbody2D rigidBody;
    public SpriteRenderer enemyBulletSprite => GetComponent<SpriteRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Top Boundary" || 
            collision.gameObject.name == "Bottom Boundary" || 
            collision.gameObject.name == "Left Boundary" || 
            collision.gameObject.name == "Right Boundary")
        {
            Destroy(enemyBullet);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(enemyBullet);
        }
    }
}
