using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject[] players;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cumulativePos = Vector3.zero;
        Vector3 averagePos = Vector3.zero;
        Vector3 targetPos = Vector3.zero;
        Vector3 newPos = Vector3.zero;
        for (int playerId = 0; playerId < players.Length; playerId++)
        {
            GameObject player = players[playerId];
            cumulativePos += player.transform.position;
            targetPos = cumulativePos / players.Length;
        }

        newPos = transform.position + (targetPos - transform.position) * 0.05f;
        transform.position = new Vector3(newPos.x, newPos.y, offset);
    }
}
