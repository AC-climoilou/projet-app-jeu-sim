using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static GameState gameState;

    public static void SaveGame(GameState gameState)
    {
        var serializedSave = JsonConvert.SerializeObject(gameState);

        var path = Path.Combine(Application.persistentDataPath, $"game{gameState.GameSave}.save");
        File.WriteAllText(path, serializedSave);
    }

    public static bool CheckHasSave()
    {
        int compteur = 0;

        if (!File.Exists(Path.Combine(Application.persistentDataPath, $"game1.save")))
        {
            Menu.instance.slot1.interactable = false;
        }

        if (!File.Exists(Path.Combine(Application.persistentDataPath, $"game2.save")))
        {
            Menu.instance.slot2.interactable = false;
        }
        if (!File.Exists(Path.Combine(Application.persistentDataPath, $"game3.save")))
        {
            Menu.instance.slot3.interactable = false;
        }

        if(compteur > 0)
        {
            return true;
        }
        else { return false; }
    }

    public static GameState LoadSave(string slotChosen)
    {
            var path = Path.Combine(Application.persistentDataPath, $"game{slotChosen}.save");
            var serializedSave = File.ReadAllText(path);
            
            return JsonConvert.DeserializeObject<GameState>(serializedSave);
    }
}

public class GameState
{
    //Attribut
    private int nbrDeMorts; //Le nombre de fois que le joueur est mort
    private string gameSave; // La partie à sauvegarder

    public int NbrDeMorts { get => nbrDeMorts; set => nbrDeMorts = value; }
    public string GameSave { get => gameSave; set => gameSave = value; }

    public GameState(int nbrDeMorts, string gameSave)
    {
        this.NbrDeMorts = nbrDeMorts;
        this.GameSave = gameSave;
    }
}