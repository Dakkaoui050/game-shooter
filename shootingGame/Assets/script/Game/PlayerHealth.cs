using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float MaxHealth;

    public GameObject enemy;

    public void Start()
    {
        health = MaxHealth;
      
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

    }

    public void Update()
    {
        

        if (health <= 0)
        {
           
            Destroy(gameObject);

        }
    }

    float CalculateHealth()
    {//als de max health 100 is en health 10 veranderd de healthbar
        return health / MaxHealth;
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            Debug.Log("Enemy started colliding with player.");


            this.health -= 10;

        }

    }

}
