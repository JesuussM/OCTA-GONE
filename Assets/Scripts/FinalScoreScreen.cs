using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScoreScreen : MonoBehaviour
{
    public UIManager uiManager;
    public Text finalScoreText;
    public Text scoreText;
    public FadeController fadeController;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = UIManager.finalScore.ToString("N0");
        StartCoroutine(ChangeScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeScene()
    {
        yield return StartCoroutine(uiManager.FadeInText(finalScoreText, scoreText));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(uiManager.FadeOutText(finalScoreText, scoreText));
        yield return StartCoroutine(fadeController.FadeOut());
        SceneManager.LoadScene(0); 
    }
}
