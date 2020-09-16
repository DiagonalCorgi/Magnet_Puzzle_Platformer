using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{

    float movementSpeed = 10f;
    float jumpHeight = 5f;
    LayerMask layerMask = 8;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = ~layerMask;
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Debug.Log("moving left/right");
            if (Input.GetAxis("Horizontal") > 0f)
            {
                transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0f, 0f), Space.Self);
            }
            else if (Input.GetAxis("Horizontal") < 0f)
            {
                transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0f, 0f), Space.Self);
            }
        }

        if (Input.GetButtonDown("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.55f, layerMask))
                {
                    Debug.Log("jump");
                    rigidbody.AddForce(transform.TransformDirection(Vector3.up * jumpHeight), ForceMode.Impulse);
                    
                }
            }
        }
    }
}
