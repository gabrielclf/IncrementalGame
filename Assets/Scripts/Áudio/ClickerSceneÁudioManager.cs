using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickerSceneÁudioManager : MonoBehaviour
{   
    // Referencia ao ClickerManager para acessar checkar a ativação método de 
    [Header("Code References")]
    [SerializeField] ClickerManager clickerManager;
    
    // Referências de Loops a serem tocados
    [Header("OSTs e Ambiences")]
    [SerializeField] EventReference GameplayOST;
    [SerializeField] EventReference MapAmbience;

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
           if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "RegiaoNorte" && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "RegiaoSudesteSul" && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "RegiaoNordeste" && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "RegiaoCentroOeste" && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Vitoria")
            {
                Destroy(gameObject);
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
            SceneCheck();
        }
    
    void Start()
    {
        clickerManager = FindAnyObjectByType<ClickerManager>();
    }

    #region OST Activation

    #endregion

    #region Ambience Activation / Change

    #endregion

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
