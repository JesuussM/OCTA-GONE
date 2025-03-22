using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text waveCountText;
    public Text centerText;
    public int score;
    public static int finalScore;
    public GameObject leftShopCircle;
    public Text leftShopText;
    public GameObject rightShopCircle;
    public Text rightShopText;
    public bool upgradeSelected = false;
    public Player player;
    public GameObject blackOutEffect;
    public GameObject staticEffect;
    public GameObject skullEffect;
    public GameObject textEffectBackground;
    public Text textEffect;
    private Coroutine scoreAnimationCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString("N0");
        waveCountText.gameObject.SetActive(false);
        centerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        finalScore = score;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = score.ToString("N0");
        
        if (scoreAnimationCoroutine != null)
        {
            StopCoroutine(scoreAnimationCoroutine);
        }
        scoreAnimationCoroutine = StartCoroutine(ScoreGainAnimation());
    }

    private IEnumerator ScoreGainAnimation()
    {
        Vector2 initialScale = scoreText.transform.localScale;
        Vector2 targetScale = initialScale * 1.2f;
        Color initialColor = scoreText.color;
        Color targetColor = Color.white;
    
        for (float t = 0.0f; t < 1f; t += Time.deltaTime / 0.2f)
        {
            scoreText.transform.localScale = Vector2.Lerp(initialScale, targetScale, t);
            scoreText.color = Color.Lerp(initialColor, targetColor, t);
            yield return null;
        }
        scoreText.transform.localScale = targetScale;
    
        for (float t = 0.0f; t < 1f; t += Time.deltaTime / 0.2f)
        {
            scoreText.transform.localScale = Vector2.Lerp(targetScale, initialScale, t);
            scoreText.color = Color.Lerp(targetColor, initialColor, t);
            yield return null;
        }
        scoreText.transform.localScale = initialScale;
        scoreAnimationCoroutine = null;
    }

    public void UpdateTopText(string topText)
    {
        waveCountText.text = topText;
    }

    public void UpdateCenterText(string message)
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
        for (float t = 0.0f; t < 1f; t += Time.deltaTime)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f - t);
            message.color = new Color(message.color.r, message.color.g, message.color.b, 1.0f - t);
            yield return null;
        }
        text.gameObject.SetActive(false);
        message.gameObject.SetActive(false);
    }

    public IEnumerator DisplayBlackOutEffect(float duration)
    {
        blackOutEffect.SetActive(true);
        yield return new WaitForSeconds(duration);
        blackOutEffect.SetActive(false);
    }

    public IEnumerator DisplayStaticEffect(float duration, float transparency)
    {
        staticEffect.SetActive(true);
        staticEffect.GetComponent<SpriteRenderer>().material.SetFloat("_Transparency", transparency);
        yield return new WaitForSeconds(duration);
        staticEffect.SetActive(false);
    }

    public IEnumerator DisplaySkullEffect(float duration)
    {
        skullEffect.SetActive(true);
        yield return new WaitForSeconds(duration);
        skullEffect.SetActive(false);
    }

    public IEnumerator DisplayTextEffect(string message, float duration)
    {
        textEffect.text = message;
        textEffectBackground.SetActive(true);
        textEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        textEffect.gameObject.SetActive(false);
        textEffectBackground.SetActive(false);
    }

    public IEnumerator Shop()
    {
        yield return StartCoroutine(player.MovePlayerInShop());
        SpriteRenderer leftShopSprite = leftShopCircle.GetComponent<SpriteRenderer>();
        SpriteRenderer rightShopSprite = rightShopCircle.GetComponent<SpriteRenderer>();
        leftShopCircle.SetActive(true);
        rightShopCircle.SetActive(true);

        StartCoroutine(FadeInText(leftShopText, rightShopText));
        UpdateTopText("");
        UpdateCenterText("C H O O S E   A N   U P G R A D E");
        StartCoroutine(FadeInText(waveCountText, centerText));

        for (float t = 0.0f; t < 0.5f; t += Time.deltaTime)
        {
            leftShopSprite.color = new Color(leftShopSprite.color.r, leftShopSprite.color.g, leftShopSprite.color.b, t * 2);
            rightShopSprite.color = new Color(rightShopSprite.color.r, rightShopSprite.color.g, rightShopSprite.color.b, t * 2);
            yield return null;
        }

        while(!upgradeSelected)
        {
            yield return null;
        }

        StartCoroutine(FadeOutText(waveCountText, centerText));
        for (float t = 0.0f; t < 0.5f; t += Time.deltaTime)
        {
            leftShopSprite.color = new Color(leftShopSprite.color.r, leftShopSprite.color.g, leftShopSprite.color.b, 1.0f - t * 2);
            rightShopSprite.color = new Color(rightShopSprite.color.r, rightShopSprite.color.g, rightShopSprite.color.b, 1.0f - t * 2);
            yield return null;
        }
        leftShopCircle.SetActive(false);
        rightShopCircle.SetActive(false);

        upgradeSelected = false;
        yield return new WaitForSeconds(1f);
    }
    public void TextTable(int round) 
    {
        switch (round)
        {
            case 2:
            case 3:
            case 4:
            case 6:
                UpdateTopText($"W A V E  {round}");
                UpdateCenterText("W A V E   C O M P L E T E");
                break;
            case 5:
            case 10:
                UpdateTopText("SHOP");
                UpdateCenterText("W A V E   C O M P L E T E");
                break;
            case 7:
                UpdateTopText($"R A V E  {round}");
                UpdateCenterText("R A V E   C O M P L E T E");
                break;
            case 8:
                UpdateTopText($"W A V E  {round}");
                UpdateCenterText("W A V E   D E L E T E");
                break;
            case 9:
                UpdateTopText($"W A V E  {round}");
                UpdateCenterText("A N O T H E R   W A V E");
                break;
            case 11:
            case 12:
            case 13:
                UpdateTopText($"W A V E  {round}");
                UpdateCenterText("G O O D  L U C K");
                break;
            case 14:
                UpdateTopText($"W A V E  {round}");
                UpdateCenterText("J O I N  M E");
                break;
            case 15:
                UpdateTopText("G E T  O U T");
                UpdateCenterText("G E T  O U T");
                break;
            case 16:
            case 21:
                UpdateTopText("W A V E  1 666666");
                UpdateCenterText("Y O U  C O U L D  H A V E  E S C A P E D");
                break;
            case 17:
            case 22:
                UpdateTopText($"W A V E  {round}");
                UpdateCenterText("W A V E  V I O L A T I O N");
                break;
            case 18:
            case 23:
                UpdateTopText("W A A A  A A");
                UpdateCenterText("W A A A  A A A A A A A\nA");
                break;
            case 19:
            case 24:
                UpdateTopText("string waveCount = $\"W A V E  {int XX}\"");
                UpdateCenterText("W_  C_");
                break;
            case 20:
                UpdateTopText("Execute(wave.Upgrades());");
                UpdateCenterText("E N D  O F  W A V E");
                break;
            case 25: 
                UpdateTopText("D I E");
                UpdateCenterText("D I E");
                break;
            default:
                UpdateTopText("W A V E  E R R O R");
                UpdateCenterText("E N D  R E A C H E D");
                break;
        }
    }
}
