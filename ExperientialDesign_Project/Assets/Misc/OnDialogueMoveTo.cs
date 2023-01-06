using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueMoveTo : OnDialogueLine
{
    public GameObject MoveTo;
    public float Speed;
    bool Moving = false;
    public Animator Anim;
    public string TriggerNameTo;

    // Start is called before the first frame update
    void Start()
    {
        if (!Anim)
        {
            Anim = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        base.Update();

        if(Moving)
        {
            Anim.gameObject.transform.parent.transform.position = Vector3.MoveTowards(Anim.gameObject.transform.parent.transform.position, MoveTo.transform.position, Speed * Time.unscaledDeltaTime);
            if (Anim.gameObject.transform.parent.transform.position == new Vector3(MoveTo.transform.position.x, Anim.gameObject.transform.parent.transform.position.y, MoveTo.transform.position.z))
            {
                Moving = false;
                if(Anim.GetComponent<TriggerAnims>())
                {
                    Anim.GetComponent<TriggerAnims>().doneOnce = false;
                }
            }
        }
    }

    public override void CorrectDialoguePlaying(bool Active)
    {
        Moving = true;
        Anim.SetTrigger(TriggerNameTo);
        if (Anim.GetComponent<TriggerAnims>())
        {
            Anim.GetComponent<TriggerAnims>().Anim.ResetTrigger("Idle");
        }
    }
}
