using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu instance;
    public GameObject menu;
    public GameObject optionsPanel;
    public GameObject slots;
    public Button buttonContinuer;
    public string slotChosen;
    public string state;

    public Button slot1;
    public Button slot2;
    public Button slot3;

    void Start()
    {
        instance = this;

        if (SaveSystem.CheckHasSave())
        {
            buttonContinuer.interactable = true;
        }

        optionsPanel.SetActive(false);
        slots.SetActive(false);
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
        slots.SetActive(false);
    }
    public void Slot1()
    {
        slotChosen = "1";
        ToGame();
    }

    public void Slot2()
    {
        slotChosen = "2";
        ToGame();
    }

    public void Slot3()
    {
        slotChosen = "3";
        ToGame();
    }

    public void NouvellePartie()
    {
        state = "new";
        menu.SetActive(false);
        slots.SetActive(true);

        slot1.interactable = true;
        slot2.interactable = true;
        slot3.interactable = true;
    }

    public void Continuer()
    {
        SaveSystem.CheckHasSave();
        state = "continuer";
        menu.SetActive(false);
        slots.SetActive(true);
    }

    public void ToGame()
    {
        if (state.Equals("continuer"))
        {
            SaveSystem.gameState = SaveSystem.LoadSave(slotChosen);
            SceneNavigator.OpenGame();
        }
        else
        {
            SaveSystem.gameState = new GameState(0, slotChosen);
            SceneNavigator.OpenGame();
        }
    }

    public static void ExitGame()
    {
        SceneNavigator.CloseGame();
    }

}
