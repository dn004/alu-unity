using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject  PauseCanvas; // Reference to the PauseCanvas
    private bool isPaused = false; // Track whether the game is pause

    public Button ResumeButton; 
    public Button OptionsButton; 
    public Button MenuButton;
    public Button RestartButton;

    void Start()
    {
        ResumeButton.onClick.AddListener(() => Resume());
        OptionsButton.onClick.AddListener(() => OptionsPressed());
        MenuButton.onClick.AddListener(() => MenuPressed());
        RestartButton.onClick.AddListener(() => RestartPressed());
    }
    void Update()
    {
        // Check if the player presses the Esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); // Unpause the game if it's already paused
            }
            else
            {
                Pause(); // Pause the game if it's not paused
            }
        }
    }

    public void Pause()
    {
        PauseCanvas.SetActive(true); // Activate the PauseCanvas
        Time.timeScale = 0f; // Pause the game timer
        isPaused = true; // Update the pause state
    }

    public void Resume()
    {
        PauseCanvas.SetActive(false); // Deactivate the PauseCanvas
        Time.timeScale = 1f; // Resume the game timer
        isPaused = false; // Update the pause state
    }

    public void OptionsPressed()
    {
        SceneManagerHelper.SetPreviousScene();
        SceneManager.LoadScene("Options");
    }

    public void MenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }
}

