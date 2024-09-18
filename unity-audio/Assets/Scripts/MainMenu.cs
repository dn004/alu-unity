using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button Level01;
    public Button Level02;
    public Button Level03;
    public Button Options;
    public Button Exit;

    void Start()
    {
        Level01.onClick.AddListener(() => LevelSelect(1));
        Level02.onClick.AddListener(() => LevelSelect(2));
        Level03.onClick.AddListener(() => LevelSelect(3));
        Options.onClick.AddListener(() => LevelSelect(4));
        Exit.onClick.AddListener(() => LevelSelect(5));
    }

    public void LevelSelect(int level)
    {
        Time.timeScale = 1f;

        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Level01");
                break;
            case 2:
                SceneManager.LoadScene("Level02");
                break;
            case 3:
                SceneManager.LoadScene("Level03");
                break;
            case 4:
                SceneManagerHelper.SetPreviousScene();
                SceneManager.LoadScene("Options");
                break;
            case 5:
                Application.Quit();
                Debug.Log("Application Exit");
                break;
        }
    }
}
