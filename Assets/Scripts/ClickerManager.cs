using UnityEngine;
using TMPro;
using DG.Tweening;

public class ClickerManager : MonoBehaviour
{
    public static ClickerManager instance; //classe Ã© singleton por conveniÃªncia
    //Manager dos objetos clicÃ¡veis

    public GameObject MainGameCanvas;
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private TextMeshProUGUI _textoContadorMoedas;
    [SerializeField] private TextMeshProUGUI _textoContadorMoedasPorSeg;
    [SerializeField] private GameObject _moeda;
    public GameObject PopUpMoedas;
    [SerializeField] private GameObject _background;

    [Space]
    [SerializeField] private GameObject _uiUpgrade;
    [SerializeField] private Transform _uiUpgradeTransform;
    public GameObject MoedasPorSeg_Obj;

    public double QuantidadeAtualMoeda { get; set; }
    public double QuantidadeAtualMoedaPorSeg { get; set; }

    //upgrades
    public double MoedasPorSeg_Upgrades { get; set;}

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    //Exibir janela do jogo ou janela de upgrades
    _upgradeCanvas.SetActive(false);
    MainGameCanvas.SetActive(true);


    //Atualizar contadores
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
        _textoContadorMoedasPorSeg.text = QuantidadeAtualMoedaPorSeg.ToString() + " p/s";
    }
    #endregion

    #region Clicar_Moeda

    public void ClicouMoeda()
    {
        GanharMoeda();
        
        //Utilizando pacote externo DOTween para gerar a animaÃ§Ã£o tÃ­pica de "popup" do elemento ao ser clicado
        _moeda.transform.DOBlendableScaleBy(new Vector3(0.05f,0.05f,0.05f),0.05f).OnComplete(MoedaScaleBack);
        _background.transform.DOBlendableScaleBy(new Vector3(0.05f,0.05f,0.05f),0.05f).OnComplete(BackgroundScaleBack);
    }
    //Metodos private para fazer a parte de "diminuir" a imagem do elemento clicado
    private void MoedaScaleBack()
    {
        _moeda.transform.DOBlendableScaleBy(new Vector3(-0.05f,-0.05f,-0.05f),0.05f);
    }
    private void BackgroundScaleBack()
    {
        _background.transform.DOBlendableScaleBy(new Vector3(-0.05f,-0.05f,-0.05f),0.05f);
    }

    public void GanharMoeda()
    {
        QuantidadeAtualMoeda += 1 + MoedasPorSeg_Upgrades;
        AtualizarUIMoedas();

    }
    #endregion
}
