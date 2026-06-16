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


            //setar (set) texto nos botões (TO DO: 11/06/2026 Inserir imagens)
            UpgradeButtons butt = go.GetComponent<UpgradeButtons>();
            butt.TituloUpgrade.text = upgrades[id_Atual].TextoTituloUpgrade;
            butt.TextoBotaoUpgrade.text = upgrades[id_Atual].TextoBotaoUpgrade;
            butt.TextoDescricaoUpgrade.SetText(upgrades[id_Atual].TextoDescricaoUpgrade, upgrades[id_Atual].QuantidadeUpgrades);
            butt.TextoCustoUpgrade.text = "Custo: "+ upgrades[id_Atual].CustoAtualUpgrade;
            //11/06/26 - Inserindo assets de imagens
            butt.Ilustracao.sprite = upgrades[id_Atual]._imagem;

            //setar eventos onClick em botões dinamicamente criados
            butt.BotaoUpgrade.onClick.AddListener(delegate {ClickerManager.instance.ClicarBotaoUpgrade(upgrades[id_Atual], butt,upgrades[id_Atual].TextoTituloUpgrade); });

            //setar upgradeData no audio manager
            UpgradesAudioManager audioManager = go.GetComponentInChildren<UpgradesAudioManager>();
            if (audioManager != null)
                audioManager.upgradeData = upgrades[id_Atual];
            else
                Debug.LogWarning("InicializarUpgrades: UpgradesAudioManager not found on upgrade prefab: " + go.name);
        }
    }
}
