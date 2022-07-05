using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{   
    //effect 
    public ParticleSystem muzzels;
    public GameObject impEffect;

    // Damage
    public int gunDamage;

    // Ammo
    public int MaxAmmo = 20;
    private int CurrentAmmo;
    public float ReloadTime = 2f;
    public bool isReloading = false;

    // the cameras 
    public GameObject Cam;
    public GameObject aiming;

    //scripts
    health health;


    private void Start()
    {
        health = GetComponent<health>();

        CurrentAmmo = MaxAmmo;
    }
    private void OnEnable()
    {
        isReloading = false;
    }
    private void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (CurrentAmmo <= 0)
        {

            StartCoroutine(Reload());
            return;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(ReloadTime);

        CurrentAmmo = MaxAmmo;
        isReloading = false;
    }

    public void Shoot()
    {
        CurrentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit))
        {

            //particle
            muzzels.Play();

            Debug.Log("Hit Something" + hit.transform.name);

            health = hit.transform.GetComponent<health>();
            if (health != null)
            {   //death
                health.Damage(gunDamage);
            }
        }

        if (Physics.Raycast(aiming.transform.position, aiming.transform.forward, out hit))
        {


            //particle
            muzzels.Play();
            Debug.Log("Hit Something wel aiming" + hit.transform.name);

            health = hit.transform.GetComponent<health>();
            if (health != null)
            {
                //death
                health.Damage(gunDamage);
            }
        }
        //the bullet effect
        GameObject effect = Instantiate(impEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
        Destroy(effect, 0.5f);
    }


}
