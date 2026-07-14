using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickerSceneÁudioManager : MonoBehaviour
{   
    #region Variables
    [Header("Variables")]
    [SerializeField] private float ScreenCenterDistance = 1f;

    // referências de managers
    [Header("Code References")]
    [SerializeField] ClickerManager clickerManager;
    [SerializeField] string Scene;
    [SerializeField] private GameObject ScreenCenter;
    private bool Clicked = false;
    
    // Referências de Loops a serem tocados
    [Header("OSTs e Ambiences")]
    [SerializeField] EventReference GameplayOST;
    EventInstance GameplayOSTInstance;
    [SerializeField] EventReference MapAmbience;
    EventInstance MapAmbienceInstance;

    //Referencia de Snapshots
    [SerializeField] EventReference GameplaySnapshot;
    [SerializeField] EventInstance GameplaySnapshotInstance;

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
           if(SceneManager.GetActiveScene().name != "RegiaoNorte" && SceneManager.GetActiveScene().name != "RegiaoSudesteSul" && SceneManager.GetActiveScene().name != "RegiaoNordeste" && SceneManager.GetActiveScene().name != "RegiaoCentroOeste" )
            {
                StopAmbience();
                StopOSTs();
                Destroy(gameObject);
            }
            else
            {
            clickerManager = FindAnyObjectByType<ClickerManager>();
            GameObject mainCamera = GameObject.FindWithTag("MainCamera");
            if (mainCamera != null)
                {
                    RuntimeManager.AttachInstanceToGameObject(MapAmbienceInstance, mainCamera);
                }
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
            changeAreaParameter();
            
        }
        #endregion
    
    void Start()
    {   
        #region OST e AMB Activation
        clickerManager = FindAnyObjectByType<ClickerManager>();
        GameplayOSTInstance = RuntimeManager.CreateInstance(GameplayOST);
        MapAmbienceInstance = RuntimeManager.CreateInstance(MapAmbience);
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        if (mainCamera != null)
        {
            RuntimeManager.AttachInstanceToGameObject(MapAmbienceInstance, mainCamera);
        }
        GameplayOSTInstance.start();
        MapAmbienceInstance.start();
        GameplaySnapshotInstance = RuntimeManager.CreateInstance(GameplaySnapshot);
        GameplaySnapshotInstance.start();
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

    private int GetDirection()
    {
        if (ScreenCenter == null)
        {
            return 1; 
        }
        if (transform.position.x < (ScreenCenter.transform.position.x - ScreenCenterDistance))
        {
            return 0; 
        }
        else if (transform.position.x > (ScreenCenter.transform.position.x + ScreenCenterDistance))
        {
            return 1; 
        }
        else
        {
            return 0; 
        }
    }
    private void setparameter(int direction)
    {
        //HoverInstance.setParameterByName("Menu Direction", direction);
    }
    #endregion

    #region Area Click Sounds
    public void PlayNorteAreaClickSound()
    {
        switch (getScene())
        {
            case 0:
                if (Clicked == true)
                {
                    return;
                }
                RuntimeManager.PlayOneShot(NorteAreaClickSound);
                Clicked = true;
                StartCoroutine(clickSoundDelay());
            break;

            case 1:
                if (Clicked == true)
                {
                    return;
                }
                RuntimeManager.PlayOneShot(NordesteAreaClickSound);
                Clicked = true;
                StartCoroutine(clickSoundDelay());
            break;

            case 2:
                if (Clicked == true)
                {
                    return;
                }
                RuntimeManager.PlayOneShot(OesteAreaClickSound);
                Clicked = true;
                StartCoroutine(clickSoundDelay());
            break;

            case 3:
                if (Clicked == true)
                {
                    return;
                }
                RuntimeManager.PlayOneShot(SulSudesteAreaClickSound);
                Clicked = true;
                StartCoroutine(clickSoundDelay());
            break;

            default:
                if (Clicked == true)
                {
                    return;
                }
                RuntimeManager.PlayOneShot(NorteAreaClickSound);
                Clicked = true;
                StartCoroutine(clickSoundDelay());
            break;
        }
    }
    IEnumerator clickSoundDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Clicked = false;
    }

    
    #endregion

    float getScene()
    {
        Scene = SceneManager.GetActiveScene().name;
        if (Scene == "RegiaoNorte")
        {   

            return 0;
        }
        if (Scene == "RegiaoNordeste")
        {
            return 1;
        }
        if (Scene == "RegiaoCentroOeste")
            {
            return 2;
            }
        if (Scene == "RegiaoSudesteSul")
                {
            return 3;
                }
        if (Scene == "Vitoria")
        {
            return 0;
        }
        return 0;
        
    }
    void changeAreaParameter()
    {
        RuntimeManager.StudioSystem.setParameterByName("Player Area", getScene());
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
