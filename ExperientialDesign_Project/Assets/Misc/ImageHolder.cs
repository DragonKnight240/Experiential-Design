using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHolder : MonoBehaviour
{
    public List<Sprite> sprites;
    public GameObject Panel;
    int currentSprite = 0;
    public bool inactive = false;
    bool doneOnce = false;
    internal bool finishedFade = false;
    public int disapearMinus = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (!inactive)
        {
            Panel.GetComponent<Image>().sprite = sprites[currentSprite];
        }
        else
        {
            currentSprite = -1;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueSystem.Instance.TWEffect.UIPanel.activeInHierarchy && !inactive)
        {
            Panel.SetActive(true);

            if(finishedFade)
            {
                Panel.GetComponent<Image>().sprite = sprites[currentSprite];
                finishedFade = false;
            }
        }
        else
        {
            Panel.SetActive(false);
        }
    }

    public void ChangeImage()
    {
        if (currentSprite +1 > sprites.Count - disapearMinus && !doneOnce)
        {
            Panel.SetActive(false);
            inactive = true;
            doneOnce = true;
        }
        else
        {
            currentSprite++;
            inactive = false;
        }

        Panel.GetComponent<Image>().sprite = sprites[currentSprite];
    }
}
