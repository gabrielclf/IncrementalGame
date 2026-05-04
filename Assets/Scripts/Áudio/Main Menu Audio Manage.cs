using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class MainMenuAudioManage : MonoBehaviour
{
    [Header("Audio References")]
    [SerializeField] EventReference MainMenuMusic;


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
    
    // Método para tocar o som de hover dos botões(chamado pelos botões do menu)

    // Update is called once per frame
    void Update()
    {
        
    }
}