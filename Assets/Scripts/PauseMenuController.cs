using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    [SerializeField]
    private EndGameFlade endGameFlade;

    private void OnEnable()
    {
        Cursor.visible = true;
        PauseGame();
    }

    private void OnDisable()
    {
        Cursor.visible = false;
        ResumeGame();
    }
    // Start is called before the first frame update

    public void ContinueBtnOnClick() {
        gameObject.SetActive(false);
    }

    public void QuitToMainBtnOnClick() {
        ResumeGame();
        //SceneManager.LoadScene("");
        endGameFlade.SetEndGameType(0);
    }

    private void PauseGame() {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    private void ResumeGame() {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
