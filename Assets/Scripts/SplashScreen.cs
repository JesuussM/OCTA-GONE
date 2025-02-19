using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public UIManager uiManager;
    public Text creditTag;
    public Text creditName;
    public FadeController fadeController;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeScene()
    {
        yield return StartCoroutine(uiManager.FadeInText(creditTag, creditName));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(uiManager.FadeOutText(creditTag, creditName));
        yield return StartCoroutine(fadeController.FadeOut());
        SceneManager.LoadScene(1); 
    }
}
