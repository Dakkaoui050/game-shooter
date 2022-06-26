using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int Health;

    public int minDmg = 1;
    public int maxDmg = 10;

    public void Damage(int amount)
    {
        Health -= Random.Range(minDmg, maxDmg);

        Health -= amount;
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    
        
   


}
