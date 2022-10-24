using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]float levelLoadDelay = 2f;
    [SerializeField]AudioClip crash;
    [SerializeField]AudioClip sucess;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>(); // remember always cache reference
    }
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
        if(isTransitioning == false)
        {
            audioSource.Stop(); // remove thrust noise after crash or sucess
            audioSource.PlayOneShot(crash);
            isTransitioning = true;
        }

        GetComponent<Movement>().enabled = false; //It's doesn't need create reference cache.
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartSucessSequence()
    {
       //todo add SFX upon crash
       //todo add particle effect upon sucess
       if(isTransitioning == false)
       {
            audioSource.Stop(); // remove thrust noise after crash or sucess
            audioSource.PlayOneShot(sucess);
            isTransitioning =true   ;
       }

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
