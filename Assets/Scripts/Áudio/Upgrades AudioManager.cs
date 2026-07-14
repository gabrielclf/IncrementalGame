using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.EventSystems;
using System.Collections;

public class UpgradesAudioManager : MonoBehaviour, IPointerEnterHandler
{
    [HideInInspector] public UpgradePontos upgradeData;
    [SerializeField] EventReference UpgradeSound;
    [SerializeField] EventReference BuyUpgradeSound;
    [SerializeField] EventReference CantUpgradeSound;
    [SerializeField] EventReference ButtonHoverSound;
    private bool Clicked = false;
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
    { if (Clicked == true)
        {
            return;
        }
        if (clickerManager == null)
        {
            Debug.LogWarning("UpgradesAudioManager: clickerManager is null. Is ClickerManager present in the scene?", this);
            return;
        }
        if (upgradeData == null)
        {
            Debug.LogWarning("UpgradesAudioManager: upgradeData is not assigned in the Inspector.", this);
            return;
        }

        if (clickerManager.QuantidadeAtualPontos < upgradeData.CustoAtualUpgrade)
        {
            RuntimeManager.PlayOneShot(CantUpgradeSound);
            Clicked = true;
            StartCoroutine(clickSoundDelay());
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
        Clicked = true;
        StartCoroutine(clickSoundDelay());
    }

    IEnumerator clickSoundDelay()
    {
        yield return new WaitForSeconds(0.25f);
        Clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
