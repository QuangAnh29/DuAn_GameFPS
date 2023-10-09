using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    private void Awake()
    {
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
