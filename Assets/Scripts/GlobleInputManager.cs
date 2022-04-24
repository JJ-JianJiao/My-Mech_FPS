using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobleInputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject changeWeaponPanel;
    [SerializeField]
    private GameObject ChooseWeaponSlotsPanel;
    [SerializeField]
    private GameObject pauseMenuPanel;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && ChooseWeaponSlotsPanel.activeInHierarchy == false) {
            if (changeWeaponPanel.activeInHierarchy == false)
            {
                changeWeaponPanel.SetActive(true);
            }
            else {
                changeWeaponPanel.SetActive(false);
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseMenuPanel.activeInHierarchy == false)
            {
                pauseMenuPanel.SetActive(true);
            }
            else
            {
                pauseMenuPanel.SetActive(false);
            }
        }

    }
}
