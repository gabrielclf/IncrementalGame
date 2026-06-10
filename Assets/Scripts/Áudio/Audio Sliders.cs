using UnityEngine;
using UnityEngine.UI;

public class AudioSliders : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

            //  sync current audio state to UI
            slider.SetValueWithoutNotify(GetVolumeFromStatic());
    }

    void OnEnable()
    {
            slider = GetComponent<Slider>();
            slider.SetValueWithoutNotify(GetVolumeFromStatic());
            slider.onValueChanged.AddListener(OnSliderChange);
    }

    private float GetVolumeFromStatic()
    {
        if (gameObject.name == "Music") 
        return AudioSettings.musicVolume;
        if (gameObject.name == "SFXs") 
        return AudioSettings.SFXVolume;
        if (gameObject.name == "Ambiences") 
        return AudioSettings.ambienceVolume;
        if (gameObject.name == "Voice Overs") 
        return AudioSettings.VOVolume;
        if (gameObject.name == "Master") 
        return AudioSettings.masterVolume;
        return 0.5f;
    }
    private void OnSliderChange(float value)
    {
        if (gameObject.name == "Music") 
        AudioSettings.Instance.SetMusicVolume(value);
        if (gameObject.name == "SFXs") 
        AudioSettings.Instance.SetSFXVolume(value);
        if (gameObject.name == "Ambiences") 
        AudioSettings.Instance.SetAmbienceVolume(value);
        if (gameObject.name == "Voice Overs") 
        AudioSettings.Instance.SetVOVolume(value);
        if (gameObject.name == "Master") 
        AudioSettings.Instance.SetMasterVolume(value);
    }
}
