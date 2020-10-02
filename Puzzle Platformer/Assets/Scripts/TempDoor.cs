using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDoor : MonoBehaviour
{

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //open door
        if (button.beingPressed)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
        //close door
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
