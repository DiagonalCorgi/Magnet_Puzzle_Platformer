using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovment : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private bool ladderInRange;
    private float inputVertical;

    private bool player1;
    private bool player2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (gameObject.tag == "Player1")
        {
            player1 = true;
        }
        else if (gameObject.tag == "Player2")
        {
            player2 = true;
        }
    }

    void FixedUpdate()
    {
        if (player1)
        {
            if (Input.GetButton("HorizontalPlayer1"))
            {
                ladderInRange = false;
                rb.useGravity = true;
            }
        }
        else if (player2)
        {
            if (Input.GetButton("HorizontalPlayer2"))
            {
                ladderInRange = false;
                rb.useGravity = true;
            }
        }

        if (ladderInRange == true)
        {
            if (player1)
            {
                MovePlayerLadder(1);
            }
            else if (player2)
            {
                MovePlayerLadder(2);
            }
        }
    }

    public void MovePlayerLadder(int player)
    {

        inputVertical = Input.GetAxisRaw("VerticalPlayer" + player);

        rb.velocity = new Vector3(rb.position.x, inputVertical * speed, rb.position.z);
        rb.useGravity = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ladder")
        {
            ladderInRange = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ladder")
        {
            ladderInRange = true;
        }
    }


}
