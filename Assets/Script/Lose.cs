using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lose : MonoBehaviour {
    
	void Awake(){
		int gameStatusCount = FindObjectsOfType<Lose>().Length;
		if (gameStatusCount > 1) {
			Destroy (gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}
	
    public void Vencible()
    {
        gameObject.SetActive(true);

    }

    public void Invencible()
    {
        gameObject.SetActive(false);

    }
	

	public void ResetLose(){
		Destroy(gameObject);

    }

	
}
