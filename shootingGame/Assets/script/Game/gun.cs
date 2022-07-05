using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public ParticleSystem muzzels;
    public GameObject impEffect;

    public int gunDamage;

    public GameObject MainWeapon;
    public GameObject SecWeapon;
    public GameObject threeWeapon;
    public GameObject MeleeWeapon;

    public GameObject Cam;
    public GameObject aiming;

    health health;


    private void Start()
    {
        health = GetComponent<health>();
    }
    public void switchToMain()
    {
        Debug.Log("main weapon selected");
        MainWeapon.SetActive(true);
        SecWeapon.SetActive(false);
        threeWeapon.SetActive(false);
        MeleeWeapon.SetActive(false);
    }

    public void switchToSecode()
    { 
        Debug.Log("2e weapon selected");
        SecWeapon.SetActive(true);
        MainWeapon.SetActive(false);
        threeWeapon.SetActive(false);
        MeleeWeapon.SetActive(false);
    }
    public void SwitchToThree()
    {
        Debug.Log(" 3e weapon selected");
        threeWeapon.SetActive(true);
        SecWeapon.SetActive(false);
        MainWeapon.SetActive(false);
        MeleeWeapon.SetActive(false);
    }
    public void SwitchToMelee()
    {
        Debug.Log(" melee weapon selected");
        threeWeapon.SetActive(false);
        SecWeapon.SetActive(false);
        MainWeapon.SetActive(false);
        MeleeWeapon.SetActive(true);

    }
    public void Shoot()
    {


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
