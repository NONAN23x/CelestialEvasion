using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public AudioClip success;
    public AudioClip crash;
    public ParticleSystem successParticles;
    public ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    void OnCollisionEnter(Collision other) 
        {
            if (isTransitioning){return;} 
            switch (other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Start the game");
                    break;
                case "Finish":
                    Debug.Log("Game Over");
                    StartSuccessScene();
                    break;
                default:
                    StartCrashSequence();
                    Debug.Log("You crashed!");
                    break;
            }
        }  

    void StartSuccessScene()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 1f);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 2.5f);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentSceneIndex + 1;
        SceneManager.LoadScene(nextLevel);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}