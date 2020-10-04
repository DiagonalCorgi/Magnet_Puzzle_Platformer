using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public bool beingPressed;
    List<string> objectsPressing;
    Animator buttonAnimator;
    public AudioSource button_down;
    public AudioSource button_up;
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        objectsPressing = new List<string>();
        buttonAnimator = gameObject.GetComponent<Animator>();
        renderer = gameObject.GetComponentInChildren<Renderer>();
        renderer.material.color = new Color(1f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(objectsPressing.Count);
        objectsPressing.Add(other.gameObject.name);
        if (objectsPressing.Count == 1)
        {
            
            beingPressed = true;
            Debug.Log(beingPressed);
            button_down.Play(0);
            buttonAnimator.SetBool("IsDown", true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(objectsPressing.Count);
        objectsPressing.Remove(other.gameObject.name);
        
        if (objectsPressing.Count == 0)
        {
            beingPressed = false;
            Debug.Log(beingPressed);
            button_up.Play(0);
            buttonAnimator.SetBool("IsDown", false);
        }
        
    }
}
