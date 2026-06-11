using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class MainMenuAudioManage : MonoBehaviour
{
    [Header("Audio References")]
    [SerializeField] EventReference MainMenuMusic;
    [SerializeField] EventInstance MainMenuMusicInstance;

    [SerializeField] EventReference GameplaySnapshot;
    [SerializeField] EventInstance GameplaySnapshotInstance;


    void Start()
    {
        PlayMainMenuMusic();
        GameplaySnapshotInstance = RuntimeManager.CreateInstance(GameplaySnapshot);
        GameplaySnapshotInstance.start();
    }
    void Oestroy()
    {
      StopMusic(); 
      stopSnapshot(); 
    }


    #region Music Activation
    // Método para tocar a música do menu principal
    public void PlayMainMenuMusic()
    {
        MainMenuMusicInstance = RuntimeManager.CreateInstance(MainMenuMusic);
        MainMenuMusicInstance.start();
    } 
    #endregion
    
    // Método para tocar o som de hover dos botões(chamado pelos botões do menu)

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopMusic()
    {
        MainMenuMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        MainMenuMusicInstance.release();
    }
    void stopSnapshot()
    {
        GameplaySnapshotInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        GameplaySnapshotInstance.release();
    }
}