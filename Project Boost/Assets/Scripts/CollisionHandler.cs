using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    [SerializeField] AudioClip SuccessSound;
    [SerializeField] AudioClip CrashSound;

    [SerializeField] ParticleSystem Success;
    [SerializeField] ParticleSystem Crash;

    AudioSource audioSource;
    bool isTransitioning = false;
    bool CollisionDisable = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheatKeys();
    }

    void CheatKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            CollisionDisable = !CollisionDisable;
        }
    }

    public void OnCollisionEnter(Collision other)

{
        if (isTransitioning || CollisionDisable) { return; }
        switch (other.gameObject.tag)
{
            case "Friendly":
                Debug.Log("This thing is a friednly one!");
                break;
            case "Finish":
                StartLoadingNextLevel();
                break;
            case "Fuel":
                Debug.Log("You picked up fuel!");
                break;
            default:
                StartCrashSequence();
                break;
        }
}

    void StartCrashSequence()
    {
        //SFX upon crash
        //particle effect upon crash
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        Invoke ("ReloadLevel", delay);
        audioSource.PlayOneShot(CrashSound);
        Crash.Play();

    }

    void StartLoadingNextLevel()
    {
        //SFX upon success
        //particle effect upon success
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay);
        audioSource.PlayOneShot(SuccessSound);
        Success.Play();
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
