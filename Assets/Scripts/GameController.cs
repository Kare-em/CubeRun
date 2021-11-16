using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //singleton
    public static GameController Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(this);
        Time.timeScale = 0f;
        Application.targetFrameRate = 120;
    }
    //
    public void StartGame()
    {
        Time.timeScale = 1f;
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
