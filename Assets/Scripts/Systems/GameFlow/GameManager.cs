using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct GameStatePairing
{
    public GameState sceneState;
    public string sceneName;
}

public class GameManager : MonoBehaviour
{
    public GameState gameState { get; private set; }

    public GameStatePairing[] states;

    private string gameOverReason = "None";

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Multiple GameManagers detected, deleting object. Please remove GameManager from scene", this);
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private string GetSceneFromState(GameState state)
    {
        foreach (GameStatePairing item in states)
        {
            if(item.sceneState == state)
            {
                return item.sceneName;
            }
        }
       return null;
    }

    public void SwitchScenes(GameState state)
    {
        if (state == GameState.Exit)
        {
            Application.Quit();
        }
        SceneManager.LoadScene(GetSceneFromState(state));
        Time.timeScale = 1;
    }

    public void GameOverFromWin(int amountDelivered, int maxPackages)
    {
        if (amountDelivered >= maxPackages)
        {
            gameOverReason = "win";
            SwitchScenes(GameState.Won);
        }
    }

    public void GameOverFromSupply(string resourceName, float amount)
    {
        if (resourceName == "supply" && amount <= 0f)
        {
            gameOverReason = "supply";
            SwitchScenes(GameState.Lost);
        }
    }

    public void GameOverFromTimer(int time)
    {
        if (time <= 0)
        {
            gameOverReason = "time";
            SwitchScenes(GameState.Lost);
        }
    }
}
