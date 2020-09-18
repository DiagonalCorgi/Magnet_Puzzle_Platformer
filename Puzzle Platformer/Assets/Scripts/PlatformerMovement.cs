using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{

    float movementSpeed = 20f;
    float jumpHeight = 5f;
    LayerMask layerMask = 8;
    Rigidbody rigidbody;
    bool player1;
    bool player2;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = ~layerMask;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        if (gameObject.tag == "Player1")
        {
            player1 = true;
            Debug.Log("Player1 found");
        }
        else if (gameObject.tag == "Player2")
        {
            player2 = true;
            Debug.Log("Player2 found");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (player1)
        {
            MovePlayer(1);
        }
        else if (player2)
        {
            MovePlayer(2);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.55f, layerMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }


        }

    public void MovePlayer(int player)
    {
        if (Input.GetButton("HorizontalPlayer" + player))
        {
            if (Input.GetAxis("HorizontalPlayer" + player) > 0f)
            {
                if (rigidbody.velocity.x < 6f)
                {
                    rigidbody.AddForce(new Vector3(movementSpeed, 0f, 0f), ForceMode.Acceleration);
                }
            }
            else if (Input.GetAxis("HorizontalPlayer" + player) < 0f)
            {
                if (rigidbody.velocity.x < 6f)
                {
                    rigidbody.AddForce(new Vector3(-movementSpeed, 0f, 0f), ForceMode.Acceleration);
                }
            }
        }
        if (!Input.GetButton("HorizontalPlayer" + player) && grounded)
        {
            rigidbody.velocity = rigidbody.velocity * 0.9f;
        }

        if (Input.GetButtonDown("VerticalPlayer" + player))
        {
            if (Input.GetAxis("VerticalPlayer" + player) > 0f)
            {
                
                if (grounded)
                {
                    rigidbody.AddForce(transform.TransformDirection(Vector3.up * jumpHeight), ForceMode.Impulse);

                }
            }
        }
    }
}
