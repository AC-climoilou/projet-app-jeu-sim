using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OpenMenu();
    }

    //Ouvre la scene Menu
    public static void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //Ouvre la scene Game
    public static void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }

    public static void OpenCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    //Ferme le jeu
    public static void CloseGame()
    {
        Application.Quit();
    }
}
