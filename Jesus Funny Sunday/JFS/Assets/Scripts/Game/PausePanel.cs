using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel;

    public static PausePanel instance;

    public Button buttonRetourAuJeu;
    public Button buttonRetourAuMenu;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        pausePanel.SetActive(false);

        buttonRetourAuJeu.onClick.AddListener(ClosePausePanel);
        buttonRetourAuMenu.onClick.AddListener(RetourAuMenu);
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }

    private void ClosePausePanel()
    {
        Time.timeScale = 1f - Time.timeScale;

        pausePanel.SetActive(false);
        GameManager.instance.gameIsPaused = false;
    }

    private void RetourAuMenu()
    {
        Time.timeScale = 1f - Time.timeScale;
        GameManager.instance.gameIsPaused = false;
        SaveSystem.SaveGame(SaveSystem.gameState);
        SceneNavigator.OpenMenu();
    }
}
