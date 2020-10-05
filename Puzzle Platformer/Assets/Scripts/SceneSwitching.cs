using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{

    public int currentScene;
    public int nextScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
