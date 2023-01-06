using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    int currentResolutionIndex;
    int oldResolutionIndex;
    public TextMeshProUGUI resolutionText;
    public Toggle fullscreenDropdown;
    public GameObject OptionsMenuUI;
    public bool InGame = true;
    public Slider MusicSlider;
    public Slider SFXSlider;
    public Slider AmbianceSlider;
    public Slider MasterSlider;
    public bool MainMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].height == Screen.currentResolution.height && resolutions[i].width == Screen.currentResolution.width)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        if (Screen.fullScreen)
        {
            fullscreenDropdown.isOn = true;
        }
        else
        {
            fullscreenDropdown.isOn = false;
        }

        float Volume = 0;
        if (MainMenu)
        {
            audioMixer.GetFloat("Master", out Volume);
            GameManager.Instance_.MasterSlider = Volume;

        }
        else
        {
            masterVolume(GameManager.Instance_.MasterSlider);
            Volume = GameManager.Instance_.MasterSlider;
        }

        MasterSlider.value = Volume;

        if (MainMenu)
        {
            audioMixer.GetFloat("SFX", out Volume);
            GameManager.Instance_.SFXSlider = Volume;
        }
        else
        {
            SFXVolume(GameManager.Instance_.SFXSlider);
            Volume = GameManager.Instance_.SFXSlider;
        }

        SFXSlider.value = Volume;

        if (MainMenu)
        {
            audioMixer.GetFloat("Music", out Volume);
            GameManager.Instance_.MusicSlider = Volume;
        }
        else
        {
            musicVolume(GameManager.Instance_.MusicSlider);
            Volume = GameManager.Instance_.MusicSlider;
        }

        MusicSlider.value = Volume;

        if (!MainMenu)
        {
            audioMixer.GetFloat("Ambiance", out Volume);
            GameManager.Instance_.AmbianceSlider = Volume;
        }
        else
        {
            AmbianceVolume(GameManager.Instance_.AmbianceSlider);
            Volume = GameManager.Instance_.AmbianceSlider;
        }

        AmbianceSlider.value = Volume;
    }

    private void Update()
    {
        if (InGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                toggleOption();
            }
        }
    }

    public void toggleOption()
    {
        if(OptionsMenuUI.activeInHierarchy)
        {
            Time.timeScale = 1;
            OptionsMenuUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            OptionsMenuUI.SetActive(true);
        }
    }

    public void masterVolume(float volume)
    {
        audioMixer.SetFloat("Master", volume);
        GameManager.Instance_.MasterSlider = volume;
    }

    public void SFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", volume);
        GameManager.Instance_.SFXSlider = volume;
    }

    public void musicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
        GameManager.Instance_.MusicSlider = volume;
    }

    public void AmbianceVolume(float volume)
    {
        audioMixer.SetFloat("Ambiance", volume);
        GameManager.Instance_.AmbianceSlider = volume;
    }

    public void resolution(int index)
    {
        print("Change Resolution " + index);
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        oldResolutionIndex = currentResolutionIndex;
        currentResolutionIndex = index;

        resolutionDropdown.value = index;
        resolutionDropdown.RefreshShownValue();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void fullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
