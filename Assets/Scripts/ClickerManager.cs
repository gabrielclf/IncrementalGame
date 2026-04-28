using UnityEngine;
using TMPro;
using DG.Tweening;

public class ClickerManager : MonoBehaviour
{
    public static ClickerManager instance; //classe Ã© singleton por conveniÃªncia
    //Manager dos objetos clicÃ¡veis

    public GameObject MainGameCanvas;
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private TextMeshProUGUI _textoContadorPontos;
    [SerializeField] private TextMeshProUGUI _textoContadorPontosPorSeg;
    [SerializeField] private GameObject _moeda;
    public GameObject PopUpPontos;
    [SerializeField] private GameObject _background;

    [Space]
    public UpgradePontos[] up;
    [SerializeField] private GameObject _uiUpgrade;
    [SerializeField] private Transform _uiUpgradeTransform;
    public GameObject PontosPorSeg_Obj;

    public double QuantidadeAtualPontos { get; set; }
    public double QuantidadeAtualPontosPorSeg { get; set; }

    //upgrades
    public double PontosPorSeg_Upgrades { get; set; }

    private InicializarUpgrades _inicializarUpgrades;
    private DisplayPontos _displayPontos;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _displayPontos = GetComponent<DisplayPontos>();

        //Exibir janela do jogo ou janela de upgrades
        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);


        //Atualizar contadores
        AtualizarUIPontos();
        AtualizarUIPontosPorSeg();

        _inicializarUpgrades = GetComponent<InicializarUpgrades>();
        _inicializarUpgrades.inicializarUpgrades(up, _uiUpgrade, _uiUpgradeTransform);
    }

    #region Atualizando UI

    private void AtualizarUIPontos()
    {
       // _textoContadorPontos.text = QuantidadeAtualPontos.ToString();
        _displayPontos.atualizarTextoPontos(QuantidadeAtualPontos,_textoContadorPontos);
    }

    private void AtualizarUIPontosPorSeg()
    {
        //_textoContadorPontosPorSeg.text = QuantidadeAtualPontosPorSeg.ToString() + " p/s";
        _displayPontos.atualizarTextoPontos(QuantidadeAtualPontosPorSeg,_textoContadorPontosPorSeg, " P/S");
    }
    #endregion

    #region Clicar_Moeda

    public void ClicouMoeda()
    {
        GanharMoeda();

        //Utilizando pacote externo DOTween para gerar a animaÃ§Ã£o tÃ­pica de "popup" do elemento ao ser clicado
        _moeda.transform.DOBlendableScaleBy(new Vector3(0.10f, 0.10f, 0.10f), 0.10f).OnComplete(MoedaScaleBack);
        _background.transform.DOBlendableScaleBy(new Vector3(0.03f, 0.03f, 0.03f), 0.03f).OnComplete(BackgroundScaleBack);
    }
    //Metodos private para fazer a parte de "diminuir" a imagem do elemento clicado
    private void MoedaScaleBack()
    {
        _moeda.transform.DOBlendableScaleBy(new Vector3(-0.10f, -0.10f, -0.10f), 0.10f);
    }
    private void BackgroundScaleBack()
    {
        _background.transform.DOBlendableScaleBy(new Vector3(-0.03f, -0.03f, -0.03f), 0.03f);
    }

    public void GanharMoeda()
    {
        QuantidadeAtualPontos += 1 + PontosPorSeg_Upgrades;
        AtualizarUIPontos();

    }
    #endregion

    #region Apertar Botões 
    //Controlando botões
    public void ApertarBotaoUpgrade()
    {
        MainGameCanvas.SetActive(false);
        _upgradeCanvas.SetActive(true);
    }

    public void ApertarBotaoVoltarJogo()
    {
        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);
    }

    #endregion

    #region Aumentos simples
    public void AumentoDePontosSimples(double quantidade)
    {
        QuantidadeAtualPontos += quantidade;
        AtualizarUIPontos();
    }

    public void AumentoDePontosPorSegSimples(double quantidade)
    {
        QuantidadeAtualPontosPorSeg += quantidade;
        AtualizarUIPontosPorSeg();
    }
    #endregion

    #region Eventos Upgrades
    /*  A partir dos scriptable objects definidos previamente, quando o jogador tiver os recursos disponíveis,
        eles serão disponiveis para compra e os outros irão aumentar progressivamente de preço */

    public void ClicarBotaoUpgrade(UpgradePontos upgrade, UpgradeButtons referenciaBotao)
    {
        //Se temos os pontos necessários
        if (QuantidadeAtualPontos >= upgrade.CustoAtualUpgrade)
        {
            //compra o upgrade clicado
            upgrade.AplicarUpgrade();

            //desconta do valor atual
            QuantidadeAtualPontos -= upgrade.CustoAtualUpgrade;

            //atualizar UI
            AtualizarUIPontos();

            //aumentar preço de proximos upgrade e seus numeros na interface
            upgrade.CustoAtualUpgrade = Mathf.Round((float)upgrade.CustoAtualUpgrade)*(1 * upgrade.MultiplicadorAumentoCustoPorUpgrade);
            referenciaBotao.TextoCustoUpgrade.text = "Custo: "+ upgrade.CustoAtualUpgrade;
        }
    }
    #endregion
}
