using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWeaponSlotsPanel : MonoBehaviour
{
    private GameObject weaponPrefab;
    private GameObject pickUpWeaponPrefab;
    private WeaponControl weaponControl;

    private void OnEnable()
    {
        Cursor.visible = true;
        pickUpWeaponPrefab = null;
        Time.timeScale = 0.05f;
        AudioListener.pause = true;
    }

    private void OnDisable()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void LHandBtnOnClick() {
        int max = -1;
        int cur = -1;
        if (pickUpWeaponPrefab != null)
        {
            max = pickUpWeaponPrefab.GetComponent<PickUpWeaponController>().maxBullets;
            cur = pickUpWeaponPrefab.GetComponent<PickUpWeaponController>().currentBullets;
            //pickUpWeaponPrefab.SetActive(false);
            GameObject.Destroy(pickUpWeaponPrefab);
        }
        weaponControl.GenerateLeftHandWeapon(weaponPrefab, max, cur);
        this.gameObject.SetActive(false);
    }

    public void RHandBtnOnClick()
    {
        int max = -1;
        int cur = -1;
        if (pickUpWeaponPrefab != null)
        {
            max = pickUpWeaponPrefab.GetComponent<PickUpWeaponController>().maxBullets;
            cur = pickUpWeaponPrefab.GetComponent<PickUpWeaponController>().currentBullets;
            //pickUpWeaponPrefab.SetActive(false);
            GameObject.Destroy(pickUpWeaponPrefab);
        }
        weaponControl.GenerateRightHandWeapon(weaponPrefab, max, cur);
        this.gameObject.SetActive(false);
    }

    public void LShoulderBtnOnClick()
    {
        int max = -1;
        int cur = -1;
        if (pickUpWeaponPrefab != null)
        {
            max = pickUpWeaponPrefab.GetComponent<PickUpWeaponController>().maxBullets;
            cur = pickUpWeaponPrefab.GetComponent<PickUpWeaponController>().currentBullets;
            //pickUpWeaponPrefab.SetActive(false);
            GameObject.Destroy(pickUpWeaponPrefab);
        }
        weaponControl.GenerateLeftShoulderWeapon(weaponPrefab, max, cur);
        this.gameObject.SetActive(false);
    }

    public void RShoulderBtnOnClick()
    {
        int max = -1;
        int cur = -1;
        if (pickUpWeaponPrefab != null)
        {
            max = pickUpWeaponPrefab.GetComponent<PickUpWeaponController>().maxBullets;
            cur = pickUpWeaponPrefab.GetComponent<PickUpWeaponController>().currentBullets;
            //pickUpWeaponPrefab.SetActive(false);
            GameObject.Destroy(pickUpWeaponPrefab);
        }
        weaponControl.GenerateRightShoulderWeapon(weaponPrefab, max, cur);
        this.gameObject.SetActive(false);
    }

    public void SetPickUpWeaponPrefab(GameObject prefab, GameObject pickUpPrefab, WeaponControl playerWeaponControl) {
        weaponPrefab = prefab;
        pickUpWeaponPrefab = pickUpPrefab;
        weaponControl = playerWeaponControl;
    }

    internal void SetPickUpWeaponPrefab(GameObject weaponPrefab)
    {
        pickUpWeaponPrefab = weaponPrefab;
    }
}
