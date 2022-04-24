using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Blaster_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject ps_obj;

    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Projectile"))
        {
            Vector3 location = this.transform.position;
            Vector3 closestPoint = collision.collider.ClosestPoint(location);
            GameObject g_ps = Instantiate(ps_obj);
            g_ps.transform.position = closestPoint;
            g_ps.transform.localScale = Vector3.one;
            Object.Destroy(gameObject);
        }

    }

}
