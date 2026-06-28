using UnityEngine;

[CreateAssetMenu(menuName = "UpgradePontos/Pontos por Segundo", fileName = "Pontos por Segundo")]
public class UpgradePorSegundo : UpgradePontos
{
    public override void AplicarUpgrade()
    { //verificar quantidade de upgrades para determinar como o ganho de pontos por segundo deve ser feito 
        GameObject gameObject = Instantiate(ClickerManager.instance.PontosPorSeg_Obj, Vector3.zero, Quaternion.identity);
        gameObject.GetComponent<PontosPorSegundoTimer>().PontosPorSegundo = QuantidadeUpgrades;
        DontDestroyOnLoad(gameObject);
        if (QuantidadeUpgrades <= 1)
        {
            ClickerManager.instance.AumentoDePontosPorSegSimples(QuantidadeUpgrades);
        }
        else
        {
            gameObject.GetComponent<PontosPorSegundoTimer>().PontosPorSegundo = QuantidadeUpgrades*1.5;
            ClickerManager.instance.AumentoDePontosPorSegSimples(QuantidadeUpgrades * 1.5);

        }
    }
}
