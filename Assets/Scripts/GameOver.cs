using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{    
    public void m_Restart()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void m_MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void m_Exit()
    {
        Application.Quit();
    }
}
