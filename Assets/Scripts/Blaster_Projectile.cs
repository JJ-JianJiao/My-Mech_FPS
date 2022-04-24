using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster_Projectile : MonoBehaviour
{
    [SerializeField]
    private GameObject ps_obj;
    RaycastHit hit;
    public float hitDistance = 1f;
    bool getHitPosition = false;
    Vector3 myPosition_PS;
    [SerializeField]
    private float hitDamage;

    public bool isPlayerOwner = true;

    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, hitDistance) && !getHitPosition)
        {
            if (!hit.transform.CompareTag("Projectile") && !hit.transform.CompareTag("PickUp") && !hit.transform.CompareTag("Player"))
            {
                getHitPosition = true;
                myPosition_PS = transform.position;
            }

            //GameObject g_ps = Instantiate(ps_obj);
            //g_ps.transform.position = transform.position;
            //g_ps.transform.localScale = Vector3.one;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Projectile")) {
            return;
        }

        if (collision.transform.CompareTag("PickUp"))
        {
            return;
        }

        if (isPlayerOwner)
        {
            if (collision.transform.CompareTag("Player"))
            {
                return;
            }
        }
        else {

            if (collision.transform.CompareTag("Enemy"))
            {
                return;
            }
        }
        if (!collision.transform.name.Contains("Mesh")) {
            //Debug.Log(collision.transform.name);
        }
        //collision.transform.get


        if (collision.gameObject.GetComponent<HealthController>()) {
            collision.gameObject.GetComponent<HealthController>().GetDamage(hitDamage);
            //if (collision.gameObject.CompareTag("Enemy")) {
            //    if (collision.gameObject.name.Contains("HoveBot")) {
            //        Enemy_HoverBot_Controller ehc = collision.gameObject.GetComponent<Enemy_HoverBot_Controller>();
            //        if(ehc.HasAttackTarget() == false) {
            //            ehc.SetAttackTarget
            //        }
            //    }
            //}
        }

        Vector3 location = this.transform.position;
        Vector3 closestPoint = collision.collider.ClosestPoint(location);
        GameObject g_ps = Instantiate(ps_obj);
        if (myPosition_PS == Vector3.zero)
        {
            g_ps.transform.position = transform.position;
        }
        else
        {
            g_ps.transform.position = myPosition_PS;
        }
        g_ps.transform.localScale = Vector3.one;
        Destroy(gameObject);


    }
}
