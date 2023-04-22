using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string LastScene = "HomeScene";

    public void LoadHomeScene()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("HomeScene");
    }
    public void LoadChapterScene()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("ChapterScene");
    }
    public void LoadLevelScene()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("LevelScene");
    }
    public void LoadInGameScene()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("InGameScene");
    }
    public void LoadOptionScene()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("OptionScene");
    }
    public void LoadStoreScene()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("StoreScene");
    }
    public void LoadLastScene()
    {
        SceneManager.LoadScene(LastScene);
    }
}
