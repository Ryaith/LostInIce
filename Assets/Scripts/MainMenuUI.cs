using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainPanel; //MainPanel
    public GameObject text; //Start text
    public GameObject instructions; //Instructions panel

    //Loads starter scene
    public void StartGame()
    {
        //Starts scene and adds a loading text to the button
        TMP_Text textLabel = text.GetComponent<TMP_Text>();
        textLabel.text = "Now Loading... ";
        SceneManager.LoadScene("SampleScene");
    }

    public void ToggleInstructions()
    {
        if (instructions.activeSelf == false)
        {
            instructions.SetActive(true);
        }
        else
        {
            instructions.SetActive(false);
        }
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
