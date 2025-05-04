using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SingleAudioManager : MonoBehaviour
{
    public static SingleAudioManager Instance;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioSettings[] audioSettings;

    private float[] _savedVolumes;
    private int _dataLength;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _dataLength = audioSettings.Length;
        _savedVolumes = new float[_dataLength];
    }

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.8f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.8f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.8f);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void OnEnable()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            _savedVolumes[i] = audioSettings[i].VolumeScaled;
        }
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void RevertChanges()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            audioSettings[i].UpdateVolume(_savedVolumes[i]);
        }
    }

    public void ApplyChange()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            audioSettings[i].SaveDataFile();
            _savedVolumes[i] = audioSettings[i].VolumeScaled;
        }
    }
}