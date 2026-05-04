using UnityEngine;
using FMODUnity;
using FMOD.Studio;

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
    [SerializeField] EventReference SulAreaClickSound;
    [SerializeField] EventReference NordesteAreaClickSound;
    [SerializeField] EventReference SudesteAreaClickSound;
    [SerializeField] EventReference OesteAreaClickSound;
    [SerializeField] EventReference ScreenSlideSound;

    

    void Start()
    {
        
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

    public void PlaySulAreaClickSound()
    {
        RuntimeManager.PlayOneShot(SulAreaClickSound);
    }

    public void PlayNordesteAreaClickSound()
    {
        RuntimeManager.PlayOneShot(NordesteAreaClickSound);
    }

    public void PlaySudesteAreaClickSound()
    {
        RuntimeManager.PlayOneShot(SudesteAreaClickSound);
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
