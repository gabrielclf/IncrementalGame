using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (_moeda == null)
        {
            _moeda = GameObject.FindGameObjectWithTag("Player");
        }

        //Fazer a loja de upgrades correta na região/cena correta
        Scene _cenaAtual = SceneManager.GetActiveScene();
        if (_uiUpgradeTransform == null)
        {
            switch (_cenaAtual.name)
            {
                case "RegiaoNorte":
                    _uiUpgradeTransform.transform.Find("ContentN");
                    break;

                case "RegiaoNordeste":
                    _uiUpgradeTransform.transform.Find("ContentNE");
                    break;

                case "RegiaoCentroOeste":
                    _uiUpgradeTransform.transform.Find("ContentCO");
                    break;

                case "RegiaoSudesteSul":
                    _uiUpgradeTransform.transform.Find("ContentSS");
                    break;

                default:

                    break;

            }
        }
    }
}
