using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("DemoScene_Forest");
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("Score", 0);
    }

    public void Home()
    {
        SceneManager.LoadScene("Start");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
