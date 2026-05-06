using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] EventReference Button_Hover;
    [SerializeField] EventReference Button_Click;
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button.interactable)
        {
           RuntimeManager.PlayOneShot(Button_Hover);
        } 
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
