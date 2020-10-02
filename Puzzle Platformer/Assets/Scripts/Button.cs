using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public bool beingPressed;
    GameObject[] objectsPressing;
    Animator buttonAnimator;
    public AudioSource button_down;
    public AudioSource button_up;


    // Start is called before the first frame update
    void Start()
    {
       buttonAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        beingPressed = true;
        Debug.Log(beingPressed);
        button_down.Play(0);
        buttonAnimator.SetBool("IsDown", true);
    }

    private void OnTriggerExit(Collider other)
    {
        beingPressed = false;
        Debug.Log(beingPressed);
        button_up.Play(0);
        buttonAnimator.SetBool("IsDown", false);
    }
}
