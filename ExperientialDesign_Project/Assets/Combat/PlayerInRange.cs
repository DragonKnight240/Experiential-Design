using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRange : MonoBehaviour
{
    SphereCollider PlayerRange;
    internal EnemyMovement Movement;
    internal Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRange = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            enemy.ChasePlayer = true;
            Movement.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            enemy.ChasePlayer = false;
            Movement.enabled = true;
        }
    }
}
