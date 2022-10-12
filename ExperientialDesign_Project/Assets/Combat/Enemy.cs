using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int Damage;
    public int ChaseSpeed;
    public int AttackSpeed;
    float AttackTimer = 0;
    EnemyMovement Movement;

    bool InRange = false;
    Vector3 StartPos;
    internal bool ChasePlayer = false;
    public BoxCollider MeleeZone;
    Player Player;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        Player = FindObjectOfType<Player>();
        Movement = GetComponent<EnemyMovement>();
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
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, ChaseSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("PlayerRange"))
        {
            InRange = true;
            ChasePlayer = false;
        }

        if (other.transform.CompareTag("Player"))
        {
            ChasePlayer = true;
            Movement.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print(other.name);
        if (other.transform.CompareTag("PlayerRange"))
        {
            InRange = false;
            ChasePlayer = true;
        }

        if (other.transform.CompareTag("Player"))
        {
            ChasePlayer = true;
            Movement.enabled = false;
        }
    }
}
