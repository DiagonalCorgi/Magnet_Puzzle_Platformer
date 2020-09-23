using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitArea : MonoBehaviour
{

    bool player1Exiting;
    bool player2Exiting;
    SceneSwitching sceneSwitcher;
    public int currentScene;


    // Start is called before the first frame update
    void Start()
    {
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitching>();
        currentScene = sceneSwitcher.currentScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Exiting && player2Exiting)
        {
            // play fade and switch to next scene
            player1Exiting = false;
            StartCoroutine("SceneFade");
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


    private IEnumerator SceneFade()
    {
        Debug.Log("Exiting scene, fading out....");
        yield return new WaitForSeconds(1f);
        sceneSwitcher.NextScene(currentScene);
    }
}
