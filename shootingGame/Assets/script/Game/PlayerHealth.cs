using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float MaxHealth;

    public GameObject HealthBar;
    public Slider Slider;

    public void Start()
    {
        health = MaxHealth;
        Slider.value = CalculateHealth();
        //scoreText.text = "Points: " + 1;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

    }

    public void Update()
    {
        Slider.value = CalculateHealth();

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
