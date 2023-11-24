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
        if (File.Exists(Path.Combine(Application.persistentDataPath, $"game1.save")))
        {
            return true;
        }
        else if (File.Exists(Path.Combine(Application.persistentDataPath, $"game2.save")))
        {
            return true;
        }
        else if (File.Exists(Path.Combine(Application.persistentDataPath, $"game3.save")))
        {
            return true;
        }
        else { return false; }
    }

    public static GameState LoadSave(string slotChosen)
    {
        if (CheckHasSave())
        {
            var path = Path.Combine(Application.persistentDataPath, $"game{slotChosen}.save");
            var serializedSave = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<GameState>(serializedSave);
        }
        else { return null; }
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