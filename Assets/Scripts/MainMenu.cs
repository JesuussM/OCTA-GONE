using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public FadeController fadeController;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return StartCoroutine(fadeController.FadeIn());
        fadeController.fadeImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        Debug.Log("Play button clicked");
        SceneManager.LoadScene("PlayingScene");
    }

    // ! It is possible I need to add a reset function here to reset the score and other variables
}
