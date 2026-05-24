using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject _moeda;
    public UpgradePontos[] _upgrades;
    [Space]
    private InicializarUpgrades _inicializarUpgrades;
    [SerializeField] private GameObject _uiUpgrade;
    [SerializeField] private Transform _uiUpgradeTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        _inicializarUpgrades = GetComponent<InicializarUpgrades>();
        _inicializarUpgrades.inicializarUpgrades(_upgrades, _uiUpgrade, _uiUpgradeTransform);
    }
}
