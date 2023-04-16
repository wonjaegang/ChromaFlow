using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{   
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
    public void LoadChapterScene()
    {
        SceneManager.LoadScene("ChapterScene");
    }
    public void LoadLevelScene()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void LoadInGameScene()
    {
        SceneManager.LoadScene("InGameScene");
    }
    public void LoadOptionScene()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
