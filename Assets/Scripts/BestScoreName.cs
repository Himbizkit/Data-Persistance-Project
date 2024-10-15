using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BestScoreName : MonoBehaviour
{
    public static BestScoreName Instance;
    private string PlayerName;
    public int bestScore;

 
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBest();
    }

    public string getPlayerName()
    {
        return PlayerName;
    }
    public void setPlayerName(string name)
    {
        this.PlayerName = name;
    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveBest()
    {
        SaveData data = new SaveData();
        data.playerName = PlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/BestScoreName.json", json);
        
    }

    public void LoadBest()
    {
        string path = Application.persistentDataPath + "/BestScoreName.json";
    
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            setPlayerName(data.playerName); 
            bestScore = data.bestScore;
        }
        else
        {
            setPlayerName("");
            bestScore = 0;

        }
    }

}
