using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuUIHandler : MonoBehaviour
{
    public MainManager mainManager;
    public static string currentName;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
        BestScoreName.Instance.SaveBest();
    }
    //set input name from input field
    public void ReadStringInput(string name)
    {
        currentName = name;
       // BestScoreName.Instance.setPlayerName(name);
        Debug.Log(name);
    }
}
