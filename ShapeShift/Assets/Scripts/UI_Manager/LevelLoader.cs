using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject Loading;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //print("BootScene");
            LoadPlayerCurrentLevel();
        }
        //print(SceneManager.GetActiveScene().buildIndex);
        //LoadPlayerCurrentLevel();
    }

    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        //Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //if (SceneManager.GetActiveScene().buildIndex > 0)
        //{
        //    Loading.SetActive(false);
        //}
        //LevelController.Instance.Init();
        //Debug.Log(LevelController.Instance.ActualLevelNumber);
        //CanvasManager.Instance.LevelText.text = $"LEVEL {LevelController.Instance.ActualLevelNumber}";
        CanvasManager.Instance.Init();
        CanvasManager.Instance.SwitchCanvas( CanvasType.StartScene);
    }


    public void ReloadScene()
    {
        //LevelController.Instance.RestartLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel()
    {
        //LevelController.Instance.LoadNextLevel();
       
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public async void LoadPlayerCurrentLevel()
    { 
        await Task.Delay(100);
        //LevelController.Instance.Init();
        //LevelController.Instance.LoadPlayerCurrentLevel();
    }
}
