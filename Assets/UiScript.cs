using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScript : MonoBehaviour
{

    public bool next = false;
    public GameObject textUI;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void Quit()
    {
        Application.Quit();
    }
}
