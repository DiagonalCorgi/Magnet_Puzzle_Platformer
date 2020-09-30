using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagnet : MonoBehaviour
{

    public Texture southBody;
    public Texture northBody;
    public Texture neutralBody;
    public Texture southGlow;
    public Texture northGlow;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject bodyBase;
    public GameObject bodyGlow;
    public GameObject blueParticles;
    public GameObject redParticles;

    public SceneSwitching sceneSwitcher;

    public float gBValues;
    public float colourChangeTime = 3f;

    public Magnet magnet;
    public string playerTag;
    public float magnetForce = 10f;

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
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject magneticObject = GameObject.FindGameObjectWithTag("Magnetic Object");
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
            magnet.MagnetForce = magnetForce;
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
            magnet.MagnetForce = magnetForce;
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
            magnet.MagnetForce = magnetForce;
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
            magnet.MagnetForce = magnetForce;
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

        if (gBValues > 1f)
        {
            sceneSwitcher.RestartScene();
        }
        else if (gBValues > 0f)
        {
            gBValues += (colourChangeTime * Time.deltaTime);
            leftLeg.GetComponent<SpriteRenderer>().color = new Color(1f, gBValues, gBValues, 1f);
            rightLeg.GetComponent<SpriteRenderer>().color = new Color(1f, gBValues, gBValues, 1f);
            bodyBase.GetComponent<MeshRenderer>().material.color = new Color(1f, gBValues, gBValues, 1f);
            bodyGlow.GetComponent<MeshRenderer>().material.color = new Color(1f, gBValues, gBValues, 1f);
            Debug.Log(gBValues);
        }

    }

    public void Die()
    {
        leftLeg.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 1f);
        rightLeg.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        bodyBase.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f, 1f);
        bodyGlow.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 1f);
        gBValues += (1/colourChangeTime * Time.deltaTime);

    }
}
