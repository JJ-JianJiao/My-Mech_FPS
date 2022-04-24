using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameFlade : MonoBehaviour
{
    public bool isEndGame;
    public bool isChangeScene = false;
    private string winGame = "WinScene";
    private string loseGame = "LoseScene";
    private string mainMenu = "StartMenu";

    public CanvasGroup canvasGroup;
    public int endGameType = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F8)) {
            SetEndGameType(1);
        }

        if (isEndGame && !isChangeScene) {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha += 0.005f;
            if (canvasGroup.alpha > 1) {
                canvasGroup.alpha = 1;
            }
        }

        if (canvasGroup.alpha >= 1 && !isChangeScene) {
            isChangeScene = true;
            if (endGameType == 1)
            {
                SceneManager.LoadScene(winGame);
            }
            else if(endGameType == 2) {
                SceneManager.LoadScene(loseGame);
            }
            else if (endGameType == 0)
            {
                SceneManager.LoadScene(mainMenu);
            }

        }
    }

    public void SetEndGameType(int t) {
        isEndGame = true;
        endGameType = t;
    }
}
