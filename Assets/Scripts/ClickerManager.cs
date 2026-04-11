using UnityEngine;
using TMPro;

public class ClickerManager : MonoBehaviour
{
    public static ClickerManager instance; //classe é singleton por conveniência
    //Manager dos objetos clicáveis

    public GameObject MainGameCanvas;
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private TextMeshProUGUI _textoContadorMoedas;
    [SerializeField] private TextMeshProUGUI _textoContadorMoedasPorSeg;
    public GameObject PopUpMoedas;
    [SerializeField] private GameObject _background;

    [Space]
    [SerializeField] private GameObject _uiUpgrade;
    [SerializeField] private Transform _uiUpgradeTransform;
    public GameObject MoedasPorSeg_Obj;

    public double QuantidadeAtualMoeda { get; set;}
    public double QuantidadeAtualMoedaPorSeg {get; set;}

    //upgrades
    public double MoedasPorSeg_Upgrades {get; set;}

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    AtualizarUIMoedas();
    AtualizarUIMoedasPorSeg();
    }

    #region Atualizando UI

    private void AtualizarUIMoedas()
    {
        _textoContadorMoedas.text = QuantidadeAtualMoeda.ToString();
    }

    private void AtualizarUIMoedasPorSeg()
    {
        _textoContadorMoedasPorSeg.text = QuantidadeAtualMoedaPorSeg.ToString() + "p/s";
    }


    #endregion

    #region Clicar_Moeda

    public void ClicouMoeda()
    {
        GanharMoeda();
    }

    public void GanharMoeda()
    {
        QuantidadeAtualMoeda += 1 + MoedasPorSeg_Upgrades;

    }


    #endregion
}
