using UnityEngine;

[CreateAssetMenu(menuName ="UpgradePontos/Pontos por Segundo", fileName ="Pontos por Segundo")]
public class UpgradePorSegundo : UpgradePontos
{
    public override void AplicarUpgrade()
    { //verificar quantidade de upgrades para determinar como o ganho de pontos por segundo deve ser feito 
        GameObject gameObject = Instantiate(ClickerManager.instance.PontosPorSeg_Obj, Vector3.zero, Quaternion.identity);
        gameObject.GetComponent<PontosPorSegundoTimer>().PontosPorSegundo = QuantidadeUpgrades;

        ClickerManager.instance.AumentoDePontosPorSegSimples(QuantidadeUpgrades);
    }
}
