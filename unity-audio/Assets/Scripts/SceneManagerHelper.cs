using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManagerHelper
{
    public static string PreviousScene { get; set; }

    public static void SetPreviousScene()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
    }
}