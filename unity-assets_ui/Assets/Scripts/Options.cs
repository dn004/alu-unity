using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void OnBackButtonPressed()
    {
        LoadPreviousScene();
    }

    private void LoadPreviousScene()
    {
        string previousScene = SceneManagerHelper.PreviousScene;
        SceneManager.LoadScene(previousScene);
    }
}
