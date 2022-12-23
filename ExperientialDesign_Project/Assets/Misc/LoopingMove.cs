using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingMove : MonoBehaviour
{
    public float MoveSpeed = 4;
    public GameObject Target;
    Vector3 StartPos;

    private void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, MoveSpeed);

        if(Target.transform.position == transform.position)
        {
            transform.position = StartPos;
        }
    }
}
