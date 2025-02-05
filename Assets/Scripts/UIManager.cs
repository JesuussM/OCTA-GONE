using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text waveCountText;
    public Text centerText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        waveCountText.gameObject.SetActive(false);
        centerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void UpdateAndDisplayWave(string topText)
    {
        waveCountText.text = topText;
    }

    public void UpdateAndDisplayCenterText(string message)
    {
        centerText.text = message;
    }

    public IEnumerator FadeInText(Text text, Text message)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        message.color = new Color(message.color.r, message.color.g, message.color.b, 0);
        text.gameObject.SetActive(true);
        message.gameObject.SetActive(true);
        for (float t = 0.0f; t < 0.5f; t += Time.deltaTime)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, t * 2);
            message.color = new Color(message.color.r, message.color.g, message.color.b, t * 2);
            yield return null;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        message.color = new Color(message.color.r, message.color.g, message.color.b, 1);
    }

    public IEnumerator FadeOutText(Text text, Text message)
    {
        yield return new WaitForSeconds(2f);
        for (float t = 0.0f; t < 1f; t += Time.deltaTime)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f - t);
            message.color = new Color(message.color.r, message.color.g, message.color.b, 1.0f - t);
            yield return null;
        }
        text.gameObject.SetActive(false);
        message.gameObject.SetActive(false);
    }

    public void TextTable(int round) 
    {
        // TODO: Add the text changes for the rest of the rounds
        switch (round)
        {
            case 2:
            case 3:
                UpdateAndDisplayWave("W A V E  " + round);
                UpdateAndDisplayCenterText("W A V E  C O M P L E T E ");
                break;
            default:
                break;
        }
    }
}
