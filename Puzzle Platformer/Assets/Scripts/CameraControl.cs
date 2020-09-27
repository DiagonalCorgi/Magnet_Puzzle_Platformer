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
    public float panResponsiveness = 0.1f;
    [Range(0, 1)]
    public float zoomResponsiveness = 0.1f;
    [Range(0, 1)]
    public float tiltResponsiveness = 0.1f;
    public Vector2 playerOffset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
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
        }

        targetPos = cumulativePos / players.Length;
        targetPos = new Vector3(targetPos.x + playerOffset.x * (1 / zoomValue), targetPos.y + playerOffset.y * (1 / zoomValue), targetPos.z);

        newPos = transform.position + (targetPos - transform.position) * panResponsiveness * 10 * Time.deltaTime;
        transform.position = new Vector3(newPos.x, newPos.y, offset);

        //tilt camera in direction of motion
        Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, Quaternion.LookRotation(targetPos - Camera.main.transform.position, Vector3.up), 50 * tiltResponsiveness * Time.deltaTime);
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
        zoomValue += (Mathf.Clamp(newZoomValue, 0.2f, 3f) - zoomValue) * zoomResponsiveness * 10 * Time.deltaTime;
        
        transform.position = new Vector3(transform.position.x, transform.position.y, offset * (1 / zoomValue));
    }
}
