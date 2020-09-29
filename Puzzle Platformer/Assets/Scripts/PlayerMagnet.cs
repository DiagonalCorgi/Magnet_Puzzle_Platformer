using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{

    public Texture southBody;
    public Texture northBody;
    public Texture neutralBody;
    public Texture southGlow;
    public Texture northGlow;
    public GameObject bodyBase;
    public GameObject bodyGlow;
    public GameObject blueParticles;
    public GameObject redParticles;

    public Magnet magnet;
    public string playerTag;
    // Start is called before the first frame update
    void Start()
    {
        bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", neutralBody);
        bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", neutralBody);
        bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", neutralBody);
        bodyGlow.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        redParticles.SetActive(false);
        blueParticles.SetActive(false);
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
            //set player sprite to north
            bodyGlow.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", northBody);
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", northBody);
            bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", northGlow);
            bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", northGlow);
            redParticles.SetActive(true);
            blueParticles.SetActive(false);
            magnet.MagnetForce = 15;
            magnet.MagneticPole = Magnet.Pole.North;
            Debug.Log("North");
        }
        if (Input.GetButtonDown("SouthPolarityPlayer1") && playerTag == "Player1")
        {
            //set player sprite to south
            bodyGlow.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", southBody);
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", southBody);
            bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", southGlow);
            bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", southGlow);
            redParticles.SetActive(false);
            blueParticles.SetActive(true);
            magnet.MagnetForce = 15;
            magnet.MagneticPole = Magnet.Pole.South;
            Debug.Log("South");
        }
        if (Input.GetButtonDown("NeutralPolarityPlayer1") && playerTag == "Player1")
        {
            //set player sprite to neutral
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", neutralBody);
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", neutralBody);
            bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", neutralBody);
            bodyGlow.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            redParticles.SetActive(false);
            blueParticles.SetActive(false);
            magnet.MagnetForce = 0;
            Debug.Log("Neutral");
        }
        if (Input.GetButtonDown("NorthPolarityPlayer2") && playerTag == "Player2")
        {
            //set player sprite to north
            bodyGlow.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", northBody);
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", northBody);
            bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", northGlow);
            bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", northGlow);
            redParticles.SetActive(true);
            blueParticles.SetActive(false);
            magnet.MagnetForce = 15;
            magnet.MagneticPole = Magnet.Pole.North;
            Debug.Log("North");
        }
        if (Input.GetButtonDown("SouthPolarityPlayer2") && playerTag == "Player2")
        {
            //set player sprite to south
            bodyGlow.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", southBody);
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", southBody);
            bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", southGlow);
            bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", southGlow);
            redParticles.SetActive(false);
            blueParticles.SetActive(true);
            magnet.MagnetForce = 15;
            magnet.MagneticPole = Magnet.Pole.South;
            Debug.Log("South");
        }
        if (Input.GetButtonDown("NeutralPolarityPlayer2") && playerTag == "Player2")
        {
            //set player sprite to neutral
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", neutralBody);
            bodyBase.GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", neutralBody);
            bodyGlow.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", neutralBody);
            bodyGlow.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            redParticles.SetActive(false);
            blueParticles.SetActive(false);
            magnet.MagnetForce = 0;
            Debug.Log("Neutral");
        }


    }
}
