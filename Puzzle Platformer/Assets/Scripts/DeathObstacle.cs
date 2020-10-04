using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.gameObject.tag == "Player1" || collision.other.gameObject.tag == "Player2")
        {
            collision.other.gameObject.GetComponent<PlayerMagnet>().Die();
        }
    }
}
