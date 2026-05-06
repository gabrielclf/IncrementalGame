using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.EventSystems;

public class UpgradesAudioManager : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] UpgradePontos upgradeData;
    [SerializeField] EventReference UpgradeSound;
    [SerializeField] EventReference BuyUpgradeSound;
    [SerializeField] EventReference ButtonHoverSound;
    private int upgradeLevel = 0;
    void Start()
    {
        //upgradeData = GetComponent<UpgradePontos>();
        //UpgradePontos.QuantidadeUpgrades = 1f;
    }
    //Plays Sound when hovering over button
    public void OnPointerEnter(PointerEventData eventData)
    {
        RuntimeManager.PlayOneShot(ButtonHoverSound);
    }

    public void PlayUpgradeSound()
    {   
        
        if (upgradeLevel < 1)
        {
            RuntimeManager.PlayOneShot(BuyUpgradeSound);
        }
        else
        {
            RuntimeManager.PlayOneShot(UpgradeSound);
        }
        upgradeLevel++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
