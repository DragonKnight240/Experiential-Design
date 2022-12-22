using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health;
    internal Weapons EquipedWeapon;
    Rigidbody RB;
    public BoxCollider MeleeAttackZone;
    public float Speed;
    public float Seconds = 2;
    float Timer = 0;
    bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        //MeleeAttackZone = GetComponent<BoxCollider>();
        MeleeAttackZone.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(MeleeAttackZone.enabled)
        {
            Timer += Time.deltaTime;

            if(Timer >= Seconds)
            {
                MeleeAttackZone.enabled = false;
                Timer = 0;
            }
        }

        if (!isDead)
        {
            Move();

            if (EquipedWeapon == null)
            {
                if (Input.GetButton("Fire1"))
                {
                    MeleeAttackZone.enabled = true;
                }
            }
        }
    }

    void TakeDamage(int amount)
    {
        Health -= amount;

        if(Health <= 0)
        {
            Death();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //RB.velocity = ((transform.forward * z) * Speed) + ((transform.right * x) * Speed) + (new Vector3(0, RB.velocity.z, 0));

        if (x != 0 || z != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(x, 0, z));
        }
        
        RB.velocity = new Vector3(x * Speed, RB.velocity.y, Speed * z);
    }

    void EquipWeapon(Weapons newWeapon)
    {
        EquipedWeapon = newWeapon;
    }

    void Death()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("MeleeZone"))
        {
            TakeDamage(collision.transform.GetComponent<Enemy>().Damage);
        }

        if(collision.transform.CompareTag("PlayerRange"))
        {
            collision.transform.GetComponent<Enemy>().ChasePlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("PlayerRange"))
        {
            collision.transform.GetComponent<Enemy>().ChasePlayer = false;
        }
    }
}
