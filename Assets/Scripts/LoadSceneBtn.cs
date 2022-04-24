using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class LoadSceneBtn : MonoBehaviour
{
    public string SceneName = "";

    private void Start()
    {
        if(!Cursor.visible)
            Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void LoadTargetScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
