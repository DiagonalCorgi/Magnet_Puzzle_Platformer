using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject[] players;
    private float offset;
    [Range(0.2f,3)]
    public float zoomValue = 1;
    [Range(0, 1)]
    public float responsiveness = 0.1f;
    public Vector2 playerOffset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        ZoomCamera();
    }

    public void MoveCamera()
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

        newPos = transform.position + (targetPos - transform.position) * responsiveness;
        transform.position = new Vector3(newPos.x +playerOffset.x * (1 / zoomValue), newPos.y + playerOffset.y * (1 / zoomValue), offset);
    }

    public void ZoomCamera()
    {
        //track the player position furthest from the center in x and y individually
        Vector2 furthestPlayerPos = Vector2.zero;
        for (int playerId = 0; playerId < players.Length; playerId++)
        {
            Vector3 distance = (Camera.main.WorldToViewportPoint(players[playerId].transform.position) - new Vector3(0.5f,0.5f,0)) * 2;

            furthestPlayerPos.x = Mathf.Max(furthestPlayerPos.x, Mathf.Abs(distance.x));
            furthestPlayerPos.y = Mathf.Max(furthestPlayerPos.y, Mathf.Abs(distance.y));
        }

        float newZoomValue = Mathf.Min( 1, 0.8f / furthestPlayerPos.x, 0.8f / furthestPlayerPos.y);
        zoomValue += (Mathf.Clamp(newZoomValue, 0.2f, 3f) - zoomValue) * responsiveness;
        
        transform.position = new Vector3(transform.position.x, transform.position.y, offset * (1 / zoomValue));
    }
}
