using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int Health;

    public void Damage(int amount)
    {

        Health -= amount;
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
