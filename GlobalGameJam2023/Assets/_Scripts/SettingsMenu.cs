using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System.Linq;


/// <summary>
/// Author/Editors: Adrian Barrett
/// 
/// Description: This script handles the settings/option menu in the main menu scene. Resolution (at 60hz), quality, fullscreen. 
/// 
/// No sound currently so its not needed.
/// </summary>
public class SettingsMenu : MonoBehaviour 
{
    //Class Variables
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle fullScreenToggle;
    Resolution[] resolutions;
    //Unity Methods
    private void Start()
    {
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray(); //Remove all resolution settings not at 60hz
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        StringBuilder builder = new StringBuilder();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            builder.Length = 0;
            builder.Append(resolutions[i].width);
            builder.Append(" x ");
            builder.Append(resolutions[i].height);
            string option = builder.ToString();
            options.Add(option);

            if (resolutions[i].width  == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }
    //Custom Public Methods 
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log(volume)*20);
    }
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality (int qualityIndex)
    {
		QualitySettings.SetQualityLevel(qualityIndex);
    }
	public void SetFullscreen (bool isFullscreen)
    {
		Screen.fullScreen = isFullscreen;
    }
    public void SaveSettings()
    {
        float volume;   
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(Screen.fullScreen));
        bool result = audioMixer.GetFloat("volume", out volume);
        if (result)
        {
            PlayerPrefs.SetFloat("VolumePreference", volume);
        }
    }
    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference")) qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else qualityDropdown.value = 3;
        if (PlayerPrefs.HasKey("ResolutionPreference")) resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else resolutionDropdown.value = currentResolutionIndex;
        if (PlayerPrefs.HasKey("FullscreenPreference")) Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else Screen.fullScreen = true;
        if (PlayerPrefs.HasKey("VolumePreference")) audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("VolumePreference"));
        else audioMixer.SetFloat("volume", -40f);
    }
    //Custom Private Methods 

}
// Reference
// https://www.youtube.com/watch?v=YOaYQrN1oYQ
// https://www.red-gate.com/simple-talk/development/dotnet-development/how-to-create-a-settings-menu-in-unity/