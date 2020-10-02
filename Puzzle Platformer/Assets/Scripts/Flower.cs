using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public Button button;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.beingPressed)
        {
            //open flower
            animator.SetBool("Button_Pressed", true);
        }
        else
        {
            //close flower
            animator.SetBool("Button_Pressed", false);
        }
    }
}
