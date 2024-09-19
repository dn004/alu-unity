using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;

    void Awake()
    {
        // Ensure only one instance of BGMManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StopBGM()
    {
        // Stops BGM when necessary
        if (TryGetComponent(out AudioSource audioSource))
        {
            audioSource.Stop();
        }
    }

    public void PlayBGM()
    {
        // Starts BGM if stopped
        if (TryGetComponent(out AudioSource audioSource))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
