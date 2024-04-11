using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{
    public string menuSceneName = "Main Menu";
    
    public string nextLevel = "Level 2";
    public int levelToUnlock = 2;
    
    public SceneFader sceneFader;

    public void Continue()
    {
        Debug.Log("Level Completed!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
