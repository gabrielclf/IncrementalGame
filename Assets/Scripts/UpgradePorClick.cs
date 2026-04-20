using UnityEngine;

[CreateAssetMenu(menuName ="UpgradePontos/Pontos por Click", fileName ="Pontos por Click")]
public class UpgradePorClick : UpgradePontos
{
    public override void AplicarUpgrade()
    {
        ClickerManager.instance.MoedasPorSeg_Upgrades += QuantidadeUpgrades;
    }
}
