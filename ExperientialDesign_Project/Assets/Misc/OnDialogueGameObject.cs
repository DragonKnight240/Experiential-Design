using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueGameObject : OnDialogueLine
{

    public GameObject GameObject;
    bool active = false;
    public bool DisableOnEnd = false;
    internal bool pending = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameObject)
        {
            GameObject = this.gameObject;
        }
    }

    public void Update()
    {
        base.Update();

        if(HasFaded && !fade.fadeBoth)
        {
            HasFaded = false;
            //GameObject.SetActive(active);
        }

        if (pending)
        {
            if (!DialogueSystem.Instance.TWEffect.UIPanel.activeInHierarchy)
            {
                GameObject.SetActive(active);
                pending = false;
            }
        }
    }

    public override void CorrectDialoguePlaying(bool Active)
    {
        active = Active;
        //HasFaded = true;
        //fade.fadeOut = true;
        //fade.fadeBoth = true;
        if (DisableOnEnd)
        {
            pending = true;
        }
        else
        {
            GameObject.SetActive(active);
        }

        if(GetComponent<OnAddItem>())
        {
            GetComponent<OnAddItem>().OnAdd();
        }
    }
}
