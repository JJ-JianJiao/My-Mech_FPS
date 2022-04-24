using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    [SerializeField]
    private Transform leftShoulderSlot;
    [SerializeField]
    private Transform rightShoulderSlot;
    [SerializeField]
    private Transform leftHandSlot;
    [SerializeField]
    private Transform rightHandSlot;
    [SerializeField]
    private GameObject chooseWeaponSlotPanel;


    private float timeStamp;
    MyWeaponController weaponController;
    [SerializeField]
    private GameObject leftHandWeaponObj;
    private float leftHandShootRate;


    [SerializeField]
    private GameObject rightHandWeaponObj;
    private float rightHandShootRate;
    [SerializeField]
    private GameObject leftShoulderWeaponObj;
    private float leftShoulderShootRate;
    [SerializeField]
    private GameObject rightSHoulderWeaponObj;
    private float rightShoulderShootRate;

    [SerializeField]
    private WeaponInfoPanel weaponInfoPanel;


    [SerializeField]
    private int currentActiveWeaponIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (!gameObject.GetComponent<HealthController>().IsDie()) {
            ShootUpdate();
        }

    }

    private void ShootUpdate()
    {
        if (Input.GetMouseButton(0) && Time.timeScale == 1) {
            //Debug.Log("Shooooot");
            switch (currentActiveWeaponIndex)
            {
                case 1:
                    if (leftHandWeaponObj) {
                        weaponController = leftHandWeaponObj.GetComponent<MyWeaponController>();
                        if (Time.time > timeStamp + leftHandShootRate)
                        {
                            if (weaponController.Shoot())
                            {
                                weaponInfoPanel.ModifyLeftHandText(weaponController.nameStr, weaponController.currentBullets, weaponController.maxBullets);
                            }
                            timeStamp = Time.time;
                        }
                    }
                    break;
                case 2:
                    if (rightHandWeaponObj)
                    {
                        weaponController = rightHandWeaponObj.GetComponent<MyWeaponController>();
                        if (Time.time > timeStamp + rightHandShootRate)
                        {
                            if (weaponController.Shoot())
                            {
                                weaponInfoPanel.ModifyRightHandText(weaponController.nameStr, weaponController.currentBullets, weaponController.maxBullets);
                            }
                            timeStamp = Time.time;
                        }
                    }
                    break;
                case 3:
                    if (leftShoulderWeaponObj)
                    {
                        weaponController = leftShoulderWeaponObj.GetComponent<MyWeaponController>();
                        if (Time.time > timeStamp + leftShoulderShootRate)
                        {
                            if (weaponController.Shoot())
                            {
                                weaponInfoPanel.ModifyLeftShoulderText(weaponController.nameStr, weaponController.currentBullets, weaponController.maxBullets);
                            }
                            timeStamp = Time.time;
                        }
                    }
                    break;
                case 4:
                    if (rightSHoulderWeaponObj)
                    {
                        weaponController = rightSHoulderWeaponObj.GetComponent<MyWeaponController>();
                        if (Time.time > timeStamp + rightShoulderShootRate)
                        {
                            if (weaponController.Shoot())
                            {
                                weaponInfoPanel.ModifyRightShoulderText(weaponController.nameStr, weaponController.currentBullets, weaponController.maxBullets);
                            }
                            timeStamp = Time.time;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    internal bool PickUpWeapon(GameObject weaponPrefab)
    {
        if (chooseWeaponSlotPanel.activeInHierarchy == false)
        {
            chooseWeaponSlotPanel.SetActive(true);
            ChooseWeaponSlotsPanel panel = chooseWeaponSlotPanel.GetComponent<ChooseWeaponSlotsPanel>();
            panel.SetPickUpWeaponPrefab(weaponPrefab);
        }

        //GameObject generateWeapon = Instantiate(weaponPrefab, leftHandSlot.position, Quaternion.identity);
        GameObject generateWeapon = Instantiate(weaponPrefab, leftHandSlot.position, leftHandSlot.rotation, leftHandSlot);
        generateWeapon.transform.localScale = Vector3.one * 5;
        return true;
    }


    internal void PickUpWeapon(GameObject weaponPrefab, GameObject gameObject)
    {
        if (chooseWeaponSlotPanel.activeInHierarchy == false)
        {
            chooseWeaponSlotPanel.SetActive(true);
            ChooseWeaponSlotsPanel panel = chooseWeaponSlotPanel.GetComponent<ChooseWeaponSlotsPanel>();
            panel.SetPickUpWeaponPrefab(weaponPrefab, gameObject,this.GetComponent<WeaponControl>());
        }
    }

    internal void GenerateLeftHandWeapon(GameObject weaponPrefab, int max, int cur)
    {
        if (leftHandWeaponObj != null) {
            //Debug.Log("I need to drop this current weapon");
            MyWeaponController m_weaponControl = leftHandWeaponObj.GetComponent<MyWeaponController>();
            GeneratePickUpWeapon(m_weaponControl.GetPickUpPrefab(), m_weaponControl.maxBullets, m_weaponControl.currentBullets);
            GameObject.Destroy(leftHandWeaponObj);

        }

        leftHandWeaponObj = GenerateWeapon(weaponPrefab, leftHandSlot, 5);
        leftHandShootRate = leftHandWeaponObj.GetComponent<MyWeaponController>().ShootRate;
        leftHandWeaponObj.GetComponent<MyWeaponController>().maxBullets = max;
        leftHandWeaponObj.GetComponent<MyWeaponController>().currentBullets = cur;
        //weaponController = leftHandWeaponObj.GetComponent<MyWeaponController>();

        weaponInfoPanel.ModifyLeftHandText(leftHandWeaponObj.GetComponent<MyWeaponController>().nameStr, cur,max);

        if (currentActiveWeaponIndex == 0) {
            currentActiveWeaponIndex = 1;
            weaponInfoPanel.SetActiveWeaponInfo(currentActiveWeaponIndex);
            //if (CrossHairController.instance)
            //    CrossHairController.instance.SyncActiveWeaponCrossHair();
        }
        if (CrossHairController.instance && currentActiveWeaponIndex == 1)
            CrossHairController.instance.SyncActiveWeaponCrossHair();
    }


    internal void GenerateRightHandWeapon(GameObject weaponPrefab, int max, int cur)
    {
        if (rightHandWeaponObj != null)
        {
            //Debug.Log("I need to drop this current weapon");
            MyWeaponController m_weaponControl = rightHandWeaponObj.GetComponent<MyWeaponController>();
            GeneratePickUpWeapon(m_weaponControl.GetPickUpPrefab(), m_weaponControl.maxBullets, m_weaponControl.currentBullets);
            GameObject.Destroy(rightHandWeaponObj);

        }

        rightHandWeaponObj = GenerateWeapon(weaponPrefab, rightHandSlot, 5);
        rightHandShootRate = rightHandWeaponObj.GetComponent<MyWeaponController>().ShootRate;
        rightHandWeaponObj.GetComponent<MyWeaponController>().maxBullets = max;
        rightHandWeaponObj.GetComponent<MyWeaponController>().currentBullets = cur;

        weaponInfoPanel.ModifyRightHandText(rightHandWeaponObj.GetComponent<MyWeaponController>().nameStr, cur, max);

        if (currentActiveWeaponIndex == 0)
        {
            currentActiveWeaponIndex = 2;
            weaponInfoPanel.SetActiveWeaponInfo(currentActiveWeaponIndex);
            //if (CrossHairController.instance)
            //    CrossHairController.instance.SyncActiveWeaponCrossHair();
        }

        if (CrossHairController.instance && currentActiveWeaponIndex == 2)
            CrossHairController.instance.SyncActiveWeaponCrossHair();
    }

    internal void GenerateRightShoulderWeapon(GameObject weaponPrefab, int max, int cur)
    {
        if (rightSHoulderWeaponObj != null)
        {
            //Debug.Log("I need to drop this current weapon");
            MyWeaponController m_weaponControl = rightSHoulderWeaponObj.GetComponent<MyWeaponController>();
            GeneratePickUpWeapon(m_weaponControl.GetPickUpPrefab(), m_weaponControl.maxBullets, m_weaponControl.currentBullets);
            GameObject.Destroy(rightSHoulderWeaponObj);

        }

        rightSHoulderWeaponObj =  GenerateWeapon(weaponPrefab, rightShoulderSlot, 5);
        rightShoulderShootRate = rightSHoulderWeaponObj.GetComponent<MyWeaponController>().ShootRate;
        rightSHoulderWeaponObj.GetComponent<MyWeaponController>().maxBullets = max;
        rightSHoulderWeaponObj.GetComponent<MyWeaponController>().currentBullets = cur;

        weaponInfoPanel.ModifyRightShoulderText(rightSHoulderWeaponObj.GetComponent<MyWeaponController>().nameStr, cur, max);


        if (currentActiveWeaponIndex == 0)
        {
            currentActiveWeaponIndex = 4;
            weaponInfoPanel.SetActiveWeaponInfo(currentActiveWeaponIndex);
            //if (CrossHairController.instance)
            //    CrossHairController.instance.SyncActiveWeaponCrossHair();
        }

        if (CrossHairController.instance && currentActiveWeaponIndex == 4)
            CrossHairController.instance.SyncActiveWeaponCrossHair();
    }

    internal void GenerateLeftShoulderWeapon(GameObject weaponPrefab, int max, int cur)
    {
        if (leftShoulderWeaponObj != null)
        {
            //Debug.Log("I need to drop this current weapon");
            MyWeaponController m_weaponControl = leftShoulderWeaponObj.GetComponent<MyWeaponController>();
            GeneratePickUpWeapon(m_weaponControl.GetPickUpPrefab(), m_weaponControl.maxBullets, m_weaponControl.currentBullets);
            GameObject.Destroy(leftShoulderWeaponObj);
        }


        leftShoulderWeaponObj = GenerateWeapon(weaponPrefab, leftShoulderSlot,5);
        leftShoulderShootRate = leftShoulderWeaponObj.GetComponent<MyWeaponController>().ShootRate;
        leftShoulderWeaponObj.GetComponent<MyWeaponController>().maxBullets = max;
        leftShoulderWeaponObj.GetComponent<MyWeaponController>().currentBullets = cur;

        weaponInfoPanel.ModifyLeftShoulderText(leftShoulderWeaponObj.GetComponent<MyWeaponController>().nameStr, cur, max);

        if (currentActiveWeaponIndex == 0)
        {
            currentActiveWeaponIndex = 3;
            weaponInfoPanel.SetActiveWeaponInfo(currentActiveWeaponIndex);
            //if (CrossHairController.instance)
            //    CrossHairController.instance.SyncActiveWeaponCrossHair();
        }

        if (CrossHairController.instance && currentActiveWeaponIndex == 3)
            CrossHairController.instance.SyncActiveWeaponCrossHair();
    }

    private GameObject GenerateWeapon(GameObject weaponPrefab, Transform tram, int scale) {
        GameObject generateWeapon = Instantiate(weaponPrefab, tram.position, tram.rotation, tram);
        generateWeapon.transform.localScale = Vector3.one * scale;
        return generateWeapon;
    }

    public bool HaveLeftHandWeapon() {
        if (leftHandWeaponObj == null)
        {
            return false;
        }
        else {
            return true;
        }
    }

    public bool HaveRightHandWeapon()
    {
        if (rightHandWeaponObj == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool HaveLeftShoulderWeapon()
    {
        if (leftShoulderWeaponObj == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool HaveRightShoulderWeapon()
    {
        if (rightSHoulderWeaponObj == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    internal void SetActiveWeaponIndex(int v)
    {
        currentActiveWeaponIndex = v;
    }


    private void GeneratePickUpWeapon(GameObject obj, int max, int cur)
    {
        GameObject pickUpObj = Instantiate(obj, transform.position, Quaternion.identity);
        PickUpWeaponController pickController = pickUpObj.GetComponent<PickUpWeaponController>();
        pickController.isDroped = true;
        pickController.currentBullets = cur;
        pickController.maxBullets = max;
        //pickUpObj.GetComponent<Collider>().enabled = false;
        //pickUpObj.GetComponent<PickUpWeaponController>()
    }

    internal bool ReloadAmmo()
    {
        int needReload = 0;

        if (leftHandWeaponObj != null) {
            MyWeaponController m_weapon = leftHandWeaponObj.GetComponent<MyWeaponController>();
            if (m_weapon.NeedReload())
            {
                m_weapon.currentBullets = m_weapon.maxBullets;
                weaponInfoPanel.ModifyLeftHandText(m_weapon.nameStr, m_weapon.currentBullets, m_weapon.maxBullets);
                needReload++;
            }
        }
        if (rightHandWeaponObj != null)
        {
            MyWeaponController m_weapon = rightHandWeaponObj.GetComponent<MyWeaponController>();
            if (m_weapon.NeedReload())
            {
                m_weapon.currentBullets = m_weapon.maxBullets;
                weaponInfoPanel.ModifyRightHandText(m_weapon.nameStr, m_weapon.currentBullets, m_weapon.maxBullets);
                needReload++;
            }
        }
        if (leftShoulderWeaponObj != null)
        {
            MyWeaponController m_weapon = leftShoulderWeaponObj.GetComponent<MyWeaponController>();
            if (m_weapon.NeedReload())
            {
                m_weapon.currentBullets = m_weapon.maxBullets;
                weaponInfoPanel.ModifyLeftShoulderText(m_weapon.nameStr, m_weapon.currentBullets, m_weapon.maxBullets);
                needReload++;
            }
        }
        if (rightSHoulderWeaponObj != null)
        {
            MyWeaponController m_weapon = rightSHoulderWeaponObj.GetComponent<MyWeaponController>();
            if (m_weapon.NeedReload())
            {
                m_weapon.currentBullets = m_weapon.maxBullets;
                weaponInfoPanel.ModifyRightShoulderText(m_weapon.nameStr, m_weapon.currentBullets, m_weapon.maxBullets);
                needReload++;
            }
        }

        if (needReload == 0) {
            return false;
        }
        else{
            return true;
        }
    }


    internal GameObject GetActiveWeapon()
    {
        switch (currentActiveWeaponIndex)
        {
            case 1:
                return leftHandWeaponObj;
            case 2:
                return rightHandWeaponObj;
            case 3:
                return leftShoulderWeaponObj;
            case 4:
                return rightSHoulderWeaponObj;
            default:
                return null;
        }

    }
}
