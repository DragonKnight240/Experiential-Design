using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int Damage;
    bool InRange = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("PlayerRange"))
        {
            InRange = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.CompareTag("PlayerRange"))
        {
            InRange = false;
        }
    }
}
