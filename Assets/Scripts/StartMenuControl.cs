using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuControl : MonoBehaviour
{
    public GameObject controlPanel;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void ControlBtnOnClick() {
        if (controlPanel.gameObject.activeInHierarchy)
        {
            controlPanel.SetActive(false);
        }
        else {
            controlPanel.SetActive(true);

        }
    }

    public void StartGameBtnOnClick() {
        SceneManager.LoadScene("Level01");
    }

    public void QuitBtnOnClick() {
        Application.Quit();
    }
}
