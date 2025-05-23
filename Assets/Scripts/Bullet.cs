using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public Rigidbody2D rigidBody;
    public SpriteRenderer bulletSprite => GetComponent<SpriteRenderer>();
    public GameObject enemyDeathAnimation;
    public AudioClip bullethitSfx;
    public AudioClip destroySfx;

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
            SoundManager.instance.PlaySound(bullethitSfx, 0.25f);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            var uiManager = FindObjectOfType<UIManager>();
            if (collision.gameObject.GetComponent<Enemy>().health > 1)
            {
                collision.gameObject.GetComponent<Enemy>().health--;
                 SoundManager.instance.PlaySound(bullethitSfx, 0.25f);
            }
            else
            {
                Destroy(collision.gameObject);
                uiManager.UpdateScore(collision.gameObject.GetComponent<Enemy>().points);

                var instantiatedAnimation = Instantiate(enemyDeathAnimation, collision.gameObject.transform.position, collision.gameObject.transform.rotation * Quaternion.Euler(0, 0, 90));
                Animator animator = instantiatedAnimation.GetComponent<Animator>();
                AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
                float clipLength = clipInfo[0].clip.length;
                Destroy(instantiatedAnimation, clipLength);
                
                 SoundManager.instance.PlaySound(destroySfx, 0.5f);
            }
            Destroy(bullet);
        }
    }
}
