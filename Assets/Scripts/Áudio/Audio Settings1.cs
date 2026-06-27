using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioSettings : MonoBehaviour
{
    [Header("Audio Buses")]
    private Bus Music;
    private Bus SFX;
    private Bus Ambience;
    private Bus VO;
    private Bus Master;

    [Header("Volume Levels")]

    public static float musicVolume { get; private set; } = 0.5f;
    public static float SFXVolume { get; private set; } = 0.5f;
    public static float ambienceVolume { get; private set; } = 0.5f;
    public static float VOVolume { get; private set; } = 0.5f;
    public static float masterVolume { get; private set; } = 0.5f;

    public static AudioSettings Instance { get; private set; }
        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
            private void OnEnable()
        {
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnDisable()
        {
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
        {   
            // Reassign Fmod buses when a new scene is loaded 
            Music = RuntimeManager.GetBus("bus:/Master/Music");
            SFX = RuntimeManager.GetBus("bus:/Master/SFXs");
            Ambience = RuntimeManager.GetBus("bus:/Master/Ambience");
            VO = RuntimeManager.GetBus("bus:/Master/VOs");
            Master = RuntimeManager.GetBus("bus:/Master");
        }
        
        

    void Start()
    {   
        // Assign Fmod buses at the start of the game
        Music = RuntimeManager.GetBus("bus:/Master/Music");
        SFX = RuntimeManager.GetBus("bus:/Master/SFXs");
        Ambience = RuntimeManager.GetBus("bus:/Master/Ambience");
        VO = RuntimeManager.GetBus("bus:/Master/VOs");
        Master = RuntimeManager.GetBus("bus:/Master");
    }


    // Update is called once per frame
    void Update()
    {   
        // continuously set the volume of each bus to the current volume levels
        Music.setVolume(musicVolume);
        SFX.setVolume(SFXVolume);
        Ambience.setVolume(ambienceVolume);
        VO.setVolume(VOVolume);
        Master.setVolume(masterVolume);
    }

    // set the volume levels to slider values 
    public void SetMusicVolume(float newMusicVolume)
    {
        musicVolume = newMusicVolume;

    }

    // set the volume levels to slider values 
    public void SetSFXVolume(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;

    }

    // set the volume levels to slider values 
    public void SetAmbienceVolume(float newAmbienceVolume)
    {
        ambienceVolume = newAmbienceVolume;
    }

    // set the volume levels to slider values 
    public void SetVOVolume(float newVOVolume)
    {
        VOVolume = newVOVolume;
    }

    // set the volume levels to slider values 
    public void SetMasterVolume(float newMasterVolume)
    {
        masterVolume = newMasterVolume;
    }

}
