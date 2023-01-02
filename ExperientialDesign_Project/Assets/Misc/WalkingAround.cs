using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAround : MonoBehaviour
{
    public float walkingSpeed = 2;
    public List<GameObject> PatrolLocations;
    int PatrolNode = 0;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PatrolLocations[PatrolNode].transform);
        transform.position = Vector3.MoveTowards(transform.position, PatrolLocations[PatrolNode].transform.position, walkingSpeed * Time.deltaTime);

        if(PatrolLocations[PatrolNode].transform.position == transform.position)
        {
            PatrolNode++;

            if(PatrolNode >= PatrolLocations.Count)
            {
                PatrolNode = 0;
            }
        }
    }
}
