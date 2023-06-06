using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndGameManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
