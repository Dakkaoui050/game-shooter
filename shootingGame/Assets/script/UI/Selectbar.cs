using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectbar : MonoBehaviour
{
    public GameObject MainWeapon;
    public GameObject SecWeapon;
    public GameObject threeWeapon;
    public GameObject MeleeWeapon;
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
}
