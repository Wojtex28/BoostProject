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
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip failExplosion;

    public bool isTransitioning = false;
    


    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You have touched friendly!");
                break;
            case "Finish":
                StartSucessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSucessSequence()
    {
        isTransitioning = true;
        StopPlayerMovement();
        Invoke("LoadNextLevel", loadLevelDelay);
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        
      
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        StopPlayerMovement();
        Invoke("ReloadLevel", loadLevelDelay);
        audioSource.Stop();
        audioSource.PlayOneShot(failExplosion);
        
        

    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
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
