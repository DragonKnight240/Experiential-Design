using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowTarget;
    public float SmoothSpeed;
    public Vector3 offSet;

    private void FixedUpdate()
    {
        Vector3 DesiredPosition = FollowTarget.position + offSet;
        Vector3 SmoothPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);

        transform.position = SmoothPosition;
    }
}
