using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int nLives = 1;
    public bool gameIsActive = true;
    public bool gameIsPaused = false;
    public GameObject gameOverScreen;
    public GameObject player;
    public AudioSource gameMusic;

    public int nbrdeMorts = 0;
    public TextMeshProUGUI mortText;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveSystem.gameState != null)
        {
            nbrdeMorts = SaveSystem.gameState.NbrDeMorts;
        }

        instance = this;
        gameOverScreen.SetActive(false);

        if (GameSettings.MuteSound == true)
        {
            gameMusic.Stop();
        }
        else
        {
            gameMusic.volume = GameSettings.SoundVolume;
        }
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
        nbrdeMorts++;
        mortText.text = $"Deaths: {nbrdeMorts}";

        gameIsActive = false;

        gameOverScreen.SetActive(true);

        SaveSystem.SaveGame(new GameState(nbrdeMorts, Menu.slotChosen));
    }

    public void UpdateLives(int livesToAdd = 0)
    {
        nLives += livesToAdd;

        if (nLives <= 0) GameOver();
    }
}
