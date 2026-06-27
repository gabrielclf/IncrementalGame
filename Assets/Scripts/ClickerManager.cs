using UnityEngine;
using TMPro;
using DG.Tweening;
using Unity.Mathematics.Geometry;
using UnityEngine.SceneManagement;

public class ClickerManager : MonoBehaviour
{
    public static ClickerManager instance; //classe é singleton por conveniência
    //Manager dos objetos clicáveis
    [SerializeField] private GameObject _game; //16/06/2026 - POG para condição de vitória
    public GameObject MainGameCanvas;
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private TextMeshProUGUI _textoContadorPontos;
    [SerializeField] private TextMeshProUGUI _textoContadorPontosPorSeg;
    [SerializeField] private GameObject _moeda;
    [SerializeField] private GameObject _background;

    [Space]
    /*public UpgradePontos[] up;[DEPRECATED]
    [SerializeField] private GameObject _uiUpgrade;
    [SerializeField] private Transform _uiUpgradeTransform;*/
    public GameObject PontosPorSeg_Obj;

    public double QuantidadeAtualPontos { get; set; }
    public double QuantidadeAtualPontosPorSeg { get; set; }

    //upgrades
    public double PontosPorSeg_Upgrades { get; set; }

    //private InicializarUpgrades _inicializarUpgrades; [DEPRECATED]
    private DisplayPontos _displayPontos;

    //30/05/2026 - Controle de codigo para ser executado após mudança de cenas

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _displayPontos = GetComponent<DisplayPontos>();

        //Atualizar contadores
        AtualizarUIPontos();
        AtualizarUIPontosPorSeg();


        //_inicializarUpgrades = GetComponent<InicializarUpgrades>();[DEPRECATED]
        //_inicializarUpgrades.inicializarUpgrades(up, _uiUpgrade, _uiUpgradeTransform);[DEPRECATED]

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Inicializar componentes cena a cena:
        _upgradeCanvas = GameObject.Find("Menu_Upgrades");
        _background = GameObject.Find("BackGround");
        PontosPorSeg_Obj = GameObject.Find("PontosPorSegundo");

        //16/06/2026 - Inserindo Condição de Vitória 
        if (SceneManager.GetActiveScene().name == "Vitoria")
        {
             //16/06/2026 - Não exibir outros componentes de interface
            _game.SetActive(false);
        }
        else
        {
            //Exibir janela do jogo ou janela de upgrades
            _upgradeCanvas.SetActive(false);
            MainGameCanvas.SetActive(true);
        }
    }
    #region Atualizando UI

    private void AtualizarUIPontos()
    {
        // _textoContadorPontos.text = QuantidadeAtualPontos.ToString();[DEPRECATED]
        _displayPontos.atualizarTextoPontos(QuantidadeAtualPontos, _textoContadorPontos);
    }

    private void AtualizarUIPontosPorSeg()
    {
        //_textoContadorPontosPorSeg.text = QuantidadeAtualPontosPorSeg.ToString() + " p/s";[DEPRECATED]
        _displayPontos.atualizarTextoPontos(QuantidadeAtualPontosPorSeg, _textoContadorPontosPorSeg, " P/s");
    }
    #endregion

    #region Clicar_Moeda

    public void ClicouMoeda()
    {
        GanharMoeda();

        //Utilizando pacote externo DOTween para gerar a animaÃ§Ã£o tÃ­pica de "popup" do elemento ao ser clicado
        _moeda.transform.DOBlendableScaleBy(new Vector3(0.10f, 0.10f, 0.10f), 0.10f).OnComplete(MoedaScaleBack);
        //this._background.transform.DOBlendableScaleBy(new Vector3(0.03f, 0.03f, 0.03f), 0.03f).OnComplete(BackgroundScaleBack); [DEPRECATED]
    }
    //Metodos private para fazer a parte de "diminuir" a imagem do elemento clicado
    private void MoedaScaleBack()
    {
        _moeda.transform.DOBlendableScaleBy(new Vector3(-0.10f, -0.10f, -0.10f), 0.10f);
    }
    /* private void BackgroundScaleBack() [DEPRECATED]
     {
         _background.transform.DOBlendableScaleBy(new Vector3(-0.03f, -0.03f, -0.03f), 0.03f);
     }*/

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
       
        _upgradeCanvas.SetActive(true);
    }

    public void ApertarBotaoVoltarJogo()
    {
        _upgradeCanvas.SetActive(false);
       
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

    public void ClicarBotaoUpgrade(UpgradePontos upgrade, UpgradeButtons referenciaBotao, string titulo_upgrade)
    {
        //Condição de vitoria (chama)
        if (titulo_upgrade == "SalvarBrasil")
        {
            _upgradeCanvas.SetActive(false);
            MainGameCanvas.SetActive(false);
            SceneManager.LoadScene("Vitoria");
        }
        else
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
                upgrade.CustoAtualUpgrade = Mathf.Round((float)((upgrade.CustoAtualUpgrade) * (1 + upgrade.MultiplicadorAumentoCustoPorUpgrade)));
                referenciaBotao.TextoCustoUpgrade.text = "Custo: " + upgrade.CustoAtualUpgrade;
            }
        }

    }
    #endregion
}
