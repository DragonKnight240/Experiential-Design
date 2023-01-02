using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueMoveTo : OnDialogueLine
{
    public GameObject MoveTo;
    public Rigidbody RB;
    public float Speed;
    bool Moving = false;

    // Start is called before the first frame update
    void Start()
    {
        if (RB == null)
        {
            RB = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        base.Update();

        if(Moving)
        {
            if (transform.position == new Vector3(MoveTo.transform.position.x, transform.position.y, MoveTo.transform.position.z))
            {
                Moving = false;
                RB.velocity = Vector3.zero;
            }
        }
    }

    public override void CorrectDialoguePlaying(bool Active)
    {
        Moving = true;
        RB.velocity = new Vector3((transform.position.x - MoveTo.transform.position.x), 0, (transform.position.z - MoveTo.transform.position.z));
    }
}
