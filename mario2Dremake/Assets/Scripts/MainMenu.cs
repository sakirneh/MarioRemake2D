using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
public void PlayGame()
    {
        SceneManager.LoadScene("Level_00");
    }

    /*
     * SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     * 
     * 
     */

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect"); // when Levels button is clicked it will send player to the level select.
    }
}
