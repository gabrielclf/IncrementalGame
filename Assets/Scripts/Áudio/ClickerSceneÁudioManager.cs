using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickerSceneÁudioManager : MonoBehaviour
{   
    #region Variables
    // referências de managers
    [Header("Code References")]
    [SerializeField] ClickerManager clickerManager;
    
    // Referências de Loops a serem tocados
    [Header("OSTs e Ambiences")]
    [SerializeField] EventReference GameplayOST;
    EventInstance GameplayOSTInstance;
    [SerializeField] EventReference MapAmbience;
    EventInstance MapAmbienceInstance;

    // Referencia de Sons a serem tocados;
    [Header("SFXs")]
    [SerializeField] EventReference ButtonClickSound;
    [SerializeField] EventReference ButtonHover;
    [SerializeField] EventReference ConfirmSound;
    [SerializeField] EventReference DeclineSound;
    [SerializeField] EventReference AreaUnlockSound;
    [SerializeField] EventReference NorteAreaClickSound;
    [SerializeField] EventReference SulSudesteAreaClickSound;
    [SerializeField] EventReference NordesteAreaClickSound;
    [SerializeField] EventReference OesteAreaClickSound;
    [SerializeField] EventReference ScreenSlideSound;

    #endregion

    #region Scene Permanence 
    public static ClickerSceneÁudioManager Instance { get; private set; }
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
        private void SceneCheck()
        {
           if(SceneManager.GetActiveScene().name != "RegiaoNorte" && SceneManager.GetActiveScene().name != "RegiaoSudesteSul" && SceneManager.GetActiveScene().name != "RegiaoNordeste" && SceneManager.GetActiveScene().name != "RegiaoCentroOeste" && SceneManager.GetActiveScene().name != "Vitoria")
            {
                StopAmbience();
                StopOSTs();
                Destroy(gameObject);
            }
            else
            {
             clickerManager = FindAnyObjectByType<ClickerManager>();
            }
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneCheck();
            
        }
        #endregion
    
    void Start()
    {   
        #region OST e AMB Activation
        clickerManager = FindAnyObjectByType<ClickerManager>();
        GameplayOSTInstance = RuntimeManager.CreateInstance(GameplayOST);
        MapAmbienceInstance = RuntimeManager.CreateInstance(MapAmbience);
        GameplayOSTInstance.start();
        MapAmbienceInstance.start();
         #endregion
    }
    void StopOSTs()
    {
        GameplayOSTInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        GameplayOSTInstance.release();
       
    }
    void StopAmbience()
    {
        MapAmbienceInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        MapAmbienceInstance.release();
    }


    #region UI Actions
    public void PlayButtonClickSound()
    {
        RuntimeManager.PlayOneShot(ButtonClickSound);
    }

    public void PlayButtonHoverSound()
    {
        RuntimeManager.PlayOneShot(ButtonHover);
    }
    #endregion

    #region Area Click Sounds
    public void PlayNorteAreaClickSound()
    {
        RuntimeManager.PlayOneShot(NorteAreaClickSound);
    }

    public void PlaySulSudesteAreaClickSound()
    {
        RuntimeManager.PlayOneShot(SulSudesteAreaClickSound);
    }

    public void PlayNordesteAreaClickSound()
    {
        RuntimeManager.PlayOneShot(NordesteAreaClickSound);
    }

    public void PlayOesteAreaClickSound()
    {
        RuntimeManager.PlayOneShot(OesteAreaClickSound);
    }
    #endregion


    // Update is called once per frame
    void Update()
    {
        
    }
}
