using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TurretController : MonoBehaviour
{
    [SerializeField]
    private GameObject turretPoleObj;

    public GameObject attackTarget;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTarget == null)
        {
            FindPlayer();
        }
        else {
            transform.LookAt(attackTarget.transform);
        }


    }

    private void FindPlayer()
    {
        Collider[] colliders =  Physics.OverlapBox(turretPoleObj.transform.position, Vector3.one * 20);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                attackTarget = collider.gameObject;
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawCube()
    }
}
