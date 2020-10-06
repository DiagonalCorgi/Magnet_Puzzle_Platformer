using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeableSpike : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Magnet[] magnets;
    public Renderer[] spikeRenderers;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Renderer spikeRenderer in spikeRenderers)
        {
            spikeRenderer.material.color = new Color(0f, 0f, 0f);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (button1.beingPressed || button2.beingPressed)
        {
            foreach (Magnet magnet in magnets)
            {
                magnet.MagnetForce = 5;
            }
            foreach (Renderer spikeRenderer in spikeRenderers)
            {
                spikeRenderer.material.color = new Color(1f, 0f, 0f);
            }

        }
        else
        {
            foreach (Magnet magnet in magnets)
            {
                magnet.MagnetForce = 0;
            }
            foreach (Renderer spikeRenderer in spikeRenderers)
            {
                spikeRenderer.material.color = new Color(0f, 0f, 0f);
            }
        }
    }

   
}
