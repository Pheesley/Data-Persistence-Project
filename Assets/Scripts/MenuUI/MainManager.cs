using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // for JSON
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    // data fields to be passed to Main scene
    public string Name; 
    public int bestScore;

    // called when the script instance is being loaded
    private void Awake()
    {
        // MainManager creates a singleton pattern.
        // Ensures that only a single instance of the MainManager can ever exist
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this; // allows Instance to be called from any other script
        DontDestroyOnLoad(gameObject); // the gameObject attached to this script will not be destroyed when the scene changes

        LoadName(); // need to initialize loaded name!
        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int bestScore;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.Name = Name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
        }
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
        }
    }
}

