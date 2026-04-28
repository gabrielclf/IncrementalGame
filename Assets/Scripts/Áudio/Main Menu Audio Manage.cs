using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MainMenuAudioManage : MonoBehaviour
{
    [Header("Audio References")]
    [SerializeField] EventReference MainMenuMusic;
    [SerializeField] EventReference ButtonClickSound;
    [SerializeField] EventReference ButtonHoverSound;


    void Start()
    {
        PlayMainMenuMusic();
    }


    #region Music Activation
    // Método para tocar a música do menu principal
    public void PlayMainMenuMusic()
    {
        RuntimeManager.PlayOneShot(MainMenuMusic);
    } 
    #endregion

    #region UI Actions
    // Método para tocar o som de clique dos botões(chamado pelos botões do menu)
    public void PlayButtonClickSound()
    {
        RuntimeManager.PlayOneShot(ButtonClickSound);
    }
    
    // Método para tocar o som de hover dos botões(chamado pelos botões do menu)
    public void PlayButtonHoverSound()
    {
        RuntimeManager.PlayOneShot(ButtonHoverSound);
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}