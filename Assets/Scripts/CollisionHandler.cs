using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag) // variable here
        {
            case "Friendly":
            Debug.Log("this thing is friendly");
            break;
            case "Finish":
                LoadNextLevel();
                break;
            case "Fuel":
            Debug.Log("You gain points!");
            break;
            default:
            ReloadLevel();
            break;
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex + 1); // load next scene, however, it has bug
    }

    void ReloadLevel() // apply clean code
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Create a variable with clean code applied
        SceneManager.LoadScene(currentSceneIndex); // current scene load
    }
}
