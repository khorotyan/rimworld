using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

	public bool fullscreen;
	public int resolutionIndex;
	//public int textureQuality;
	public static float musicVolume = 1f;

	public Toggle fullScreenToggle;
	public Dropdown resolutionDropdown;
	//public Dropdown textureQualityDropdown;
	public Slider musicVolumeSLider;

	public Resolution[] resolutions;

	void Start() 
	{
		AudioListener.volume = musicVolumeSLider.value;
		musicVolumeSLider.value = musicVolume;
	}

	void Update()
	{
		musicVolume = musicVolumeSLider.value;
	}

	void OnEnable()
	{
		fullScreenToggle.onValueChanged.AddListener (delegate {
			OnFullscreenToggle ();
		});

		resolutionDropdown.onValueChanged.AddListener (delegate {
			OnResolutionChange ();
		});

		//textureQualityDropdown.onValueChanged.AddListener (delegate {
		//	OnTextureQualityChange ();
		//});

		musicVolumeSLider.onValueChanged.AddListener (delegate {
			OnMusicVolumeChange ();
		});

		resolutions = Screen.resolutions;
	}

	public void OnFullscreenToggle()
	{
		fullscreen = Screen.fullScreen = fullScreenToggle.isOn;
	}

	public void OnResolutionChange()
	{
		
	}

	/*
	public void OnTextureQualityChange()
	{
		QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
	}
	*/

	public void OnMusicVolumeChange()
	{
		AudioListener.volume = musicVolumeSLider.value;
	}

	public void SaveSettings()
	{

	}

	public void LoadSettings()
	{

	}

}
