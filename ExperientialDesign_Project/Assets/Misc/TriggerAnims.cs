using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnims : MonoBehaviour
{
    Animator Anim;
    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponentInParent<Rigidbody>(true);
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RB.velocity != Vector3.zero)
        {
            Anim.ResetTrigger("Idle");
            Anim.SetTrigger("Moving");
        }
        else
        {
            Anim.ResetTrigger("Moving");
            Anim.SetTrigger("Idle");
        }
    }
}
