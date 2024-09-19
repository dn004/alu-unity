using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public Button MenuButton;
    public Button NextButton;

    void Start()
    {
        MenuButton.onClick.AddListener(MainMenu);
        NextButton.onClick.AddListener(Next);
    }

    // Takes the player to the Main Menu
    public void MainMenu()
    {
        Time.timeScale = 1f;  // In case the game is paused
        SceneManager.LoadScene("MainMenu");  // Load Main Menu scene (or use scene index for Main Menu)
    }

    // Loads the next level, or the Main Menu if on the last level
    public void Next()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Handle levels 0 (Level 1), 1 (Level 2), 2 (Level 3)
        if (currentSceneIndex > 1 && currentSceneIndex < 4)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);  // Load the next level
        }
        else
        {
            MainMenu();  // If on the last level (index 2), go to Main Menu
        }
    }
}
