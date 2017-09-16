using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    [SerializeField] string m_NextSceneID = "leveltwo";
    [SerializeField] float pauseDelay = 3.0f;

    GameObject gameStatus;
    Text gameText;

    public static bool GameComplete = false;
    public static bool GameOver = false;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        GameComplete = false;
        GameOver = false;
        gameStatus = GameObject.Find("LevelCompleteFail");
        gameText = gameStatus.GetComponent<Text>();
        HideStatus();
    }
	
	// Update is called once per frame
	void Update () {
		if (GameComplete)
        {
            GameCompleteHandler();
        }
        else if (GameOver)
        {
            GameOverHandler();
        }
	}

    void HideStatus()
    {
        gameText.enabled = false;
    }

    void ShowStatus(string text)
    {
        gameText.text = text;
        gameText.enabled = true;
    }

    public void GameCompleteHandler()
    {
        //do things
        Time.timeScale = 0;
        Image crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        crosshair.enabled = false;
        ShowStatus("Level Complete!");
        // start new level after a few seconds
        fadeout();
        SceneManager.LoadScene(m_NextSceneID);
    }

    public IEnumerator GameOverHandler()
    {
        // do things
        
        Image crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        crosshair.enabled = false;
        ShowStatus("Game Over");
        // start new level after a few seconds
        Time.timeScale = .0000001f;
        yield return new WaitForSeconds(pauseDelay* Time.timeScale);
        Time.timeScale = 0;
        // begin fadeout
        Console.WriteLine("Fading out...");
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

    private IEnumerator fadeout()
    {
        Time.timeScale = .0000001f;
        yield return new WaitForSeconds(pauseDelay * Time.timeScale);
        // begin fadeout
        print("Fadingout...");
    }
}
