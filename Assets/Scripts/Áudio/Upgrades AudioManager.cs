using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.EventSystems;

public class UpgradesAudioManager : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] EventReference UpgradeSound;
    [SerializeField] EventReference ButtonHoverSound;
    void Start()
    {
        
    }
    //Plays Sound when hovering over button
    public void OnPointerEnter(PointerEventData eventData)
    {
        RuntimeManager.PlayOneShot(ButtonHoverSound);
    }

    public void PlayUpgradeSound()
    {
        RuntimeManager.PlayOneShot(UpgradeSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
