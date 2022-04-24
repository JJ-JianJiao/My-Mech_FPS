using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [Tooltip("Health component to track")] public HealthController Health;

    [Tooltip("Image component displaying health left")]
    public Image HealthBarImage;

    [Tooltip("The floating healthbar pivot transform")]
    public Transform HealthBarPivot;

    [Tooltip("Whether the health bar is visible when at full health or not")]
    public bool HideFullHealthBar = true;


    public GameObject thridViewCam;
    public GameObject firstViewCam;


    // Update is called once per frame
    void Update()
    {
        // update health bar value
        HealthBarImage.fillAmount = Health.currentHealth / Health.maxHealth;

        // rotate health bar to face the camera/player
        if(thridViewCam.activeInHierarchy)
            HealthBarPivot.LookAt(thridViewCam.transform.position);
        else if(firstViewCam.activeInHierarchy)
            HealthBarPivot.LookAt(firstViewCam.transform.position);


        // hide health bar if needed
        if (HideFullHealthBar)
            HealthBarPivot.gameObject.SetActive(HealthBarImage.fillAmount != 1);
    }
}
