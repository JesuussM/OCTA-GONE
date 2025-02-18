using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public SpriteRenderer textEffectBackground;
    public Shader staticShader;
    public Shader wavyShader;
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
        switch (round) 
        {
            case 2:
                StartCoroutine(TransitionColor(player, new Color(152/255f, 152/255f, 181/255f, 1f), 2f));
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
            case 10:
            case 15:
            case 20:
                StartCoroutine(TransitionColor(player, new Color(157/225f, 186/255f, 217/255f, 1f), 2f));
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
            case 11:
                StartCoroutine(TransitionColor(player, new Color(124/255f, 33/255f, 31/255f, 1f), 2f));
                StartCoroutine(ChangeToWavyShader(player, wavyShader, new Color(124/255f, 33/255f, 31/255f, 1f), 0.15f, 5f, 5f));
                StartCoroutine(TransitionColor(bullet, new Color(126/255f, 27/255f, 28/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(126/255f, 27/255f, 28/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(224/255f, 104/255f, 25/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(127/255f, 32/255f, 34/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(127/255f, 32/255f, 34/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(127/255f, 32/255f, 34/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(127/255f, 32/255f, 34/255f, 1f), 2f));
                StartCoroutine(ChangeToWavyShader(topBorder, wavyShader, new Color(127/255f, 32/255f, 34/255f, 1f), 0.13f, 2.75f, 1.7f));
                StartCoroutine(ChangeToWavyShader(downBorder, wavyShader, new Color(127/255f, 32/255f, 34/255f, 1f), 0.13f, 2.75f, 1.7f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(161/255f, 27/255f, 10/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(194/255f, 45/255f, 25/255f, 1f), 2f));
                StartCoroutine(TransitionColor(tankEnemy, new Color(199/255f, 51/255f, 30/255f, 1f), 2f));

                textEffectBackground.sortingLayerName = "Effects";
                textEffectBackground.sortingOrder = -1;
                StartCoroutine(TransitionColor(textEffectBackground, new Color(180/255f, 53/255f, 11/255f, 235/255f), 2f));
                StartCoroutine(TransitionColor(skullEffect, new Color(210/255f, 76/255f, 37/255f, 1f), 2f));
                break;
            case 12:
                StartCoroutine(TransitionMaterial(player, defaultShader, 2f));
                StartCoroutine(TransitionColor(player, new Color(37/255f, 144/255f, 216/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(23/255f, 18/255f, 34/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(23/255f, 18/255f, 34/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(206/255f, 207/255f, 218/255f, 1f), 2f));
                StartCoroutine(TransitionMaterial(topBorder, defaultShader, 2f));
                StartCoroutine(TransitionMaterial(downBorder, defaultShader, 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(112/255f, 148/255f, 194/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(112/255f, 148/255f, 194/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(112/255f, 148/255f, 194/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(112/255f, 148/255f, 194/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(191/255f, 53/255f, 58/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(207/255f, 167/255f, 168/255f, 1f), 2f));
                StartCoroutine(TransitionColor(tankEnemy, new Color(201/255f, 141/255f, 32/255f, 1f), 2f));
                StartCoroutine(TransitionColor(sentryEnemy, new Color(207/255f, 178/255f, 154/255f, 1f), 2f));
                StartCoroutine(TransitionColor(sentryBullet, new Color(23/255f, 18/255f, 34/255f, 1f), 2f));

                textEffectBackground.sortingLayerName = "Default";
                textEffectBackground.sortingOrder = 10;
                StartCoroutine(TransitionColor(textEffectBackground, new Color(34/255f, 28/255f, 28/255f, 1f), 2f));
                
                break;
            case 13:
                StartCoroutine(TransitionColor(player, new Color(162/255f, 150/255f, 169/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(168/255f, 151/255f, 153/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(168/255f, 151/255f, 153/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(148/255f, 95/255f, 100/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(167/255f, 151/255f, 159/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(167/255f, 151/255f, 159/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(167/255f, 151/255f, 159/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(167/255f, 151/255f, 159/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(185/255f, 146/255f, 149/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(170/255f, 139/255f, 142/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(172/255f, 140/255f, 140/255f, 1f), 2f));
                StartCoroutine(TransitionColor(tankEnemy, new Color(177/255f, 147/255f, 144/255f, 1f), 2f));

                break;
            case 14:
                StartCoroutine(TransitionColor(player, new Color(39/255f, 161/255f, 218/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(44/255f, 45/255f, 63/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(44/255f, 45/255f, 63/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(206/255f, 207/255f, 221/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(143/255f, 158/255f, 197/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(143/255f, 158/255f, 197/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(143/255f, 158/255f, 197/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(143/255f, 158/255f, 197/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(182/255f, 91/255f, 115/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(207/255f, 175/255f, 184/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(208/255f, 179/255f, 156/255f, 1f), 2f));

                break;
            case 16:
            case 21:
                StartCoroutine(TransitionColor(player, new Color(38/255f, 21/255f, 223/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(66/255f, 46/255f, 82/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(66/255f, 46/255f, 82/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(29/255f, 16/255f, 17/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(162/255f, 23/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(162/255f, 23/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(162/255f, 23/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(162/255f, 23/255f, 203/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(215/255f, 41/255f, 113/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(197/255f, 30/255f, 161/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(198/255f, 27/255f, 126/255f, 1f), 2f));
                StartCoroutine(TransitionColor(sentryEnemy, new Color(191/255f, 26/255f, 140/255f, 1f), 2f));
                StartCoroutine(TransitionColor(sentryBullet, new Color(148/255f, 64/255f, 160/255f, 1f), 2f));
                
                break;
            case 17:
            case 22:
                StartCoroutine(TransitionColor(player, new Color(223/255f, 31/255f, 219/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(34/255f, 13/255f, 23/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(34/255f, 13/255f, 23/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(198/255f, 166/255f, 196/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(208/255f, 31/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(208/255f, 31/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(208/255f, 31/255f, 203/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(208/255f, 31/255f, 203/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(172/255f, 192/255f, 81/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(184/255f, 193/255f, 31/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(158/255f, 197/255f, 27/255f, 1f), 2f));
                StartCoroutine(TransitionColor(tankEnemy, new Color(56/255f, 201/255f, 24/255f, 1f), 2f));
                StartCoroutine(TransitionColor(sentryEnemy, new Color(159/255f, 191/255f, 46/255f, 1f), 2f));
                StartCoroutine(TransitionColor(sentryBullet, new Color(34/255f, 13/255f, 23/255f, 1f), 2f));

                break;
            case 18:
            case 23:
                StartCoroutine(TransitionColor(player, new Color(217/255f, 211/255f, 214/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(169/255f, 158/255f, 160/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(169/255f, 158/255f, 160/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(229/255f, 223/255f, 226/255f, 1f), 2f));
                StartCoroutine(ColorFlip(topBorder, Color.white, Color.yellow, Color.red, Color.black, true));
                StartCoroutine(ColorFlip(downBorder, Color.white, Color.yellow, Color.red, Color.black, true));
                StartCoroutine(ColorFlip(leftBorder, Color.white, Color.yellow, Color.red, Color.black, true));
                StartCoroutine(ColorFlip(rightBorder, Color.white, Color.yellow, Color.red, Color.black, true));

                StartCoroutine(TransitionColor(enemySpawner, new Color(176/255f, 167/255f, 170/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(161/255f, 137/255f, 142/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(181/255f, 157/255f, 164/255f, 1f), 2f));
                StartCoroutine(TransitionColor(tankEnemy, new Color(171/255f, 144/255f, 152/255f, 1f), 2f));
                StartCoroutine(TransitionColor(sentryEnemy, new Color(183/255f, 161/255f, 173/255f, 1f), 2f));
                StartCoroutine(TransitionColor(sentryBullet, new Color(169/255f, 158/255f, 160/255f, 1f), 2f));

                StartCoroutine(ColorFlip(skullEffect, Color.white, Color.yellow, Color.red, Color.black, true));

                break;
            case 19:
            case 24:
                StartCoroutine(ColorFlip(topBorder, Color.white, Color.yellow, Color.red, Color.black, false));
                StartCoroutine(ColorFlip(downBorder, Color.white, Color.yellow, Color.red, Color.black, false));
                StartCoroutine(ColorFlip(leftBorder, Color.white, Color.yellow, Color.red, Color.black, false));
                StartCoroutine(ColorFlip(rightBorder, Color.white, Color.yellow, Color.red, Color.black, false));
                StartCoroutine(ColorFlip(skullEffect, Color.white, Color.yellow, Color.red, Color.black, false));


                StartCoroutine(TransitionColor(player, new Color(30/255f, 22/255f, 152/255f, 1f), 2f));
                StartCoroutine(TransitionColor(bullet, new Color(34/255f, 16/255f, 26/255f, 1f), 2f));
                StartCoroutine(TransitionColor(enemyDeathAnimation, new Color(34/255f, 16/255f, 26/255f, 1f), 2f));

                StartCoroutine(TransitionColor(mainCamera.backgroundColor, new Color(35/255f, 162/255f, 229/255f, 1f), 2f));
                StartCoroutine(TransitionColor(topBorder, new Color(30/255f, 39/255f, 158/255f, 1f), 2f));
                StartCoroutine(TransitionColor(downBorder, new Color(30/255f, 39/255f, 158/255f, 1f), 2f));
                StartCoroutine(TransitionColor(leftBorder, new Color(30/255f, 39/255f, 158/255f, 1f), 2f));
                StartCoroutine(TransitionColor(rightBorder, new Color(30/255f, 39/255f, 158/255f, 1f), 2f));

                StartCoroutine(TransitionColor(enemySpawner, new Color(10/255f, 45/255f, 124/255f, 1f), 2f));
                StartCoroutine(TransitionColor(baseEnemy, new Color(37/255f, 71/255f, 183/255f, 1f), 2f));
                StartCoroutine(TransitionColor(fastEnemy, new Color(38/255f, 73/255f, 178/255f, 1f), 2f));
                StartCoroutine(TransitionColor(tankEnemy, new Color(24/255f, 34/255f, 104/255f, 1f), 2f));
                StartCoroutine(TransitionColor(sentryEnemy, new Color(36/255f, 85/255f, 188/255f, 1f), 2f));
                StartCoroutine(TransitionColor(sentryBullet, new Color(34/255f, 16/255f, 26/255f, 1f), 2f));

                StartCoroutine(TransitionColor(skullEffect, new Color(61/255f, 99/255f, 243/255f, 1f), 2f));
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

    public IEnumerator TransitionMaterial(SpriteRenderer sprite, Shader shader, float duration)
    {
        yield return new WaitForSeconds(2f);
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
    public IEnumerator ChangeToWavyShader(SpriteRenderer sprite, Shader shader, Color color, float strength, float speed, float frequency)
    {
        yield return new WaitForSeconds(2f);
        sprite.material = new Material(shader);
        sprite.material.SetColor("_Color", color);
        sprite.material.SetFloat("_WaveStrength", strength);
        sprite.material.SetFloat("_WaveSpeed", speed);
        sprite.material.SetFloat("_WaveFrequency", frequency);
    }

    public IEnumerator ColorFlip(SpriteRenderer spriteRenderer, Color color1, Color color2, Color color3, Color color4, bool on) 
    {
        while (on)
        {
            yield return StartCoroutine(TransitionColor(spriteRenderer, color1, 0.2f));
            yield return StartCoroutine(TransitionColor(spriteRenderer, color2, 0.2f));
            yield return StartCoroutine(TransitionColor(spriteRenderer, color3, 0.2f));
            yield return StartCoroutine(TransitionColor(spriteRenderer, color4, 0.2f));
        }
    }
}