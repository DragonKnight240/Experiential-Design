using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAppear : MonoBehaviour
{
    public GameObject Speech;
    public TextMeshProUGUI TMComp;
    string fullString;
    public float RevealMax;
    float RevealTimer = 0;
    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        TMComp = GetComponent<TextMeshProUGUI>();
        fullString = TMComp.text;
        TMComp.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        RevealTimer += Time.deltaTime;

        if(RevealMax <= RevealTimer)
        {
            RevealTimer = 0;
            if (fullString == TMComp.text)
            {
                TMComp.text = "";
                currentIndex = 0;
            }
            else
            {
                TMComp.text += fullString[currentIndex];
                currentIndex++;
            }
        }
    }
}
