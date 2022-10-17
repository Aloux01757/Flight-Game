using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]float levelLoadDelay = 2f;
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag) // variable here
        {
            case "Friendly":
            Debug.Log("this thing is friendly");
            break;
            case "Finish":
                StartSucessSequence();
                break;
            default:
            StartCrashSequence();
            break;
        }
    }

    void StartCrashSequence()
    {
        //todo add SFX upon crash
        //todo add particle effect upon crash
        GetComponent<Movement>().enabled = false; //It's doesn't need create reference cache.
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartSucessSequence()
    {
       //todo add SFX upon crash
       //todo add particle effect upon crash
       GetComponent<Movement>().enabled = false; //It's doesn't need create reference cache.
       Invoke("LoadNextLevel", levelLoadDelay);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex); 
    }

    void ReloadLevel() // apply clean code
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Create a variable with clean code applied
        SceneManager.LoadScene(currentSceneIndex); // current scene load
    }
}
