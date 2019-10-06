using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    [SerializeField] int breakableBlocks;  // Serialized for debugging purposes
    [SerializeField] int ballsInField = 1;
    private Lose lose;
    private Ball ball;
    [SerializeField] int life = 0;
    int maxlife = 3;
    [SerializeField] Text lifeText;

    void Awake()
    {
        life = maxlife;
        lifeText.text = life.ToString();
        lifeText.text = "Vida: " + life.ToString();
        int gameStatusCount = FindObjectsOfType<LevelManager>().Length;
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
        ball = FindObjectOfType<Ball>();
        lose = FindObjectOfType<Lose>();

    }


    void Update()
    {
       // CountingBalls();
        if (life >= maxlife)
        {
            life = maxlife;
        }
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void TakeLife()
    {
        life--;
        lifeText.text = "Vida: " + life.ToString();
        if (life <= 0)
        {
            SceneManager.LoadScene("Lose");
            // FindObjectOfType<GameSession>().ResetGame();  
        }
    }

    public void AddToLife()
    {
        life++;
        lifeText.text = "Vida: " + life.ToString();

    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            FindObjectOfType<ChangeScenes>().LoadNextScene();
        }
    }

    public void CountBalls()
    {
        ballsInField += 2;
        if (ballsInField > 1)
        {
            lose.Invencible();
        }
    }

    public void BallDestroyed()
    {
        ballsInField--;

    }
}/*
    private void CountingBalls()
    {
        if (ballsInField == 1)
        {
            lose.Vencible();
        }
    }

}*/
