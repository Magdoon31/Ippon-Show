using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioMixer audioMixer;
    private void Start()
    {
        LoadVolume();
        MusicManager.Instance.PlayMusic("Menu");
       
    }
    private void Update()
    {
        UpdateMusicVolume(musicSlider.value);
        UpdateSFXVolume(sfxSlider.value);
    }
    public void Play()
    {
        Debug.Log(LevelManager.Instance);
        LevelManager.Instance.LoadScene("Game", "CrossFade");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void UpdateSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}
