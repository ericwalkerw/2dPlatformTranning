using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : Singleton<GameManeger>
{
    public PlayerController player;
    public int enemyCount= 0;

    public GameObject btn_start;
    public GameObject btn_replay;
    private void Start()
    {
        PauseGame();
    }

    public void PassLv1(GameObject wall)
    {
        if (enemyCount == 2)
        {
            Destroy(wall);
        }
    }
    public void IsVictory(GameObject winPanel)
    {
        if (enemyCount == 0)
        {
            PauseGame();
            btn_start.SetActive(false);
            btn_replay.SetActive(true);
            winPanel.SetActive(true);
        }
    }

    public void Lose()
    {
        btn_start.SetActive(false);
        btn_replay.SetActive(true);
    }

    public void PauseGame() => Time.timeScale = 0;
    public void ResumeGame() => Time.timeScale = 1;

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
