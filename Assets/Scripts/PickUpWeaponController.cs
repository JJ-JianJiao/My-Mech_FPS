using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeaponController:PickUp
{
    [SerializeField]
    private GameObject weaponPrefab;

    public bool isDroped = false;

    public int maxBullets ;
    public int currentBullets ;
    public AudioSource pickUpAS;

    protected override void Start()
    {
        base.Start();
        pickUpAS.ignoreListenerPause = true;
    }

    protected override void Update()
    {
        base.Update();
        //transform.LeanMoveY(1f, 1f).setLoopPingPong();
        //Debug.Log("this is overrride the PickUp Update()");
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag.Equals("Player")) {
            if (isDroped) {
                isDroped = false;
                //Debug.Log("This is the first drop from the player");
                return;
            }
            WeaponControl playerWeaponControl = other.GetComponent<WeaponControl>();
            //if (playerWeaponControl.PickUpWeapon(weaponPrefab)) {
            //    gameObject.SetActive(false);
            //}
            playerWeaponControl.PickUpWeapon(weaponPrefab, this.gameObject);
            pickUpAS.Play();
            //Debug.Log("I get this weapon");
        }   
    }

    public void DropedPickUpWeapon() {
        Invoke("EnableCollider",3f);
    }

    private void EnableCollider() {
        transform.GetComponent<Collider>().enabled = true;
    }

    public void SetCurrentBullet(int i) {
        currentBullets = i;
    }

    public int GetCurrentBullet()
    {
        return currentBullets;
    }
}
