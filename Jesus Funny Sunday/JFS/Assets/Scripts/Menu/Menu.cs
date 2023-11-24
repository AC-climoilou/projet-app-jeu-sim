using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject optionsPanel;
    
    
    void Start()
    {
        optionsPanel.SetActive(false);
    }
    
    public void Parametres()
    {
        menu.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void Retour()
    {
        menu.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public static void ToGame()
    {
        SceneNavigator.OpenGame();
    }

    public static void ExitGame()
    {
        SceneNavigator.CloseGame();
    }

}
