using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public FadeController fadeController;
    public AudioClip menuMusic;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        SoundManager.instance.PlayMusic(menuMusic, 0f);
        yield return StartCoroutine(fadeController.FadeIn());
        fadeController.fadeImage.gameObject.SetActive(false);

        StartCoroutine(SoundManager.instance.FadeInMusic(SoundManager.instance.musicSource));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        Debug.Log("Play button clicked");
        StartCoroutine(SoundManager.instance.FadeOutMusic(SoundManager.instance.musicSource));
        SceneManager.LoadScene("PlayingScene");
    }

    // ! It is possible I need to add a reset function here to reset the score and other variables
}
