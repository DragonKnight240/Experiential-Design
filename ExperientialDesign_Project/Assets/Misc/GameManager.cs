using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance_;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance_ == null)
        {
            Instance_ = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
