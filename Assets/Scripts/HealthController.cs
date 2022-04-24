using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Image currentHealthImg;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //currentHealthImg.fillAmount = currentHealth / maxHealth;
        //if (Input.GetKeyDown(KeyCode.Z)) {
        //    currentHealth--;
        //}
    }

    private void LateUpdate()
    {
        if (currentHealthImg == null) {
            return;
        }

        currentHealthImg.fillAmount = currentHealth / maxHealth;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentHealth -= 300;
        }
    }

    internal bool IsDie()
    {
        return currentHealth <= 0 ? true: false;
    }

    internal void GetDamage(float hitDamage)
    {
        currentHealth -= hitDamage;
        currentHealth = (currentHealth <= 0 ? 0 : currentHealth);
    }

    internal bool GetHurt() {
        if (currentHealth < maxHealth)
        {
            return true;
        }
        else {
            return false;
        }
    }
}
