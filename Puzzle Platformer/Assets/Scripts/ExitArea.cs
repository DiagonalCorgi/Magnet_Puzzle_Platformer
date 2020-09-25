using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitArea : MonoBehaviour
{

    bool player1Exiting;
    bool player2Exiting;
    SceneSwitching sceneSwitcher;
    public int currentScene;
    public Image blackFade;
    float fadeOutTime;
    float fadeAmount;


    // Start is called before the first frame update
    void Start()
    {
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitching>();
        currentScene = sceneSwitcher.currentScene;
        Debug.Log(currentScene);
        blackFade = GameObject.Find("Canvas").GetComponentInChildren<Image>();
        blackFade.color = new Color(blackFade.color.r, blackFade.color.g, blackFade.color.b, 1f);
        fadeOutTime = 0.5f;
        StartCoroutine("SceneFadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Exiting && player2Exiting)
        {
            // play fade and switch to next scene
            player1Exiting = false;
            StartCoroutine("SceneFadeOut");
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            player1Exiting = true;
        }
        else if (other.gameObject.tag == "Player2")
        {
            player2Exiting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            player1Exiting = false;
        }
        else if (other.gameObject.tag == "Player2")
        {
            player2Exiting = false;
        }
    }


    private IEnumerator SceneFadeOut()
    {
        Debug.Log("Exiting scene, fading out....");
        while (blackFade.color.a < 1)
        {
            fadeAmount = blackFade.color.a + (fadeOutTime * Time.deltaTime);

            blackFade.color = new Color(blackFade.color.r, blackFade.color.g, blackFade.color.b, fadeAmount);
            yield return null;

        }
        sceneSwitcher.NextScene(currentScene);
    }

    private IEnumerator SceneFadeIn()
    {
        Debug.Log("Entering scene, fading in....");
        while (blackFade.color.a > 0)
        {
            fadeAmount = blackFade.color.a - (fadeOutTime * Time.deltaTime);

            blackFade.color = new Color(blackFade.color.r, blackFade.color.g, blackFade.color.b, fadeAmount);
            yield return null;

        }
    }
}
