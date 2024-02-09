using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject variable;

    public void Pause()
    {
        variable.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        variable.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home(int sceneID)
    {
        variable.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
