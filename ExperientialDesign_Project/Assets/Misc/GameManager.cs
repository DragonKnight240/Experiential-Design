using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance_;
    int Karma = 0;

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

    void increaseKarma(int amount)
    {
        Karma += amount;
    }

    void decreaseKarma(int amount)
    {
        Karma -= amount;
    }

    public int GetKarma()
    {
        return Karma;
    }
}
