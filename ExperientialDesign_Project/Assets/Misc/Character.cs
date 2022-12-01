using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int StartingOpinion = 0;
    int OpinionOfPlayer;

    // Start is called before the first frame update
    void Start()
    {
        OpinionOfPlayer = StartingOpinion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetOpinionOfPlayer()
    {
        return OpinionOfPlayer;
    }
}
