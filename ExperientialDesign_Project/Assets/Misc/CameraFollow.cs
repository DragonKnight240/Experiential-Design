using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowTarget;
    public float SmoothSpeed;
    public Vector3 offSet;
    internal bool Follow = true;
    public GameObject NewPosition;

    private void Start()
    {
        transform.position = FollowTarget.position + offSet;
    }

    private void Update()
    {
        if (!Follow)
        {
            if (NewPosition)
            {
                Vector3 DesiredPosition = NewPosition.transform.position + offSet;
                Vector3 SmoothPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);
                transform.position = SmoothPosition;
            }
        }
        else
        {
            if (DialogueSystem.Instance.TWEffect.UIPanel.activeInHierarchy)
            {
                transform.position = FollowTarget.position + offSet;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Follow)
        {
            Vector3 DesiredPosition = FollowTarget.position + offSet;
            Vector3 SmoothPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);

            transform.position = SmoothPosition;
        }
    }

    public void SetNewPosition(GameObject Position)
    {
        NewPosition = Position;
    }
}
