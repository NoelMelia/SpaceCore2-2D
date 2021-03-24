using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        // Check for any other objects of the same type
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject); // Destroy the current object
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
    }
}
