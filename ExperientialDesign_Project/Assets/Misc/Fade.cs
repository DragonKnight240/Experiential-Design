using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float FadeRate;
    public Image FadingObject;
    public bool StartWithFadeIn = false;
    internal bool fadeIn = false;
    internal bool fadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        if(StartWithFadeIn)
        {
            fadeIn = true;
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeIn)
        {
            FadingObject.color = new Color(FadingObject.color.r, FadingObject.color.g, FadingObject.color.b, FadingObject.color.a - (FadeRate * Time.unscaledDeltaTime));

            if(FadingObject.color.a <= 0)
            {
                fadeIn = false;
                Time.timeScale = 1;
            }
        }

        if (fadeOut)
        {
            FadingObject.color = new Color(FadingObject.color.r, FadingObject.color.g, FadingObject.color.b, FadingObject.color.a + (FadeRate * Time.unscaledDeltaTime));

            if (FadingObject.color.a >= 1)
            {
                fadeOut = false;
                Time.timeScale = 1;
            }
        }
    }


}
