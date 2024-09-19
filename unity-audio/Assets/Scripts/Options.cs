using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle InvertYToggle;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public AudioMixer audioMixer;  // Reference to the AudioMixer for SFX

    public static event System.Action<bool> OnInvertYChanged;

    void Start()
    {
        InvertYToggle.isOn = PlayerPrefs.GetInt("InvertY", 0) == 1;
        InvertYToggle.onValueChanged.AddListener(delegate { ToggleInvertY(InvertYToggle.isOn); });

        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        BGMSlider.onValueChanged.AddListener(SetBGMVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }


    private void ToggleInvertY(bool isOn)
    {
        OnInvertYChanged?.Invoke(isOn);
    }

    public void Apply()
    {
        PlayerPrefs.SetInt("InvertY", InvertYToggle.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefs.Save();

        LoadPreviousScene();
    }


    public void Back()
    {
        LoadPreviousScene();
    }

    private void LoadPreviousScene()
    {
        string previousScene = SceneManagerHelper.PreviousScene;
        SceneManager.LoadScene(previousScene);
    }

    private void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);  // Convert to dB
    }

    private void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);  // Convert to dB
    }
}
