using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAmmoController : PickUp
{
    public AudioSource pickUpAmmoAS;
    protected override void Start()
    {
        base.Start();
        //pickUpAmmoAS.ignoreListenerPause = true;
    }

    protected override void Update()
    {
        base.Update();
        //transform.LeanMoveY(1f, 1f).setLoopPingPong();
        //Debug.Log("this is overrride the PickUp Update()");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            WeaponControl playerWeaponControl = other.GetComponent<WeaponControl>();
            if (!playerWeaponControl.ReloadAmmo())
            {
                return;
            }
            else {
                pickUpAmmoAS.Play();
                transform.LeanScale(Vector3.one * 0.1f, 1f);
                Destroy(gameObject,1f);
            }

        }
    }
}
