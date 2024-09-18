using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class OptionsMenu : MonoBehaviour
{
    public Toggle InvertYToggle; // Reference to the toggle in the UI

    // Define the event to notify subscribers
    public static event Action<bool> OnInvertYChanged;

    void Start()
    {
        // Load the saved preference when the options menu is opened
        InvertYToggle.isOn = PlayerPrefs.GetInt("InvertY", 0) == 1;

        // Subscribe the toggle's event to fire when the value changes
        InvertYToggle.onValueChanged.AddListener(delegate { ToggleInvertY(InvertYToggle.isOn); });
    }

    // Method called when the toggle value changes
    private void ToggleInvertY(bool isOn)
    {
        OnInvertYChanged?.Invoke(isOn); // Fire the event to notify listeners
    }

    // Apply the changes made in the Options menu
    public void Apply()
    {
        // Save the Invert Y-Axis preference
        PlayerPrefs.SetInt("InvertY", InvertYToggle.isOn ? 1 : 0);
        PlayerPrefs.Save(); // Ensure the preferences are saved

        // Return to the previous scene
        LoadPreviousScene();
    }

    // Go back to the previous scene without saving changes
    public void Back()
    {
        LoadPreviousScene();
    }

    private void LoadPreviousScene()
    {
        string previousScene = SceneManagerHelper.PreviousScene;
        SceneManager.LoadScene(previousScene);
    }
}
