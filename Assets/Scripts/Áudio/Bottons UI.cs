using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FMODUnityResonance;


//
public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EventReference Button_Hover;
    [SerializeField] private EventReference Button_Click;
    //[SerializeField] private GameObject ScreenCenter;
    //[SerializeField] private float ScreenCenterDistance = 1f;

    private Button button;
    private EventInstance ClickInstance;
    private EventInstance HoverInstance;

    void Start()
    {
        button = GetComponent<Button>();
    }


    

    public void OnPointerEnter(PointerEventData eventData)
    {
        // only play the hover sound if the button is interactable
        if (button.interactable)
        {   
            HoverInstance = RuntimeManager.CreateInstance(Button_Hover);
            
            HoverInstance.start();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopHoverSound();
    }
        
    public void PlayButtonClickSound()
    {
        // plays button click sound when called
        ClickInstance = RuntimeManager.CreateInstance(Button_Click);
        ClickInstance.start();
        ClickInstance.release();
    }

    private void StopHoverSound()
    {
            HoverInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            HoverInstance.release();

            // clears instance in case of scene change
            HoverInstance.clearHandle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
