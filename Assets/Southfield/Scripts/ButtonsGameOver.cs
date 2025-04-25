using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsGameOver : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("SouthfieldScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
