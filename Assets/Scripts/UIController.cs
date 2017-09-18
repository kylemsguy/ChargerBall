using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    [SerializeField] string m_NextSceneID = "leveltwo";
    [SerializeField] float pauseDelay = 3.0f;
    [SerializeField] GameObject crosshairObj;
    [SerializeField] GameObject gameStatus;
    [SerializeField] GameObject splashScreen;
    [SerializeField] GameObject blackImage;

    Text gameText;

    public static bool GameComplete = false;
    public static bool GameOver = false;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 0;
        GameComplete = false;
        GameOver = false;
        gameText = gameStatus.GetComponentInChildren<Text>();
        HideStatus();
        StartCoroutine(FadeOutSplash());
    }
	
	// Update is called once per frame
	void Update () {
		if (GameComplete)
        {
            StartCoroutine(GameCompleteHandler());
        }
        else if (GameOver)
        {
            StartCoroutine(GameOverHandler());
        }
	}

    IEnumerator FadeOutSplash()
    {
        Image img = splashScreen.GetComponent<Image>();
        yield return new WaitForSecondsRealtime(2);
        img.CrossFadeAlpha(0, 1, true);
        Time.timeScale = 1;
    }

    void HideStatus()
    {
        gameStatus.GetComponent<Image>().CrossFadeAlpha(0, 0, false);
        gameText.enabled = false;
    }

    void ShowStatus(string text)
    {
        gameStatus.GetComponent<Image>().CrossFadeAlpha(255, 0, false);
        gameText.text = text;
        gameText.enabled = true;
    }

    public IEnumerator GameCompleteHandler()
    {
        //do things
        Time.timeScale = 0;
        Image crosshair = crosshairObj.GetComponent<Image>();
        crosshair.enabled = false;
        ShowStatus("Level Complete!");
        // start new level after a few seconds
        fadeout();
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(m_NextSceneID);
    }

    public IEnumerator GameOverHandler()
    {
        Image crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        crosshair.enabled = false;
        ShowStatus("Level Failed. Reloading...");
        // start new level after a few seconds
        Time.timeScale = 0;
        // begin fadeout
        fadeout();
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

    private void fadeout()
    {
        Image img = splashScreen.GetComponent<Image>();
        // begin fadeout
        img.CrossFadeAlpha(0, 1, true);
    }
}
