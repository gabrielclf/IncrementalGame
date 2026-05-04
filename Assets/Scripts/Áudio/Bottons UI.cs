using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] EventReference Button_Hover;
    [SerializeField] EventReference Button_Click;
    void Start()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        RuntimeManager.PlayOneShot(Button_Hover);
    }
    public void PlayButtonClickSound()
    {
        RuntimeManager.PlayOneShot(Button_Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
