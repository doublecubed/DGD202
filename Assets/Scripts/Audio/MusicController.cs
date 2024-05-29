using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    #region REFERENCES

    [Header("UI Elements")] 
    public Image uiButton;
    public Sprite mutedMusic;
    public Sprite playingMusic;
    public Slider musicSlider;
    
    [Header("Audio Source")]
    public AudioSource audioSource;

    #endregion
    
    #region VARIABLES
    
    #endregion
    
    #region MONOBEHAVIOUR
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        float savedVolumeValue = PlayerPrefs.GetFloat("volumeFloat", 1f);
        musicSlider.value = savedVolumeValue;
        
        SetAudioVolume(savedVolumeValue);
    }
    
    #endregion
    
    #region METHODS
    
    public void SetAudioVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat("volumeFloat", value);

        uiButton.sprite = (value <= 0f) ? mutedMusic : playingMusic;
    }

    public void SetAudioVolumeDummy(int value, string what)
    {
        
    }
    
    #region Obsolete
    
    public void SwitchAudioVolume()
    {
        int currentVolumeValue = PlayerPrefs.GetInt("volume", 1);
        int newVolumeValue = currentVolumeValue == 1 ? 0 : 1;
        
        SetAudioVolume(newVolumeValue);
        
        PlayerPrefs.SetInt("volume", newVolumeValue);
    }
    
    private void SetAudioVolume(int value)
    {
        bool playIt = value != 0;
        
        audioSource.volume = playIt ? 1f : 0f;
        uiButton.sprite = playIt ? playingMusic : mutedMusic;
    }
    
    #endregion
    
    #endregion
}

