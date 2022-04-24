using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairController : MonoBehaviour
{

    public static CrossHairController instance;

    [SerializeField]
    private List<Sprite> crossHairs;
    [SerializeField]
    private WeaponControl m_weaponControl;
    [SerializeField]
    private Image my_ch;

    private void OnEnable()
    {
        SyncActiveWeaponCrossHair();
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentCrossHair(int i) {
        if (i == 0)
        {
            my_ch.sprite = crossHairs[0];
            //my_ch.color = new Color(11 / 255f, 191 / 255f, 0f);
            gameObject.transform.localScale = Vector3.one;
        }
        else if (i == 1)
        {
            my_ch.sprite = crossHairs[1];
            gameObject.transform.localScale = Vector3.one * 1.5f;
            //my_ch.color = new Color(11 / 255f, 191 / 255f, 0f);
        }
        else if (i == 2) {
            my_ch.sprite = crossHairs[2];
            gameObject.transform.localScale = Vector3.one * 1.5f;

        }
    }

    public void SyncActiveWeaponCrossHair() {
        GameObject currentWeapon =  m_weaponControl.GetActiveWeapon();
        if (currentWeapon != null) {
            string n = currentWeapon.GetComponent<MyWeaponController>().nameStr;
            if (n.Equals("Blaster"))
            {
                SetCurrentCrossHair(0);
            }
            else if (n.Equals("Launcher"))
            {
                SetCurrentCrossHair(1);
            }
            else if (n.Equals("ShotGun")) {
                SetCurrentCrossHair(2);
            }


        }

    }
}
