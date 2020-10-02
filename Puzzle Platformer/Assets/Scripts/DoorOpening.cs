using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public bool beingpressed;
    public Button button;
    public AudioSource door_open;
    Animator doorAnimator;
    float audiotimer;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        doorAnimator.SetBool("IsDown", false);
        if (button.beingPressed & audiotimer <= 0f)
            {
            door_open.Play(0);
            audiotimer = 0.5f;
            }
        else if (!button.beingPressed)
        {
            doorAnimator.SetBool("IsDown", true);

        }
        else
        {
            audiotimer -= Time.deltaTime;
        }
    }
}
