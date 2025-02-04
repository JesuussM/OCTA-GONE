using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public SpriteRenderer player;
    public SpriteRenderer shooter;
    public Camera mainCamera;
    public SpriteRenderer topBorder;
    public SpriteRenderer downBorder;
    public SpriteRenderer leftBorder;
    public SpriteRenderer rightBorder;
    public SpriteRenderer bullet;
    public SpriteRenderer enemySpawner;
    public SpriteRenderer baseEnemy;
    public SpriteRenderer fastEnemy;
    public SpriteRenderer tankEnemy;
    public SpriteRenderer sentryEnemy;
    public SpriteRenderer sentryBullet;

    // Start is called before the first frame update
    void Start()
    {
        player.color = new Color(.5281104f, .6454683f, .7490194f, 1f); // light blue
        shooter.color = new Color(120/255f, 134/255f, 155/255f, 1f); // dark grey
        bullet.color = new Color(161/255f, 160/255f, 167/255f, 1f); // lighter grey

        mainCamera.backgroundColor = new Color(0.8313726f, 0.827451f, 0.854902f, 1f); // light grey
        topBorder.color = new Color(180/255f, 187/255f, 203/255f, 1f); // bluish grey
        downBorder.color = new Color(180/255f, 187/255f, 203/255f, 1f);
        leftBorder.color = new Color(180/255f, 187/255f, 203/255f, 1f);
        rightBorder.color = new Color(180/255f, 187/255f, 203/255f, 1f);
        
        enemySpawner.color = new Color(206/255f, 173/255f, 183/255f, 1f); // hot pink
        baseEnemy.color = new Color(212/255f, 194/255f, 198/255f, 1f); // pink
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void colorTable(int round)
    {
        // TODO: Add the color changes for the rest of the rounds
        switch (round) 
        {
            case 2:
                StartCoroutine(TransitionColor(player, new Color(152/255f, 152/255f, 181/255f, 1f), 2f));
                // StartCoroutine(TransitionColor(shooter, new Color(0.8313726f, 0.827451f, 0.854902f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(145/255f, 151/255f, 174/255f, 1f), 2f));
                
                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(98/255f, 103/255f, 149/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(150/255f, 150/255f, 172/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(150/255f, 150/255f, 172/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(150/255f, 150/255f, 172/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(150/255f, 150/255f, 172/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(146/255f, 144/255f, 172/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(152/255f, 143/255f, 161/255f, 1f), 2f));

                break;
            default:
                break;
        }
    }


    public IEnumerator TransitionColor(SpriteRenderer spriteRenderer, Color targetColor, float duration)
    {
        Color initialColor = spriteRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            spriteRenderer.color = Color.Lerp(initialColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = targetColor;
    }

    private IEnumerator TransitionColor(Color backgroundColor, Color targetColor, float duration)
    {
        Color initialColor = mainCamera.backgroundColor;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            mainCamera.backgroundColor = Color.Lerp(initialColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.backgroundColor = targetColor;
    }
}