using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNormal : MonoBehaviour
{
    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<DestroyNormal>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetDestroy()
    {
        Destroy(gameObject);
    }
}
