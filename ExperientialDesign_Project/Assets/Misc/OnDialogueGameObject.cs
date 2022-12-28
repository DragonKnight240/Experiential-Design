using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueGameObject : OnDialogueLine
{

    GameObject GameObject;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject = this.gameObject;
    }

    public void Update()
    {
        base.Update();

        if(HasFaded && !fade.fadeBoth)
        {
            HasFaded = false;
            GameObject.SetActive(active);
        }
    }

    public override void CorrectDialoguePlaying(bool Active)
    {
        active = Active;
        HasFaded = true;
        FindObjectOfType<Fade>().fadeOut = true;
        FindObjectOfType<Fade>().fadeBoth = true;
    }
}
