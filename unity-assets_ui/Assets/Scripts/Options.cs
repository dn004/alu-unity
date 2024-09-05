using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void OnBackButtonPressed()
    {
        Time.timeScale = 1f;
        LoadPreviousScene();
    }

    private void LoadPreviousScene()
    {
        string previousScene = SceneManagerHelper.PreviousScene;
        SceneManager.LoadScene(previousScene);
    }
}
