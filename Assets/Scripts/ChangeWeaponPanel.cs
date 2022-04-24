using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeaponPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponInfoPanel;
    private WeaponInfoPanel weaponInfo;
    [SerializeField]
    private WeaponControl playerWeaponController;
    [SerializeField]
    private Button L_Hand;
    [SerializeField]
    private Button R_Hand;
    [SerializeField]
    private Button L_Shoulder;
    [SerializeField]
    private Button R_Shoulder;

    private Color selectedColor = new Color(0, 1, 0);
    private Color normalColor = new Color(0.7686275f, 0.7686275f, 0.7686275f);

    private void OnEnable()
    {
        Cursor.visible = true;
        Time.timeScale = 0.05f;
        AudioListener.pause = true;

        if (playerWeaponController != null) {
            if (playerWeaponController.HaveLeftHandWeapon())
            {
                L_Hand.interactable = true;
            }
            else {
                L_Hand.interactable = false;
            }
            if (playerWeaponController.HaveRightHandWeapon()) {
                R_Hand.interactable = true;
            }
            else
            {
                R_Hand.interactable = false;
            }
            if (playerWeaponController.HaveLeftShoulderWeapon())
            {
                L_Shoulder.interactable = true;
            }
            else
            {
                L_Shoulder.interactable = false;
            }
            if (playerWeaponController.HaveRightShoulderWeapon())
            {
                R_Shoulder.interactable = true;
            }
            else
            {
                R_Shoulder.interactable = false;
            }
        }

        switch (weaponInfoPanel.GetComponent<WeaponInfoPanel>().GetCurrentActiveInfoIndex())
        {
            case 1:
                L_Hand.image.color = selectedColor;
                L_Hand.interactable = false;
                break;
            case 2:
                R_Hand.image.color = selectedColor;
                R_Hand.interactable = false;
                break;
            case 3:
                L_Shoulder.image.color = selectedColor;
                L_Shoulder.interactable = false;
                break;
            case 4:
                R_Shoulder.image.color = selectedColor;
                R_Shoulder.interactable = false;
                break;
            default:
                break;
        }
    }

    private void OnDisable()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        ResetAllColor();
        if (CrossHairController.instance)
            CrossHairController.instance.SyncActiveWeaponCrossHair();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (weaponInfoPanel) {
            weaponInfo = weaponInfoPanel.GetComponent<WeaponInfoPanel>();
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectLeftHand() {
        weaponInfo.ActiveLeftHand();
        if (playerWeaponController) {
            playerWeaponController.SetActiveWeaponIndex(1);
        }
        gameObject.SetActive(false);
    }

    public void SelectRightHand()
    {
        weaponInfo.ActiveRightHand();
        if (playerWeaponController)
        {
            playerWeaponController.SetActiveWeaponIndex(2);
        }
        gameObject.SetActive(false);
    }

    public void SelectLeftShoulder()
    {
        weaponInfo.ActiveLeftShoulder();
        if (playerWeaponController)
        {
            playerWeaponController.SetActiveWeaponIndex(3);
        }
        gameObject.SetActive(false);
    }

    public void SelectRightShoulder()
    {
        weaponInfo.ActiveRightShoulder();
        if (playerWeaponController)
        {
            playerWeaponController.SetActiveWeaponIndex(4);
        }
        gameObject.SetActive(false);
    }

    private void ResetAllColor() {
        L_Hand.image.color = normalColor;
        R_Hand.image.color = normalColor;
        L_Shoulder.image.color = normalColor;
        R_Shoulder.image.color = normalColor;
    }

}
