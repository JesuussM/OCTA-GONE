using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Net.Http.Headers;

public class EndingScreen : MonoBehaviour
{
    public Text endingText;
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ending());
        videoPlayer.gameObject.SetActive(false);
        endingText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Ending()
    {
        yield return new WaitForSeconds(2f);
        endingText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        endingText.gameObject.SetActive(false);
        videoPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0); 
    }
}
