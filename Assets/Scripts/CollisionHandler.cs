using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Accessibility;
using System;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] public float loadLevelDelay = 1.0f;
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                StartSucessSequence();
                break;
            case "Finish":
                Invoke("LoadNextLevel",loadLevelDelay);
                break;
            case "Fuel":
                Debug.Log("You have picked up fuel!");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSucessSequence()
    {
        throw new NotImplementedException();
    }

    void StartCrashSequence()
    {
        StopPlayerMovement();
        Invoke("ReloadLevel", loadLevelDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        StopPlayerMovement();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int loadNextLevel = currentSceneIndex + 1;
        if (loadNextLevel == SceneManager.sceneCountInBuildSettings)
        {
           loadNextLevel = 0;
        }
        SceneManager.LoadScene(loadNextLevel);

    }

    void StopPlayerMovement()
    {
        GetComponent<Movement>().enabled = false;
    }
}
