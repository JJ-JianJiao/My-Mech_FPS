using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWeaponController : MonoBehaviour
{
    public string nameStr;

    [SerializeField]
    private GameObject pickUpObject;

    [SerializeField]
    private Transform GunMuzzle;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private AudioSource shootAS;
    [SerializeField]
    private GameObject shootMuzzle_PS;

    public float ShootRate;
    public float shootSpeed;

    public int bulletsPerShoot;
    public bool m_useGravity = false;

    [Tooltip("Angle for the cone in which the bullets will be shot randomly (0 means no spread at all)")]
    public float BulletSpreadAngle = 0f;

    public int maxBullets;
    public int currentBullets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal bool Shoot()
    {
        if (currentBullets <= 0) {
            return false;
        }

        shootAS.Play();
        //Debug.Log("Plaer Ask me to shoot");
        GameObject muzzle_PS = Instantiate(shootMuzzle_PS, GunMuzzle.position, GunMuzzle.rotation, GunMuzzle);
        muzzle_PS.transform.localScale = Vector3.one * 2;
        muzzle_PS.transform.SetParent(null);
        Destroy(muzzle_PS, 2f);

        /*
        GameObject bullet = Instantiate(projectile, GunMuzzle.position, GunMuzzle.rotation);
        Rigidbody rb =  bullet.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = transform.forward * shootSpeed;
        */

        for (int i = 0; i < bulletsPerShoot; i++)
        {
            Vector3 shotDirection = GetShotDirectionWithinSpread(GunMuzzle);
            //GameObject bullet = Instantiate(projectile, GunMuzzle.position, Quaternion.LookRotation(shotDirection));
            GameObject bullet = Instantiate(projectile, GunMuzzle.position, Quaternion.Euler(shotDirection));
            Rigidbody rb = bullet.AddComponent<Rigidbody>();
            if (m_useGravity)
            {
                rb.useGravity = true;
            }
            else {
                rb.useGravity = false;
            }
            rb.velocity = transform.forward * shootSpeed;
        }
        currentBullets--;
        return true;
    }

    private Vector3 GetShotDirectionWithinSpread(Transform gunMuzzle)
    {
        float spreadAngleRatio = BulletSpreadAngle / 180f;
        Vector3 spreadWorldDirection = Vector3.Slerp(gunMuzzle.forward, UnityEngine.Random.insideUnitSphere,
            spreadAngleRatio);

        return spreadWorldDirection;
    }

    internal GameObject GetPickUpPrefab()
    {
        return pickUpObject;
    }

    internal bool NeedReload()
    {
        return currentBullets != maxBullets ? true : false;
    }
}
