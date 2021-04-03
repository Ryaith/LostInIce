﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiScript : MonoBehaviour
{

    public bool next = false;
    public GameObject textUI; //DialogueUI Panel
    public GameObject menuUI; //Menu UI panel
    public GameObject menuButtonText; //Text on menu button
    public GameObject quitButton; //Quit button on menu
    public GameObject blocker; //Translucent black blocker for menu
    private TMP_Text textLabel; //Given at start, text on menu button
    public static bool isPaused = false;   // Conveys state of the pause menu so that player direction cannot be changed on pause 

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
            isPaused = false;
            menuUI.gameObject.SetActive(false);
            blocker.gameObject.SetActive(false);
            textLabel.text = "Show Menu";
            Time.timeScale = 1f;
            //return (false);
        }
        else
        {
            isPaused = true;
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
