using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public string url;

    public void OpenLink()
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
    }
}
