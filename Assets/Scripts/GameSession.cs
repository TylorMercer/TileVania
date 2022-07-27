using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playersLives = 3;
    void Awake()
    {
        int numGameSeesions = FindObjectsOfType<GameSession>().Length;
        if(numGameSeesions > 1)
        {
            Destroy(gameObject);
        }else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ProcessPlayerDeath()
    {
        if(playersLives > 1)
        {
            TakeLife();
        } 
        else
        {
            ResetGameSession();
        }
    }

    void TakeLife()
    {
        playersLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
