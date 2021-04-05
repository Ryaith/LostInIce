using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject blackImageObject; //Blackout image
    private Image blackImg; //Img for black
    public static bool isPaused = false;   // Conveys state of the pause menu so that player direction cannot be changed on pause 
    public static bool blackOut = false;
    public static string mapToLoad = "";
    public GameObject DialogueObject; //Dialogue box object
    public GameObject SpeakerObject; //Speaker name object
    private TMP_Text speakerDialogueText; //Dialogue text
    private TMP_Text speakerNameText; //Speaker text

    //Strings of stuff that can be said by Klarens at each scene
    private string scene1load = "My brother-?! Where did he go? I have to find him before the storm hits...";
    private string scene2load = "Footprints-! This must be the path, I must hurry before he freezes to death.";
    private string scene3load = "Is that Vel's scarf? I think he went further ahead... I hope he's still alright.";
    private string scene4load = "Vel-! ...Thank the gods he's okay. It's time to head home now...";

    private string klarens = "Klarens";
    private string vel = "Velius";

    //check for which string id to say next?
    private string nextstring = "";

    private static UiScript playerInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        textLabel = menuButtonText.GetComponent<TMP_Text>();
        blackImg = blackImageObject.GetComponent<Image>();
        speakerNameText = SpeakerObject.GetComponent<TMP_Text>();
        speakerDialogueText = DialogueObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            TogglePause();

        if (blackOut)
        {
            StartCoroutine(FadeBlack());
        }

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

    //Fades out the screen
    public IEnumerator FadeBlack()
    {
   
        int fadeSpeed = 5;
        Color objectColor = blackImg.color;
        float fadeAmount;
        isPaused = true;
        if (blackOut)
        {
            blackOut = false;
            while (blackImg.color.a < 1)
            {

                //Debug.Log("fade in");
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackImg.color = objectColor;
                yield return null;
            }

            if (mapToLoad != "")
            {
                SceneManager.LoadScene(mapToLoad);

                mapToLoad = "";
            }

            //Will not unfade colour after scene loads rip.
            while (blackImg.color.a > 0)
            {
                //Debug.Log("fade out");
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackImg.color = objectColor;
                yield return null;
            }
        }

        //Debug.Log("done");
        isPaused = false;
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
