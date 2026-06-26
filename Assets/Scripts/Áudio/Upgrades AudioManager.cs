using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.EventSystems;

public class UpgradesAudioManager : MonoBehaviour, IPointerEnterHandler
{
    [HideInInspector] public UpgradePontos upgradeData;
    [SerializeField] EventReference UpgradeSound;
    [SerializeField] EventReference BuyUpgradeSound;
    [SerializeField] EventReference CantUpgradeSound;
    [SerializeField] EventReference ButtonHoverSound;
    private int upgradeLevel = 0;

    //Code References
    ClickerManager clickerManager;

    void Start()
    {
        //upgradeData = GetComponent<UpgradePontos>();
        //UpgradePontos.QuantidadeUpgrades = 1f;
        clickerManager = FindAnyObjectByType<ClickerManager>();
    }
    //Plays Sound when hovering over button
    public void OnPointerEnter(PointerEventData eventData)
    {
        RuntimeManager.PlayOneShot(ButtonHoverSound);
    }

    public void PlayUpgradeSound()
    {
        if (clickerManager == null)
        {
            return;
        }
        if (upgradeData == null)
        {
            return;
        }

        if (clickerManager.QuantidadeAtualPontos < upgradeData.CustoAtualUpgrade)
        {
            RuntimeManager.PlayOneShot(CantUpgradeSound);
            return;
        }

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
