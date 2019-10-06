using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [Range(0.1f, 10f)]public float gameSpeed = 1f;
    [SerializeField] static int currentScore = 0;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Time.timeScale = gameSpeed;
    }

    public int GetScore()
    {
        return currentScore;
    }
    public void AddToScore(int pointsPerBlockDestroyed)

    {
        currentScore += pointsPerBlockDestroyed;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
        currentScore = 0;
    }
}
