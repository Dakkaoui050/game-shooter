using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject player;
    health h;
    private float deathcounter = 3f;
    // Start is called before the first frame update
    void Start()
    {
        h = GetComponent<health>();
    
         Instantiate(player, transform.position, transform.rotation);
    }

    // Update is called once per frame
    public void Update()
    { 
       

        if (h.Health == 0)
        {
            StartCoroutine(restart());
           Instantiate(player, transform.position, transform.rotation);
        }
    }
    IEnumerator restart()
    {
        yield return new WaitForSeconds(deathcounter); 
        
    }
}
