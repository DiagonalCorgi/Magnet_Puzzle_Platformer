using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public List<string> objectsMoving;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void SetKinematic()
    {
        rb.isKinematic = false;
    }


    private void OnCollisionEnter(Collision collision)
    {


       
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            objectsMoving.Add(collision.gameObject.name);

            rb.isKinematic = true;


        }   
    }

    private void OnCollisionExit(Collision collision)
    {

        Vector3 collisionDirection;
        float distance;
        Physics.ComputePenetration(collision.other.GetComponent<Collider>(), collision.other.transform.position + Vector3.down * 0.5f, collision.other.transform.rotation, gameObject.GetComponent<Collider>(), transform.position, transform.rotation, out collisionDirection, out distance);


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
