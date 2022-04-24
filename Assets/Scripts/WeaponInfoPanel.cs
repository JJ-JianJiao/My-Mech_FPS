using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WeaponInfoPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text leftHandTMP;
    [SerializeField]
    private TMP_Text rightHandTMP;
    [SerializeField]
    private TMP_Text leftShoulderTMP;
    [SerializeField]
    private TMP_Text rightShoulderTMP;


    private float inactiveFontSize = 20f;
    private float activeFontSize = 30f;
    private Color inactiveFontColor = new Color(0.7f, 0.7f, 0.7f);
    private Color activeFontColor = new Color(1f, 1f, 1f);

    private int activeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        InactiveAllText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    internal void ActiveLeftHand()
    {
        InactiveAllText();
        leftHandTMP.color = activeFontColor;
        leftHandTMP.fontSize = activeFontSize;
        activeIndex = 1;
    }

    internal void ActiveRightHand()
    {
        InactiveAllText();
        rightHandTMP.color = activeFontColor;
        rightHandTMP.fontSize = activeFontSize;
        activeIndex = 2;
    }

    internal void ActiveLeftShoulder()
    {
        InactiveAllText();
        leftShoulderTMP.color = activeFontColor;
        leftShoulderTMP.fontSize = activeFontSize;
        activeIndex = 3;
    }

    internal void ActiveRightShoulder()
    {
        InactiveAllText();
        rightShoulderTMP.color = activeFontColor;
        rightShoulderTMP.fontSize = activeFontSize;
        activeIndex = 4;
    }

    private void InactiveAllText() {
        leftHandTMP.color = inactiveFontColor;
        rightHandTMP.color = inactiveFontColor;
        leftShoulderTMP.color = inactiveFontColor;
        rightShoulderTMP.color = inactiveFontColor;

        leftHandTMP.fontSize = inactiveFontSize;
        rightHandTMP.fontSize = inactiveFontSize;
        leftShoulderTMP.fontSize = inactiveFontSize;
        rightShoulderTMP.fontSize = inactiveFontSize;
    }

    internal int GetCurrentActiveInfoIndex()
    {
        return activeIndex;
    }

    internal void SetActiveWeaponInfo(int currentActiveWeaponIndex)
    {
        switch (currentActiveWeaponIndex)
        {
            case 1:
                ActiveLeftHand();
                break;
            case 2:
                ActiveRightHand();
                break;
            case 3:
                ActiveLeftShoulder();
                break;
            case 4:
                ActiveRightShoulder();
                break;
            default:
                break;
        }
    }

    public void ModifyLeftHandText(String name, int current, int max) { 
        leftHandTMP.text = "Left Hand - " + name + ": " + current.ToString() + "/" + max.ToString();
    }

    public void ModifyRightHandText(String name, int current, int max)
    {
        rightHandTMP.text = "Left Hand - " + name + ": " + current.ToString() + "/" + max.ToString();
    }

    public void ModifyLeftShoulderText(String name, int current, int max)
    {
        leftShoulderTMP.text = "Left Hand - " + name + ": " + current.ToString() + "/" + max.ToString();
    }

    public void ModifyRightShoulderText(String name, int current, int max)
    {
        rightShoulderTMP.text = "Left Hand - " + name + ": " + current.ToString() + "/" + max.ToString();
    }
}
