using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public SpriteRenderer player;
    public SpriteRenderer shooter;
    public SpriteRenderer leftShooter;
    public SpriteRenderer rightShooter;
    public SpriteRenderer bullet;
    public SpriteRenderer enemyDeathAnimation;
    public Camera mainCamera;
    public SpriteRenderer topBorder;
    public SpriteRenderer downBorder;
    public SpriteRenderer leftBorder;
    public SpriteRenderer rightBorder;
    public SpriteRenderer enemySpawner;
    public SpriteRenderer baseEnemy;
    public SpriteRenderer fastEnemy;
    public SpriteRenderer tankEnemy;
    public SpriteRenderer sentryEnemy;
    public SpriteRenderer sentryBullet;
    public SpriteRenderer skullEffect;
    public Shader staticShader;
    public Shader defaultShader;

    // Start is called before the first frame update
    void Start()
    {
        player.color = new Color(.5281104f, .6454683f, .7490194f, 1f); // light blue
        shooter.color = new Color(25/255f, 20/255f, 10/255f, 1f); // black
        leftShooter.color = new Color(25/255f, 20/255f, 10/255f, 1f); // black
        rightShooter.color = new Color(25/255f, 20/255f, 10/255f, 1f); // black
        bullet.color = new Color(161/255f, 160/255f, 167/255f, 1f); // lighter grey
        enemyDeathAnimation.color = new Color(161/255f, 160/255f, 167/255f, 1f); // lighter grey

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
                StartCoroutine(TransitionColor(shooter, new Color(25/255f, 20/255f, 10/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftShooter, new Color(25/255f, 20/255f, 10/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightShooter, new Color(25/255f, 20/255f, 10/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(145/255f, 151/255f, 174/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(145/255f, 151/255f, 174/255f, 1f), 2f));
                
                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(98/255f, 103/255f, 149/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(150/255f, 150/255f, 172/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(150/255f, 150/255f, 172/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(150/255f, 150/255f, 172/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(150/255f, 150/255f, 172/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(146/255f, 144/255f, 172/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(152/255f, 143/255f, 161/255f, 1f), 2f));
                break;
            case 3:
                StartCoroutine(TransitionColor(player, new Color(205/255f, 188/255f, 34/255f, 1f), 2f));
                StartCoroutine(TransitionColor(shooter, new Color(25/255f, 20/255f, 10/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftShooter, new Color(25/255f, 20/255f, 10/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightShooter, new Color(25/255f, 20/255f, 10/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(25/255f, 20/255f, 10/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(25/255f, 20/255f, 10/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(207/255f, 205/255f, 197/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(180/255f, 168/255f, 89/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(180/255f, 168/255f, 89/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(180/255f, 168/255f, 89/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(180/255f, 168/255f, 89/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(82/255f, 179/255f, 174/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(128/255f, 187/255f, 192/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(84/255f, 181/255f, 202/255f, 1f), 2f));
                break;
            case 4:
                StartCoroutine(TransitionColor(player, new Color(205/255f, 187/255f, 170/255f, 1f), 2f));
                StartCoroutine(TransitionColor(shooter, new Color(32/255f, 21/255f, 18/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftShooter, new Color(32/255f, 21/255f, 18/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightShooter, new Color(32/255f, 21/255f, 18/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(32/255f, 21/255f, 18/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(32/255f, 21/255f, 18/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(156/255f, 147/255f, 145/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(187/255f, 165/255f, 144/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(187/255f, 165/255f, 144/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(187/255f, 165/255f, 144/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(187/255f, 165/255f, 144/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(174/255f, 194/255f, 187/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(176/255f, 191/255f, 190/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(165/255f, 192/255f, 198/255f, 1f), 2f));
                break;
            case 5:
                StartCoroutine(TransitionColor(player, new Color(157/225f, 186/255f, 217/255f, 1f), 2f));
                StartCoroutine(TransitionColor(shooter, new Color(120/255f, 134/255f, 155/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftShooter, new Color(120/255f, 134/255f, 155/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightShooter, new Color(120/255f, 134/255f, 155/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(161/255f, 160/255f, 167/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(161/255f, 160/255f, 167/255f, 1f), 2f));
                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(0.8313726f, 0.827451f, 0.854902f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(180/255f, 187/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(180/255f, 187/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(180/255f, 187/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(180/255f, 187/255f, 203/255f, 1f), 2f));
                break;
            case 6:
                StartCoroutine(TransitionColor(player, new Color(210/255f, 32/255f, 25/255f, 1f), 2f));
                StartCoroutine(TransitionColor(shooter, new Color(34/255f, 11/255f, 34/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftShooter, new Color(34/255f, 11/255f, 34/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightShooter, new Color(34/255f, 11/255f, 34/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(34/255f, 11/255f, 34/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(34/255f, 11/255f, 34/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(151/255f, 94/255f, 124/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(110/255f, 22/255f, 19/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(110/255f, 22/255f, 19/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(110/255f, 22/255f, 19/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(110/255f, 22/255f, 19/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(58/255f, 135/255f, 38/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(43/255f, 120/255f, 20/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(41/255f, 135/255f, 24/255f, 1f), 2f));
                break;
            case 7:
                StartCoroutine(TransitionMaterial(player, staticShader, 2f));
                StartCoroutine(TransitionColor(shooter, new Color(111/255f, 31/255f, 44/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftShooter, new Color(111/255f, 31/255f, 44/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightShooter, new Color(111/255f, 31/255f, 44/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(111/255f, 31/255f, 44/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(111/255f, 31/255f, 44/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(223/255f, 219/255f, 218/255f, 1f), 2f));
                StartCoroutine(TransitionMaterial(topBorder, staticShader, 2f));
                StartCoroutine(TransitionMaterial(downBorder, staticShader, 2f));
                StartCoroutine(TransitionMaterial(leftBorder, staticShader, 2f));
                StartCoroutine(TransitionMaterial(rightBorder, staticShader, 2f));
                StartCoroutine(TransitionColor(skullEffect, new Color(197/255f, 193/255f, 193/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(153/255f, 135/255f, 135/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(196/255f, 186/255f, 181/255f, 1f), 2f));
                break;
            case 8:
                StartCoroutine(TransitionMaterial(player, defaultShader, 2f));
                StartCoroutine(TransitionMaterial(topBorder, defaultShader, 2f));
                StartCoroutine(TransitionMaterial(downBorder, defaultShader, 2f));
                StartCoroutine(TransitionMaterial(leftBorder, defaultShader, 2f));
                StartCoroutine(TransitionMaterial(rightBorder, defaultShader, 2f));

                StartCoroutine(TransitionColor(player, new Color(98/255f, 124/255f, 213/255f, 1f), 2f));
                StartCoroutine(TransitionColor(shooter, new Color(20/255f, 19/255f, 37/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftShooter, new Color(20/255f, 19/255f, 37/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightShooter, new Color(20/255f, 19/255f, 37/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(20/255f, 19/255f, 37/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(20/255f, 19/255f, 37/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(154/255f, 198/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(78/255f, 107/255f, 180/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(78/255f, 107/255f, 180/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(78/255f, 107/255f, 180/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(78/255f, 107/255f, 180/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(170/255f, 121/255f, 130/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(183/255f, 164/255f, 176/255f, 1f), 2f));
                StartCoroutine(TransitionColor(tankEnemy, new Color(176/255f, 124/255f, 114/255f, 1f), 2f));
                break;
            case 9:
                StartCoroutine(TransitionColor(player, new Color(87/255f, 124/255f, 205/255f, 1f), 2f));
                StartCoroutine(TransitionColor(shooter, new Color(65/255f, 71/255f, 127/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftShooter, new Color(65/255f, 71/255f, 127/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightShooter, new Color(65/255f, 71/255f, 127/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(65/255f, 71/255f, 127/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(65/255f, 71/255f, 127/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(195/255f, 204/255f, 223/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(99/255f, 121/255f, 186/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(99/255f, 121/255f, 186/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(99/255f, 121/255f, 186/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(99/255f, 121/255f, 186/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(115/255f, 111/255f, 153/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(162/255f, 161/255f, 195/255f, 1f), 2f));
                StartCoroutine(TransitionColor(tankEnemy, new Color(135/255f, 134/255f, 170/255f, 1f), 2f));
                break;
            case 10:
                StartCoroutine(TransitionColor(player, new Color(157/225f, 186/255f, 217/255f, 1f), 2f));
                StartCoroutine(TransitionColor(shooter, new Color(120/255f, 134/255f, 155/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftShooter, new Color(120/255f, 134/255f, 155/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightShooter, new Color(120/255f, 134/255f, 155/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(161/255f, 160/255f, 167/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(161/255f, 160/255f, 167/255f, 1f), 2f));
                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(0.8313726f, 0.827451f, 0.854902f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(180/255f, 187/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(180/255f, 187/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(180/255f, 187/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(180/255f, 187/255f, 203/255f, 1f), 2f));
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
        Color initialColor = backgroundColor;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            mainCamera.backgroundColor = Color.Lerp(initialColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.backgroundColor = targetColor;
    }

    private IEnumerator TransitionMaterial(SpriteRenderer sprite, Shader shader, float duration)
    {
        sprite.material = new Material(shader);
        sprite.material.SetFloat("_Transparency", 0f);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            sprite.material.SetFloat("_Transparency", elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        sprite.material.SetFloat("_Transparency", 1f);
    }
}