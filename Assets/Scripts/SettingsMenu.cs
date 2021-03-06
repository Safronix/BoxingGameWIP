using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

    public class SettingsMenu : MonoBehaviour
    {
        public GameObject MainMenuScreen, SettingsMenuScreen;
        public AudioMixer audioMixer;
        public Dropdown resolutionDropdown;
        public Slider volume;
        public Dropdown qualityDropdown;
        public Toggle FullscreenToggle;
        public int currentResolutionIndex = 0;
        public int fullscreencheck;
        Resolution[] resolutions;


        void Awake()
        {
            resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            List<string> options = new List<string>();

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
            LoadSettings();

            if (PlayerPrefs.GetInt("FullscreenPreference", fullscreencheck) == 1)
                FullscreenToggle.isOn = true;
            else
                FullscreenToggle.isOn = false;

        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
            Debug.Log("Set Res To Prefs");
        }

        public void SetVolume(float sliderVolume)
        {
            audioMixer.SetFloat("volume", Mathf.Log10(sliderVolume) * 20);
            PlayerPrefs.SetFloat("VolumePreference", sliderVolume);
            //Debug.Log("Set Vol To Prefs " + sliderVolume);
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
            PlayerPrefs.SetInt("QualityPreference", qualityIndex);
            //Debug.Log("Set Qual To Prefs " + qualityIndex);
        }

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
            //Should convert true and false to int values
            if (isFullscreen)
            {
                fullscreencheck = 1;
            }
            else
            {
                fullscreencheck = 0;
            }
            PlayerPrefs.SetInt("FullscreenPreference", fullscreencheck);
        }

        public void LoadSettings()
        {
            if (PlayerPrefs.HasKey("ResolutionPreference"))
                resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
            else
                resolutionDropdown.value = currentResolutionIndex;

            if (PlayerPrefs.HasKey("VolumePreference"))
                volume.value = PlayerPrefs.GetFloat("VolumePreference");
            else
                volume.value = 1.0f;

            if (PlayerPrefs.HasKey("QualityPreference"))
                qualityDropdown.value = PlayerPrefs.GetInt("QualityPreference");
            else
                qualityDropdown.value = 1;

            if (PlayerPrefs.HasKey("FullscreenPreference"))
                fullscreencheck = PlayerPrefs.GetInt("FullscreenPreference");
            else
                fullscreencheck = 0;
            PlayerPrefs.Save();
        }
        public void Back()
    {
        SettingsMenuScreen.SetActive(false);
        MainMenuScreen.SetActive(true);
    }



}
//In order to detail the slider for violence filtering, check the value of the slider and have a text box above that will change text
//based on the value; If value is one, filter nothing. If two, filter blood. If three, filter blood, broken bones and whatever else may be violent.