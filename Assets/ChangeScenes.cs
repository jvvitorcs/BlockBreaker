using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1f;
    }
    public void LoadLevels(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
        //FindObjectOfType<DestroyNormal>().ResetDestroy();
        //FindObjectOfType<Lose>().ResetLose();        
    }   

    public void QuitRequest()
    {
        Application.Quit();
    }
}
