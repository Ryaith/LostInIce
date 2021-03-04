using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject text;

    public void StartGame()
    {
        //Starts scene and adds a loading text to the button
        TMP_Text textLabel = text.GetComponent<TMP_Text>();
        textLabel.text = "Now Loading... ";
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
