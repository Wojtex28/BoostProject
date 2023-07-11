using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDebug : MonoBehaviour
{

    [SerializeField] Collider rocket;

    void Start()
    {
        rocket = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        NextScene();
        DisableCollisions();
    }

    void NextScene()
    {

        if (Input.GetKey(KeyCode.L))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int loadNextLevel = currentSceneIndex + 1;
            if (loadNextLevel == SceneManager.sceneCountInBuildSettings)
            {
                loadNextLevel = 0;
            }
            SceneManager.LoadScene(loadNextLevel);
        }
        
    }

    void DisableCollisions()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            rocket.enabled = !rocket.enabled;
        }
    }
}
        
