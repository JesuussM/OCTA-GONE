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
        
        // TODO: Add the enemy sprites
    }

    // Update is called once per frame
    void Update()
    {
        
        
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
}