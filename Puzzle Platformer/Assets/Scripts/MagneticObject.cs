using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public List<string> objectsMoving;
    GameObject playerOne;
    GameObject playerTwo;


    bool playerOneTouching;
    bool playerTwoTouching;


    void Start()
    {
        playerOne = GameObject.Find("Player1");
        playerTwo = GameObject.Find("Player2");

    }

    // Update is called once per frame
    void Update()
    {
        if (playerOneTouching)
        {
            Magnet magnet = playerOne.GetComponentInChildren<Magnet>();
            if (playerOne.GetComponent<Rigidbody>().velocity.magnitude <= 0.01f)
            {
                rb.isKinematic = false;
            }
            else if (magnet.MagnetForce > 0f)
            {
                rb.isKinematic = false;
            }
            else
            {
                rb.isKinematic = true;
            }
        }
        if (playerTwoTouching)
        {
            Magnet magnet = playerTwo.GetComponentInChildren<Magnet>();
            if (playerTwo.GetComponent<Rigidbody>().velocity.magnitude <= 0.01f)
            {
                rb.isKinematic = false;
            }
            else if (magnet.MagnetForce > 0f)
            {
                rb.isKinematic = false;
            }
            else
            {
                rb.isKinematic = true;
            }
        }

    }

    private void SetKinematic()
    {
        rb.isKinematic = false;
    }


    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Hit something");

        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") && (collision.gameObject.transform.position.y - gameObject.transform.position.y  < -0.9f))
        {
            collision.gameObject.GetComponent<PlayerMagnet>().Die();
        }

        if (collision.gameObject.tag == "Player1")
        {
            playerOneTouching = true;
        }

        else if (collision.gameObject.tag == "Player2")
        {
            playerTwoTouching = true;
        }

        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Magnet magnet = collision.gameObject.GetComponentInChildren<Magnet>();
            if (magnet.MagnetForce > 0f)
            {
                rb.isKinematic = false;
            }
            else
            {
                objectsMoving.Add(collision.gameObject.name);

                rb.isKinematic = true;

            }


        }   
    }

    private void OnCollisionExit(Collision collision)
    {

        Vector3 collisionDirection;
        float distance;
        Physics.ComputePenetration(collision.other.GetComponent<Collider>(), collision.other.transform.position + Vector3.down * 0.5f, collision.other.transform.rotation, gameObject.GetComponent<Collider>(), transform.position, transform.rotation, out collisionDirection, out distance);

        if (collision.gameObject.tag == "Player1")
        {
            playerOneTouching = false;
        }

        else if (collision.gameObject.tag == "Player2")
        {
            playerTwoTouching = false;
        }

        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            objectsMoving.Remove(collision.gameObject.name);

            if (objectsMoving.Count == 0)
            {
                if (distance > 0.01f)
                {
                    rb.isKinematic = true;
                    Invoke("SetKinematic", 2.0f);
                }
                else
                {
                    rb.isKinematic = false;
                }
            }

        }
    }
}
