using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiScript : MonoBehaviour
{

    public bool next = false;
    public GameObject textUI;
    public GameObject menuUI;
    public GameObject menuButtonText;
    public GameObject quitButton;
    public GameObject mainMenu;
    public GameObject blocker;
    private TMP_Text textLabel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        textLabel = menuButtonText.GetComponent<TMP_Text>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            TogglePause();
    }

    public void ContinueText()
    {
        if (next)
        {
            textUI.SetActive(false);
        }
        else
        {
            textUI.SetActive(false);
        }
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            menuUI.gameObject.SetActive(false);
            blocker.gameObject.SetActive(false);
            textLabel.text = "Show Menu";
            Time.timeScale = 1f;
            //return (false);
        }
        else
        {
            menuUI.gameObject.SetActive(true);
            blocker.gameObject.SetActive(true);
            textLabel.text = "Hide Menu";
            Time.timeScale = 0f;
            //return (true);
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
