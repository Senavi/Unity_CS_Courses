using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    public void OnCollisionEnter(Collision other)
{
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
        GetComponent<Movement>().enabled = false;
        Invoke ("ReloadLevel", delay);
    }

    void StartLoadingNextLevel()
    {
        //SFX upon success
        //particle effect upon success
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
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
