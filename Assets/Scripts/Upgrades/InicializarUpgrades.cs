using UnityEngine;
using UnityEngine.UI;

public class InicializarUpgrades : MonoBehaviour
{
    //criar um botão para cada upgrade de maneira dinâmica
    public void inicializarUpgrades (UpgradePontos[] upgrades, GameObject criarUI, Transform criarUIParent)
    {
        for(int i = 0; i < upgrades.Length; i++)
        {
            int id_Atual = i;
            GameObject go = Instantiate(criarUI, criarUIParent);

            //resetar custo do upgrade
            upgrades[id_Atual].CustoAtualUpgrade = upgrades[id_Atual].CustoOriginalUpgrade;


            //setar (set) texto nos botões
            UpgradeButtons butt = go.GetComponent<UpgradeButtons>();
            butt.TextoBotaoUpgrade.text = upgrades[id_Atual].TextoBotaoUpgrade;
            butt.TextoDescricaoUpgrade.SetText(upgrades[id_Atual].TextoDescricaoUpgrade, upgrades[id_Atual].QuantidadeUpgrades);
            butt.TextoCustoUpgrade.text = "Custo: "+ upgrades[id_Atual].TextoDescricaoUpgrade;

            //setar eventos onClick em botões dinamicamente criados
            butt.BotaoUpgrade.onClick.AddListener(delegate {ClickerManager.instance.ClicarBotaoUpgrade(upgrades[id_Atual], butt); });
        }
    }
}
