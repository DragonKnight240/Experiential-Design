using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHolder : MonoBehaviour
{
    public List<Sprite> sprites;
    public GameObject Panel;
    int currentSprite = 0;
    internal bool inactive = false;
    bool doneOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        Panel.GetComponent<Image>().sprite = sprites[currentSprite];
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueSystem.Instance.TWEffect.UIPanel.activeInHierarchy && !inactive)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
    }

    public void ChangeImage()
    {
        
        if (currentSprite +1 > sprites.Count - 3 && !doneOnce)
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
