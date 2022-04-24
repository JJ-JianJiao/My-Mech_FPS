using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{

    public GameObject barrelEnd;
    public GameObject grenade;
    public GameObject weaponModel;

    public float timeStamp;
    public float shootRate;

    public GameObject crosshair;

    public Color[] barrelColors;

    int colorIndex;

    // Start is called before the first frame update
    void Start()
    {
        timeStamp = 0.0f;
        shootRate = 0.5f;
        colorIndex = 0;

        weaponModel.GetComponent<Renderer>().material.color = barrelColors[colorIndex];
        crosshair.GetComponent<Image>().color = new Color(barrelColors[colorIndex].r, barrelColors[colorIndex].g, barrelColors[colorIndex].b, 1.0f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireGrenade(float speed) {

        if (Time.time > timeStamp + shootRate)
        {

            GameObject InstantiateGrenade = Instantiate(grenade, barrelEnd.transform.position, barrelEnd.transform.rotation);
            InstantiateGrenade.GetComponent<Rigidbody>().velocity = barrelEnd.transform.forward * speed;
            InstantiateGrenade.GetComponentInChildren<Renderer>().material.color = weaponModel.GetComponent<Renderer>().material.color;
            Physics.IgnoreCollision(InstantiateGrenade.GetComponentInChildren<Collider>(), this.GetComponentInChildren<Collider>());

            timeStamp = Time.time;
        }
    
    }

    public void ChangeBarrelColor() {

        colorIndex++;
        if (colorIndex >= barrelColors.Length) {

            colorIndex = 0;
        
        }
        weaponModel.GetComponent<Renderer>().material.color = barrelColors[colorIndex];
        crosshair.GetComponent<Image>().color = new Color(barrelColors[colorIndex].r, barrelColors[colorIndex].g, barrelColors[colorIndex].b, 1.0f);

    }

}
