using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance_;
    int Karma = 0;
    int Money = 0;
    internal int GermaineOpinion = 0;
    internal int PlayerGermaineOpinion = 0;

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

        DontDestroyOnLoad(this.gameObject);
    }

    public void increaseKarma(int amount)
    {
        Karma += amount;
    }

    public void decreaseKarma(int amount)
    {
        Karma -= amount;
    }

    public int GetKarma()
    {
        return Karma;
    }

    public int GetMoney()
    {
        return Money;
    }

    public void increaseMoney(int amount)
    {
        Money += amount;
        Inventory.Instance.ChangeMoney();
    }

    public void decreaseMoney(int amount)
    {
        Money -= amount;
        Inventory.Instance.ChangeMoney();
    }
}
