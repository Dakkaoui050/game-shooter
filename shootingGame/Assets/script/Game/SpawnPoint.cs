using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] spawnLocation;
    public GameObject player;

    private Vector3 RespawnLocation;
    health h;
    private void Awake()
    {
        h = GetComponent<health>();
        spawnLocation = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
    private void Start()
    {
        RespawnLocation = player.transform.position;

        SpawnPlayer();
    }

   private void SpawnPlayer()
    {
        int spawn = Random.Range(0, spawnLocation.Length);
        GameObject.Instantiate(player, spawnLocation[spawn].transform.position, Quaternion.identity);

    }
    public void respawn()
    {
            Debug.Log("respawn compleet");
            int spawn = Random.Range(0, spawnLocation.Length);
            GameObject.Instantiate(player, spawnLocation[spawn].transform.position, Quaternion.identity);
    }
}
