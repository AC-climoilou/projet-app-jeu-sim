using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int nLives = 1;
    public bool gameIsActive = true;
    public bool gameIsPaused = false;
    public GameObject gameOverScreen;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f - Time.timeScale;

            if (PausePanel.instance.pausePanel.activeSelf == false)
            {
                gameIsPaused = true;
                PausePanel.instance.OpenPausePanel();
            }
            else
            {
                gameIsPaused = false;
                PausePanel.instance.pausePanel.SetActive(false);
            }
        }
    }

    public void SetPause(bool val = true)
    {
        Time.timeScale = val ? 1f : 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameIsActive = false;

        gameOverScreen.SetActive(true);
    }

    public void UpdateLives(int livesToAdd = 0)
    {
        nLives += livesToAdd;

        if (nLives <= 0) GameOver();
    }
}
