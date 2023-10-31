using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public static void ExitGame()
    {
        Application.Quit();
    }

}
