using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FMODUnityResonance;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EventReference Button_Hover;
    [SerializeField] private EventReference Button_Click;

    private Button button;
    private EventInstance hoverInstance;

    void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button.interactable)
        {
            hoverInstance = RuntimeManager.CreateInstance(Button_Hover);
            hoverInstance.start();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopHoverSound();
    }
        
    public void PlayButtonClickSound()
    {
        RuntimeManager.PlayOneShot(Button_Click);
    }

    private void StopHoverSound()
    {
        if (hoverInstance.isValid())
        {
            hoverInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            hoverInstance.release();
            hoverInstance.clearHandle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
