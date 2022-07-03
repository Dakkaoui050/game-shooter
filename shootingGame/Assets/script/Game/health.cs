using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{   //health
    public float Health;  
    public float MaxHealth;

    //range of damage. (I chance this later voor each weapon)
    public int minDmg = 1;
    public int maxDmg = 10;


    public GameObject HealthBar;
    public Slider Slider;

    public void Damage(int amount)
    {
        Health -= Random.Range(minDmg, maxDmg);

        Health -= amount;
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    public void Start()
    {
        Health = MaxHealth;
        Slider.value = CalculateHealth();
        //scoreText.text = "Points: " + 1;
    }


    public void Update()
    {
        Slider.value = CalculateHealth();

        if (Health <= 0)
        {

            Destroy(gameObject);

        }
    }

    float CalculateHealth()
    {//als de max health 100 is en health 10 veranderd de healthbar
        return Health / MaxHealth;
    }


    





}
