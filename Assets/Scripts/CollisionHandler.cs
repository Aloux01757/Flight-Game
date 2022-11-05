using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]float levelLoadDelay = 2f;
    [SerializeField]AudioClip crash;
    [SerializeField]AudioClip sucess;

    [SerializeField]ParticleSystem crashParticles; //it doesn't need cache
    [SerializeField]ParticleSystem sucessParticles; //it doesn't need cache

    AudioSource audioSource;


    bool isTransitioning = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>(); // remember always cache reference
    }
    void OnCollisionEnter(Collision other) // call when touched another rigidbody/collider
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

        if(isTransitioning == false)
        {
            crashParticles.Play(); 
            audioSource.Stop(); 
            audioSource.PlayOneShot(crash);
            isTransitioning = true; // in order to stop repeat or another function
        }

        GetComponent<Movement>().enabled = false; // Disable script Moviment
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartSucessSequence()
    {

       if(isTransitioning == false)
       {
            sucessParticles.Play(); 
            audioSource.Stop();
            audioSource.PlayOneShot(sucess);
            isTransitioning =true; // in order to stop repeat or another function
       }

        


       GetComponent<Movement>().enabled = false; // Disable script Moviment
       Invoke("LoadNextLevel", levelLoadDelay);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Check current Scene
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) // Check many scenes
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
