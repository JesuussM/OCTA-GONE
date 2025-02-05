using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public Rigidbody2D rigidBody;
    public SpriteRenderer bulletSprite => GetComponent<SpriteRenderer>();

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
            Destroy(bullet);
            // TODO: Add animation and sound effect
        }

        if (collision.gameObject.tag == "Enemy")
        {
            var uiManager = FindObjectOfType<UIManager>();
            if (collision.gameObject.GetComponent<Enemy>().health > 1)
            {
                collision.gameObject.GetComponent<Enemy>().health--;
            }
            else
            {
                Destroy(collision.gameObject);
                Destroy(bullet);
                uiManager.UpdateScore(collision.gameObject.GetComponent<Enemy>().points);
                // TODO: Add animation and sound effect
            }
        }
    }
}
