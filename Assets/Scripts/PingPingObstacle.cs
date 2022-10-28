using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPingObstacle : MonoBehaviour
{
    Vector3 startPos;
    public float moveX = 0f;
    public float moveY = 0f;
    public float moveZ = 0f;
    public float speed = 1f;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Bounces a value between 0 and 1.
        // Then multiplies that number with the distance we want to move in each direction.
        float bounce = Mathf.PingPong(Time.time * speed, 1f);
        Vector3 movement = new Vector3(moveX * bounce, moveY * bounce, moveZ * bounce);

        transform.position = startPos + movement;
    }
}
