using UnityEngine;
using System.Collections;

public class CameraFollowObject : MonoBehaviour
{
    // Script for camera to follow the player object

    public Transform target;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 goalPos = target.position;
        goalPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}
