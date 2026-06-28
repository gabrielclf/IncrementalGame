using UnityEngine;

[CreateAssetMenu(menuName = "UpgradePontos/Pontos por Click", fileName = "Pontos por Click")]
public class UpgradePorClick : UpgradePontos
{
    public override void AplicarUpgrade()
    {
        if (QuantidadeUpgrades <= 1)
        {
            ClickerManager.instance.PontosPorSeg_Upgrades += QuantidadeUpgrades;
        }
        else
        {
            ClickerManager.instance.PontosPorSeg_Upgrades += QuantidadeUpgrades * 1.5;
        }
    }
}
