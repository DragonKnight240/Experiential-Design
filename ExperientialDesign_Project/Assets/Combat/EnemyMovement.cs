using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum MovementTypes
    {
        Patrol,
        Stationary,
        Retreat
    }

    public MovementTypes MovementType;
    Patrol MovementPatrol;
    public float Speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (MovementType)
        {
            case MovementTypes.Patrol:
                {
                    transform.position = Vector3.MoveTowards(transform.position, MovementPatrol.PatrolTo.transform.position, Speed * Time.deltaTime);
                    break;
                }
            case MovementTypes.Retreat:
                {
                    break;
                }
            case MovementTypes.Stationary:
                {
                    break;
                }
        }
    }
}
