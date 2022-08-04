using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Need to look up how a database contains this gamesession.
public class GameSession : MonoBehaviour
{
    [SerializeField] int playersLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
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

    void Start() 
    {
        livesText.text = playersLives.ToString();
        scoreText.text = score.ToString();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    void TakeLife()
    {
        playersLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playersLives.ToString();
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
