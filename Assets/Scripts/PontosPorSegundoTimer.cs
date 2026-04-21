using UnityEngine;

public class PontosPorSegundoTimer : MonoBehaviour
{ //Script controlando a passagem do tempo automatica e sua interação com os upgrades e pontos
    public float duracao_timer = 1f;
    private float _contador;
    public double PontosPorSegundo {get; set;}
    
    private void Update()
    {
        _contador += Time.deltaTime;
        if (_contador >= duracao_timer)
        {
            ClickerManager.instance.AumentoDePontosSimples(PontosPorSegundo);
            _contador = 0;
        }
    }
}
