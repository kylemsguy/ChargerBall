using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThanksForPlayingController : MonoBehaviour {

    public Image HideEverythingFilter;
    public Button QuitButton;

    Image textbg;
    Text text;

	// Use this for initialization
	void Start () {
        // get stuff
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Button btn = QuitButton.GetComponent<Button>();
        btn.onClick.AddListener(QuitGame);
        StartCoroutine(FadeInScreen());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FadeInScreen()
    {
        yield return new WaitForSecondsRealtime(1);
        HideEverythingFilter.GetComponent<Image>().CrossFadeAlpha(0, 2, true);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
