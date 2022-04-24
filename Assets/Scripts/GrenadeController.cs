using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Paintable")
        {

            WallStatus wallStatus = collision.gameObject.GetComponentInParent<WallStatus>();
            if (wallStatus != null && collision.transform.GetComponent<Renderer>().material.color == Color.white)
            {
                collision.transform.GetComponent<Renderer>().material.color = this.GetComponentInChildren<Renderer>().material.color;

                wallStatus.GetPainted();
            }
            else {
                collision.transform.GetComponent<Renderer>().material.color = this.GetComponentInChildren<Renderer>().material.color;

            }

            Destroy(gameObject);

            //collision.transform.GetComponent<Renderer>().material.color = this.GetComponentInChildren<Renderer>().material.color;

        }
        //Destroy(gameObject);
    }
}
