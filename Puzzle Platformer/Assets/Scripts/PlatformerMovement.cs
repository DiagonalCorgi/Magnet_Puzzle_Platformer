﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{

    float movementSpeed = 20f;
    float jumpHeight = 6f;
    Rigidbody rigidbody;
    bool player1;
    bool player2;
    public bool grounded;
    public Transform body;

    // Start is called before the first frame update
    void Start()
    {
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
    void Update()
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

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.55f, LayerMask.GetMask("Ground")))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }


        //update animation
        GetComponent<Animator>().SetFloat("Speed", Mathf.Min(Mathf.Abs(rigidbody.velocity.x * 1f), 2));
        if (body && Mathf.Abs(rigidbody.velocity.x) > 0.01f)
        {
            body.localScale = new Vector3(-Mathf.Abs(body.localScale.x) * Mathf.Sign(rigidbody.velocity.x), body.localScale.y, body.localScale.z);
        }
    }

    public void MovePlayer(int player)
    {
        if (Input.GetButton("HorizontalPlayer" + player))
        {
            //Moving right
            if (Input.GetAxis("HorizontalPlayer" + player) > 0f)
            {
                if (rigidbody.velocity.x <= 0f || Mathf.Abs(rigidbody.velocity.x) < 6f)
                {
                    rigidbody.AddForce(new Vector3(movementSpeed, 0f, 0f), ForceMode.Acceleration);
                }
            }
            //moving left
            else if (Input.GetAxis("HorizontalPlayer" + player) < 0f)
            {
                if (rigidbody.velocity.x >= 0f || Mathf.Abs(rigidbody.velocity.x) < 6f)
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
                    GetComponent<Animator>().SetTrigger("Jump");
                    rigidbody.AddForce(transform.TransformDirection(Vector3.up * jumpHeight), ForceMode.Impulse);

                }
            }
        }
    }
}
