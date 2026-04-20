using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class UpgradePontos : ScriptableObject
{ //Upgrades que irão afetar os valores do jogo. Abstract class pq será usada por outras classes depois.
    //valores placeholder são iguais ao vídeo inspiração por enquanto
    public float QuantidadeUpgrades = 1f;

    public double CustoOriginalUpgrade = 100;
    public double CustoAtualUpgrade = 100;
    public double MultiplicadorAumentoCustoPorUpgrade = 0.05f;

    public string TextoBotaoUpgrade;
    [TextArea(3,10)]
    public string TextoDescricaoUpgrade;

    public abstract void AplicarUpgrade();

    private void OnValidate() {
        CustoAtualUpgrade = CustoOriginalUpgrade;        
    }
}
