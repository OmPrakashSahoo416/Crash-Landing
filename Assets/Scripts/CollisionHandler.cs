using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip levelFinish;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem levelFinishParticles;

    AudioSource audioSource;

    bool isTrasitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTrasitioning)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                //do nothing...
                break;
            case "Finish":
                SuccessLevelSequence();
                break;
            default:
                FailureLevelSequence();
                break;
        }
    }
    void SuccessLevelSequence()
    {
        isTrasitioning = true;
        audioSource.PlayOneShot(levelFinish,1f);
        levelFinishParticles.Play();
        GetComponent<RocketController>().enabled = false;
        Invoke("LoadNextLevel", loadLevelDelay);
    }
    void FailureLevelSequence()
    {
        isTrasitioning = true;
        audioSource.PlayOneShot(crash,0.25f);
        crashParticles.Play();
        GetComponent<RocketController>().enabled = false;
        Invoke("ReloadLevel", loadLevelDelay);
    } 
    void LoadNextLevel()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneBuildIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneBuildIndex);
    }
}
