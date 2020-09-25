using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{


    public Magnet magnet;
    public string playerTag;
    // Start is called before the first frame update
    void Start()
    {

        playerTag = gameObject.tag;
        magnet = GetComponentInChildren<Magnet>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        var player1Renderer = player1.GetComponent<Renderer>();

        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        var player2Renderer = player2.GetComponent<Renderer>();

        if (Input.GetButtonDown("NorthPolarityPlayer1") && playerTag == "Player1")
        {
            player1Renderer.material.SetColor("_Color", Color.blue);
            magnet.MagnetForce = 15;
            magnet.MagneticPole = Magnet.Pole.North;
            Debug.Log("North");
        }
        if (Input.GetButtonDown("SouthPolarityPlayer1") && playerTag == "Player1")
        {
            player1Renderer.material.SetColor("_Color", Color.red);
            magnet.MagnetForce = 15;
            magnet.MagneticPole = Magnet.Pole.South;
            Debug.Log("South");
        }
        if (Input.GetButtonDown("NeutralPolarityPlayer1") && playerTag == "Player1")
        {
            player1Renderer.material.SetColor("_Color", Color.grey);
            magnet.MagnetForce = 0;
            Debug.Log("Neutral");
        }
        if (Input.GetButtonDown("NorthPolarityPlayer2") && playerTag == "Player2")
        {
            player2Renderer.material.SetColor("_Color", Color.blue);
            magnet.MagnetForce = 15;
            magnet.MagneticPole = Magnet.Pole.North;
            Debug.Log("North");
        }
        if (Input.GetButtonDown("SouthPolarityPlayer2") && playerTag == "Player2")
        {
            player2Renderer.material.SetColor("_Color", Color.red);
            magnet.MagnetForce = 15;
            magnet.MagneticPole = Magnet.Pole.South;
            Debug.Log("South");
        }
        if (Input.GetButtonDown("NeutralPolarityPlayer2") && playerTag == "Player2")
        {
            player2Renderer.material.SetColor("_Color", Color.grey);
            magnet.MagnetForce = 0;
            Debug.Log("Neutral");
        }


    }
}
