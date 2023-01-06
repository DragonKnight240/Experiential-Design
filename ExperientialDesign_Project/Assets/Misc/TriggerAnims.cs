using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnims : MonoBehaviour
{
    internal Animator Anim;
    Rigidbody RB;
    internal bool doneOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponentInParent<Rigidbody>(true);
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueSystem.Instance.TWEffect.UIPanel.activeInHierarchy)
        {
            if (RB.velocity != Vector3.zero)
            {
                Anim.ResetTrigger("Idle");
                Anim.SetTrigger("Moving");
                doneOnce = false;
            }
            else
            {
                Anim.ResetTrigger("Moving");
                Anim.SetTrigger("Idle");
                doneOnce = false;
            }
        }
        else
        {
            if (!doneOnce)
            {
                Anim.ResetTrigger("Moving");
                Anim.SetTrigger("Idle");
                doneOnce = true;
            }
        }
    }
}
