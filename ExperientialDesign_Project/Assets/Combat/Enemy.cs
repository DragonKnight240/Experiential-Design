using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int Damage;
    public int Speed;
    public int AttackSpeed;
    float AttackTimer = 0;

    bool InRange = false;
    Vector3 StartPos;
    internal bool ChasePlayer = false;
    SphereCollider PlayerRange;
    public BoxCollider MeleeZone;
    Player Player;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        PlayerRange = GetComponent<SphereCollider>();
        Player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Chase();

        if(InRange || AttackTimer != 0)
        {
            Attack();
        }

    }

    void Attack()
    {
        if(AttackTimer >= AttackSpeed)
        {
            AttackTimer += Time.deltaTime;
            if (InRange)
            {
                StartCoroutine(Collision());
            }

            AttackTimer = 0;
        }

    }

    IEnumerator Collision()
    {
        MeleeZone.enabled = true;
        yield return new WaitForSeconds(2);
        MeleeZone.enabled = true;
    }

    void Chase()
    {
        if (ChasePlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("PlayerRange"))
        {
            InRange = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.CompareTag("PlayerRange"))
        {
            InRange = false;
        }
    }
}
