using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public Magnet magnet;
    // Start is called before the first frame update
    void Start()
    {
        magnet = GetComponentInChildren<Magnet>();
    }

    // Update is called once per frame
    void Update()
    {

     if(Input.GetButtonDown("ToggleMagnetPlayer1"))
        {
            Debug.Log("toggle");
        }

        if (Input.GetButtonDown("SwitchPolarityPlayer1"))
        {
            if (magnet.MagneticPole == Magnet.Pole.North)
            {
                magnet.MagneticPole = Magnet.Pole.South;
            }
            else
            {
                magnet.MagneticPole = Magnet.Pole.North;
            }
            Debug.Log(magnet.MagneticPole);
        }
     if(Input.GetButtonDown("ToggleMagnetPlayer2"))
        {
            Debug.Log("toggle");
        }

        if (Input.GetButtonDown("SwitchPolarityPlayer2"))
        {
            if (magnet.MagneticPole == Magnet.Pole.North)
            {
                magnet.MagneticPole = Magnet.Pole.South;
            }
            else
            {
                magnet.MagneticPole = Magnet.Pole.North;
            }
            Debug.Log(magnet.MagneticPole);
        }
    }
}
