using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class ButtonClick : MonoBehaviour
{
    // Referência de som a ser tocado
    [SerializeField] EventReference buttonClickSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtonClickSound()
    {
        RuntimeManager.PlayOneShot(buttonClickSound);
    }
}
